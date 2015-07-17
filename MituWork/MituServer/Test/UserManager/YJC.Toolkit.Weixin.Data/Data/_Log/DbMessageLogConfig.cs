using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    [MessageLogConfig(NamespaceType = NamespaceType.Toolkit, CreateDate = "2014-04-02",
        Author = "YJC", Description = "缺省向数据库存入接收的消息")]
    internal class DbMessageLogConfig : IConfigCreator<IMessageLog>
    {
        #region IConfigCreator<IMessageLog> 成员

        public IMessageLog CreateObject(params object[] args)
        {
            return DbMessageLog.Instance;
        }

        #endregion
    }
}
