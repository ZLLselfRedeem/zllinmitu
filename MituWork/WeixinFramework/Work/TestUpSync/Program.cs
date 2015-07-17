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
        private const int ATTEN = 1;
        private const int NOATTEN = 0;

        static void Main(string[] args)
        {
            if (!ConsoleApp.Initialize())
                return;

            ReadUser();
            ReadDb();
            UpSync();
            Console.WriteLine("after Sync:");
            ReadUser();
            ReadDb();
            Console.ReadKey();
        }

        public static void UpSync()
        {
            var luser = CorpDepartment.GetAllUsers(1, true);
            Dictionary<string, bool> userId = new Dictionary<string, bool>();
            foreach (var lu in luser.UserList)
                userId.Add(lu.Id, false);

            Dictionary<string, Tuple<CorpUser, DataRow>> DbId = new Dictionary<string, Tuple<CorpUser, DataRow>>();
            EmptyDbDataSource source = new EmptyDbDataSource();
            TableResolver resolver = new TableResolver("WE_CORP_USER", source);
            resolver.SetCommands(AdapterCommand.Update);
            resolver.Select();

            foreach (DataRow db in resolver.HostTable.Rows)
            {
                CorpUser user = new CorpUser("1", "user", new int[] { 1 });
                bool isDelete = db["ValidFlag"].Value<bool>();
                user.ReadFromDataRow(db, "CorpUser");

                if (!isDelete)
                {
                    user.Enable = true;
                    Tuple<CorpUser, DataRow> tup = new Tuple<CorpUser, DataRow>(user, db);
                    DbId.Add(user.Id, tup);
                }
            }

            foreach (var v in DbId)
                if (userId.ContainsKey(v.Key))
                {
                    var userStatus = CorpUser.GetUser(v.Key).Status;
                    bool changed = false;

                    if (userStatus == UserStatus.Attention)
                    {
                        if (v.Value.Item2["AttentionFlag"].Value<int>() != ATTEN)
                        {
                            v.Value.Item2["AttentionFlag"] = ATTEN;
                            changed = true;
                        }
                    }
                    else if (v.Value.Item2["AttentionFlag"].Value<int>() == ATTEN)
                    {
                        v.Value.Item2["AttentionFlag"] = NOATTEN;
                        changed = true;
                    }

                    if (changed)
                        resolver.UpdateDatabase();

                    userId[v.Key] = true;
                    var result = v.Value.Item1.Update();
                    if (result.IsError)
                        Console.WriteLine("Update Error : User:{0}, {1}", v.Value.Item1.Name, result);
                }
                else
                {
                    userId.Add(v.Key, true);
                    var result = v.Value.Item1.Create();
                    if (result.IsError)
                        Console.WriteLine("Create Error : User:{0}, {1}", v.Value.Item1.Name, result);
                }

            var remainder = from u in userId
                            where !u.Value
                            select u.Key;

            foreach (var rd in remainder)
            {
                CorpUser user = new CorpUser(rd, "user", new int[] { 1 });
                var result = user.Delete();
                if (result.IsError)
                    Console.WriteLine("Delete Error : User:{0}, {1}", rd, result);
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