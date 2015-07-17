using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class BaseServiceMessage : BaseJsonMessage
    {
        protected BaseServiceMessage(string toUser, MessageType msgType)
            : base(msgType)
        {
            TkDebug.AssertArgumentNullOrEmpty(toUser, "toUser", null);

            ToUser = toUser;
        }


        public WeixinResult Send()
        {
            string url = WeUtil.GetUrl(WeConst.SERVICE_URL);
            WeixinResult result = new WeixinResult();
            result = WeUtil.PostToUri(url, ToJson(), result);

            return result;
        }
    }
}
