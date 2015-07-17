using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    [MessageLogConfig(NamespaceType = NamespaceType.Toolkit, CreateDate = "2014-05-09",
       Author = "YJC", Description = "把接收的消息存成文件")]
    class FileMessageLogConfig : IConfigCreator<IMessageLog>
    {
        #region IConfigCreator<IMessageLog> 成员

        public IMessageLog CreateObject(params object[] args)
        {
            return new FileMessageLog(BasePath);
        }

        #endregion

        [SimpleAttribute]
        public string BasePath { get; private set; }
    }
}
