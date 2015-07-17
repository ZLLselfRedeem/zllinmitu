using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Data
{
    internal sealed class DbMessageLog : IMessageLog
    {
        public static readonly IMessageLog Instance = new DbMessageLog();

        private DbMessageLog()
        {
        }

        #region IMessageLog 成员

        public void Log(ReceiveMessage message)
        {
            using (WeixinDataSource source = new WeixinDataSource())
            using (MessageResolver resolver = new MessageResolver(source))
            {
                resolver.SetCommands(AdapterCommand.Insert);
                DataRow row = resolver.NewRow();
                message.AddToDataRow(row);
                row["CreateDate"] = message.CreateTime;
                resolver.UpdateDatabase();
            }
        }

        #endregion
    }
}
