using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Message;
using YJC.Toolkit.Weixin.Rule;

namespace YJC.Toolkit.Weixin.Rule
{
    internal class CorpAppLogRule : IRule
    {
        public BaseSendMessage Reply(ReceiveMessage message)
        {
            TkDbContext context = DbContextUtil.CreateDbContext("Weixin");
            using (EmptyDbDataSource source = new EmptyDbDataSource() { Context = context})
            using (TableResolver resolver = new TableResolver("WE_CORP_APP_LOG", source))
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
