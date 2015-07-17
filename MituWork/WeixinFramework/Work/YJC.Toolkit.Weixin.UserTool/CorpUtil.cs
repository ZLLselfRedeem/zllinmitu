using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.UserTool
{
    internal static class CorpUtil
    {
        private const int ATTEN = 1;
        private const int NOATTEN = 0;

        public static void UpSync()
        {
            var luser = CorpDepartment.GetAllUsers(1, true);
            Dictionary<string, bool> userId = new Dictionary<string, bool>();
            foreach (var lu in luser.UserList)
                userId.Add(lu.Id, false);

            Dictionary<string, Tuple<CorpUser, DataRow>> DbId = new Dictionary<string, Tuple<CorpUser, DataRow>>();
            using (EmptyDbDataSource source = new EmptyDbDataSource())
            using (TableResolver resolver = new TableResolver("WE_CORP_USER", source))
            {
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
                        DbId.Add(user.Id, Tuple.Create(user, db));
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
                        ResultHandle(v.Value.Item1.Name, result);
                    }
                    else
                    {
                        userId.Add(v.Key, true);
                        var result = v.Value.Item1.Create();
                        ResultHandle(v.Value.Item1.Name, result);
                    }
            }

            IEnumerable<string> remainder = from u in userId
                                            where !u.Value
                                            select u.Key;

            foreach (var rd in remainder)
            {
                CorpUser user = new CorpUser(rd, "user", new int[] { 1 });
                var result = user.Delete();
                ResultHandle(rd, result);
            }

        }

        public static void ResultHandle(string userName, WeixinResult result)
        {
            if (result.IsError)
                Console.WriteLine("User : {0}, {1}", userName, result);
        }

        //public static void DownSync()
        //{
        //    WeFanContainter container = WeFanContainter.GetFans();
        //    DateTime timeNow = DateTime.Now;
        //    int timeVersion = (int)timeNow.ToOADate();

        //    using (EmptyDbDataSource source = new EmptyDbDataSource())
        //    using (TableResolver resolver = new TableResolver("WE_USER", source))
        //    using (TableResolver subResolver = new TableResolver("WE_SUBSCRIBE_DATA", source))
        //    {
        //        subResolver.SetCommands(AdapterCommand.Insert);
        //        resolver.SetCommands(AdapterCommand.Insert | AdapterCommand.Update);
        //        while (true)
        //        {
        //            if (container.OpenIds == null)
        //                break;
        //            foreach (var openId in container.OpenIds)
        //            {
        //                WeUser user = WeUser.GetUser(openId);
        //                DataRow row = resolver.TrySelectRowWithKeys(openId);
        //                if (row == null)
        //                {
        //                    row = resolver.NewRow();
        //                    DataRow subRow = subResolver.NewRow();
        //                    subRow.BeginEdit();
        //                    subRow["Id"] = subResolver.CreateUniId();
        //                    subRow["OpenId"] = openId;
        //                    subRow["SubscribeDate"] = user.SubscribeTime;
        //                    subRow["IsSubscribe"] = 1;
        //                    subRow.EndEdit();
        //                }
        //                user.AddToDataRow(row, WeConst.USER_MODE);
        //                row["Version"] = timeVersion;
        //            }
        //            UpdateUtil.UpdateTableResolvers(source.Context, (Action<Transaction>)null, resolver, subResolver);
        //            resolver.HostTable.Rows.Clear();
        //            subResolver.HostTable.Rows.Clear();
        //            if (string.IsNullOrEmpty(container.NextOpenId))
        //                break;
        //            else
        //                container = WeFanContainter.GetFans(container);
        //        }

        //        resolver.HostTable.Rows.Clear();
        //        subResolver.HostTable.Rows.Clear();
        //        IParamBuilder builder = SqlParamBuilder.CreateParamBuilder(
        //            SqlParamBuilder.CreateSingleSql(source.Context, "WU_VERSION", TkDataType.Int, "!=", timeVersion),
        //            ParamBuilder.CreateSql("WU_SUBSCRIBE = 1"));

        //        resolver.Select(builder);
        //        if (resolver.HostTable.Rows.Count > 0)
        //        {
        //            foreach (DataRow row in resolver.HostTable.Rows)
        //            {
        //                row["subscribe"] = 0;
        //                DataRow subRow = subResolver.NewRow();
        //                subRow.BeginEdit();
        //                subRow["Id"] = subResolver.CreateUniId();
        //                subRow["OpenId"] = row["OpenId"];
        //                subRow["Subscribe"] = DateTime.Now;
        //                subRow["IsSubscribe"] = 0;
        //                subRow.EndEdit();
        //            }
        //            UpdateUtil.UpdateTableResolvers(source.Context, (Action<Transaction>)null, resolver, subResolver);
        //        }
        //    }
        //}
    }
}
