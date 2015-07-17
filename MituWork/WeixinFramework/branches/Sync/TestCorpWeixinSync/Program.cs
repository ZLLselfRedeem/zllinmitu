using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace TestCorpWeixin
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!ConsoleApp.Initialize())
                return;

            ReadUser();
            ReadDb();
            Synchronize();
            Console.WriteLine("after Sync:");
            ReadUser();
            ReadDb();
            Console.ReadKey();
        }

        private static void Synchronize()
        {
            var luser = CorpDepartment.GetAllUsers(1, true);
            Dictionary<string, bool> userId = new Dictionary<string, bool>();
            foreach (var lu in luser.UserList)
                userId.Add(lu.Id, false);

            Dictionary<string, CorpUser> DbId = new Dictionary<string, CorpUser>();
            EmptyDbDataSource source = new EmptyDbDataSource();
            TableResolver resolver = new TableResolver("WE_CORP_USER", source);
            resolver.Select();

            foreach (DataRow db in resolver.HostTable.Rows)
            {
                CorpUser user = new CorpUser("1", "user", new int[] { 1 });
                bool isDelete = db["ValidFlag"].Value<bool>();
                user.ReadFromDataRow(db, "CorpUser");

                if (!isDelete)
                {
                    user.Enable = true;
                    DbId.Add(user.Id, user);
                }
            }

            foreach (var v in DbId)
                if (userId.ContainsKey(v.Key))
                {
                    userId[v.Key] = true;
                    v.Value.Update();
                }
                else
                {
                    userId.Add(v.Key, true);
                    v.Value.Create();
                }

            var remainder = from u in userId
                            where !u.Value
                            select u.Key;

            foreach (var rd in remainder)
            {
                CorpUser user = new CorpUser(rd, "user", new int[] { 1 });
                user.Delete();
            }
        }

        private static void ReadUser()
        {
            var list = CorpDepartment.GetAllUsers(1, true);
            foreach (CorpSimpleUser item in list.UserList)
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