using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-20",
        Description = "微信企业号发送文字消息的数据源")]
    [InstancePlugIn, AlwaysCache]
    internal class CorpMessageObjectSource : IInsertObjectSource
    {
        public static object Instance = new CorpMessageObjectSource();

        private CorpMessageObjectSource()
        {
        }

        #region IInsertObjectSource 成员

        public object CreateNew(IInputData input)
        {
            CorpMessageSender sender = new CorpMessageSender();
            sender.ReadQueryString(input.QueryStringText);
            return sender;
        }

        public OutputData Insert(IInputData input, object instance)
        {
            CorpMessageSender sender = instance.Convert<CorpMessageSender>();
            sender.SendMessage();
            return OutputData.CreateToolkitObject(new KeyData("Id", "OK"));
        }

        #endregion
    }
}
