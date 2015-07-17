using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with Data Readers\n");
            // 特定于SQLserver数据库的提供程序的对象
            // create and open a connection
            SqlConnectionStringBuilder cnStrBuilder = new SqlConnectionStringBuilder();
            cnStrBuilder.InitialCatalog = "AutoLot";
            cnStrBuilder.DataSource = @"(local)\SQLEXPRESS";
            cnStrBuilder.ConnectTimeout = 30;
            cnStrBuilder.IntegratedSecurity = true;

            //string cnStrTest = @"Data Source=(local)\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AutoLot";
            //SqlConnectionStringBuilder cnStrBuilderTest = new SqlConnectionStringBuilder(cnStrTest);
            //cnStrBuilderTest.ConnectTimeout = 10;

            
            using (SqlConnection cn = new SqlConnection())
            {
                //cn.ConnectionString = cnStrBuilderTest.ConnectionString;
                cn.ConnectionString = cnStrBuilder.ConnectionString;
                
                cn.Open();
                // create an sql command object.
                ShowConnectionStatus(cn);
                string strSql = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(strSql, cn);
                myCommand.Prepare();
                //SqlCommand myCommand = new SqlCommand();
                //myCommand.Connection = cn;
                //myCommand.CommandText = strSql;

                // obtain a data reader ExecuteReader();
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // 数据读取器通过Read()方法返回一个布尔值来表示是否读完数据
                    while (myDataReader.Read())
                    {
                        Console.WriteLine("-> Make: {0}, PetName: {1}, Color: {2}, Type: {3}",
                            myDataReader["Make"].ToString(),
                            myDataReader[1].ToString(),
                            myDataReader["Color"].ToString(),
                            myDataReader["PetName"].GetType().Name);
                    }
                }
            }
        }

        private static void ShowConnectionStatus(SqlConnection cn)
        {
            Console.WriteLine("Info about your connection");
            Console.WriteLine("Database location: {0}", cn.DataSource);
            Console.WriteLine("Database name: {0}", cn.Database);
            Console.WriteLine("TimeOut: {0}", cn.ConnectionTimeout);
            Console.WriteLine("Connection status: {0}, Type: {1}", cn.State.ToString(), cn.State.GetType().Name);
        }

        private static void SqlCommandPrepareEx(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);
                command.CommandText = "INSERT INTO Region(RegionID, RegionDescription) VALUES (@id, @desc)";
                SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                SqlParameter descParam = new SqlParameter("@desc", SqlDbType.Text, 100);
                idParam.Value = 20;
                idParam.Value = "First Region";
                command.Parameters.Add(idParam);
                command.Parameters.Add(descParam);
                command.Prepare();
                command.ExecuteNonQuery();

                command.Parameters[0].Value = 21;
                command.Parameters[1].Value = "Second Region";
                command.ExecuteNonQuery();
            }
        }
    }
}
