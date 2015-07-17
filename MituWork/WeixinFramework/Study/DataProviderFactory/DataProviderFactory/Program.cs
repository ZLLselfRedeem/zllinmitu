using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DataProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Data Provider Factories\n");
            // Get Connetion string/provider form *.config.
            string dp = ConfigurationManager.AppSettings["provider"];
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            // Get the factory provider
            DbProviderFactory df = DbProviderFactories.GetFactory(dp);

            // Now get the connection object
            using (DbConnection cn = df.CreateConnection())
            {
                Console.WriteLine("Your connection object is a: {0}", cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();
                // Make command object.
                DbCommand cmd = df.CreateCommand();
                Console.WriteLine("Your command object is a: {0}", cmd.GetType().Name);
                cmd.Connection = cn;
                cmd.CommandText = "Select * From Inventory";

                // Print out data with data reader
                using (DbDataReader dr = cmd.ExecuteReader())
                {
                    Console.WriteLine("Your data reader object is a: {0}", dr.GetType().Name);

                    Console.WriteLine("\n Current Inventory");
                    while (dr.Read())
                    {
                        Console.WriteLine("-> Car #{0} is a {1}.",dr["CarID"],dr["Make"].ToString());
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
