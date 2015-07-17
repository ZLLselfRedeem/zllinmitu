using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace CSVUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!ConsoleApp.Initialize())
                return;

            string fileName = @"D:\C#\微信完整分类.csv";
            DataSet dSet = CSVUtility.OpenCSV(fileName);

            using (EmptyDbDataSource source = new EmptyDbDataSource())
            using (TableResolver resolver = new TableResolver("WE_CATEGORY", source))
            {
                resolver.SetCommands(AdapterCommand.Insert);
                DataRow newRow;
                foreach (DataRow row in dSet.Tables[0].Rows)
                {
                    newRow = resolver.NewRow();
                    row.AddToDataRow(newRow);
                }
               // resolver.UpdateDatabase();
            }
        }
    }
}
