using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Data;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessage(CreateDate = "2014-12-26", Author = "YJC",
        Description = "企业号用户进入应用时数据库登记")]
    internal class CorpAppLogRule : IRule
    {
        public BaseSendMessage Reply(ReceiveMessage message)
        {
            using (EmptyDbDataSource source = WeDataUtil.CreateSource())
            using (TableResolver resolver = new CorpAppLogResolver(source))
            {
                resolver.SetCommands(AdapterCommand.Insert);
                DataRow row = resolver.NewRow();
                row.BeginEdit();
                row["LogId"] = resolver.CreateUniId();
                row["AppId"] = message.AgentId;
                row["CreateDate"] = message.CreateTime;
                row["UserId"] = message.FromUserName;
                row.EndEdit();
                resolver.UpdateDatabase();
            }
            return null;
        }
    }
}
