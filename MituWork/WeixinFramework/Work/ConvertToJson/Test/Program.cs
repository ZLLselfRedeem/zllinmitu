using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!ConsoleApp.Initialize())
                return;

            //ReadUser();
            ReadDb();
            Console.ReadKey();
        }

        private static void ReadUser()
        {
            var list = CorpDepartment.GetAllUsers(1, true);
            foreach (var item in list.UserList)
            {
                Console.WriteLine(item);
            }
        }

        private static void ReadDb()
        {
            EmptyDbDataSource source = new EmptyDbDataSource();
            TableResolver resolver = new TableResolver("WE_CORP_USER", source);

            resolver.Select();
            foreach (DataRow row in resolver.HostTable.Rows)
            {
                CorpUser user = new CorpUser("1", "user", new int[] { 1 });
                user.ReadFromDataRow(row, "CorpUser");
                Console.WriteLine(user);
            }
        }
    }
}
