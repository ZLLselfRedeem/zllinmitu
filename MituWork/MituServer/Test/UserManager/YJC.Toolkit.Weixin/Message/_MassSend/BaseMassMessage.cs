using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class BaseMassMessage
    {
        protected BaseMassMessage()
        {
        }

        [SimpleElement(Order = 100, LocalName = "msgtype")]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public MessageType MsgType { get; protected set; }

        public static WeixinResult Delete(long msgId)
        {
            MassMessageResult msg = new MassMessageResult(msgId);
            string url = WeUtil.GetUrl(WeConst.DELETE_MASS_MESSAGE_URL);

            return WeUtil.PostToUri(url, msg.WriteJson(), new WeixinResult());
        }
    }
}
