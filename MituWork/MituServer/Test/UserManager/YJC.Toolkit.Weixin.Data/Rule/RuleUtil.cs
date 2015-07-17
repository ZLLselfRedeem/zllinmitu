using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Data;
using YJC.Toolkit.Weixin.Message;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Rule
{
    internal static class RuleUtil
    {
        public static void ProcessCorpUser(bool subscribe, string logonName)
        {
            using (EmptyDbDataSource source = WeDataUtil.CreateSource())
            using (InternalCorpUserResolver resolver = new InternalCorpUserResolver(source))
            {
                DataRow row = resolver.TrySelectRowWithParam("UserLogonName", logonName);
                if (row != null)
                {
                    resolver.SetCommands(AdapterCommand.Update);
                    row.BeginEdit();
                    DateTime current = DateTime.Now;
                    if (subscribe)
                    {
                        row["AttentionFlag"] = 1;
                        row["AttentionDate"] = current;
                        row["UnAttentionDate"] = DBNull.Value;
                    }
                    else
                    {
                        row["AttentionFlag"] = 0;
                        row["UnAttentionDate"] = current;
                    }
                    row["UpdateDate"] = current;
                    row.EndEdit();
                }

                resolver.UpdateDatabase();
            }
        }

        public static void ProcessNormalUser(bool subscrible, string openId)
        {
            using (EmptyDbDataSource source = WeDataUtil.CreateSource())
            using (UserResolver resolver = new UserResolver(source))
            using (SubscribeDataResolver subResolver = new SubscribeDataResolver(source))
            {
                subResolver.SetCommands(AdapterCommand.Insert);
                resolver.SetCommands(AdapterCommand.Insert | AdapterCommand.Update);
                DateTime current = DateTime.Now;

                DataRow row = resolver.TrySelectRowWithKeys(openId);
                if (row == null)
                    row = resolver.NewRow();
                if (subscrible)
                {
                    WeUser user = WeUser.GetUser(openId);
                    user.AddToDataRow(row);
                }
                else
                    row["Subscribe"] = 0;

                DataRow subRow = subResolver.NewRow();
                subRow.BeginEdit();
                subRow["Id"] = subResolver.CreateUniId();
                subRow["OpenId"] = openId;
                subRow["SubscribeDate"] = current;
                subRow["IsSubscribe"] = subscrible ? 1 : 0;
                subRow.EndEdit();

                UpdateUtil.UpdateTableResolvers(source.Context, null,
                    new TableResolver[] { resolver, subResolver });
            }
        }

        public static BaseSendMessage Execute(Action<bool, string> processor, bool subscrible, string data)
        {
            TkDebug.ThrowIfNoAppSetting();
            TkDebug.ThrowIfNoGlobalVariable();

            if (BaseAppSetting.Current.UseWorkThread)
                BaseGlobalVariable.Current.BeginInvoke(processor, subscrible, data);
            else
                processor(subscrible, data);

            return null;
        }
    }
}
