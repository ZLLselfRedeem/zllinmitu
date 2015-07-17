using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.UserTool
{
    internal static class CorpUtil
    {
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
    }
}
