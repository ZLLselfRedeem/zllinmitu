using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class BaseJsonMessage
    {
        protected BaseJsonMessage(MessageType msgType)
        {
            MsgType = msgType;
        }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 10)]
        public string ToUser { get; protected set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 20)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public MessageType MsgType { get; protected set; }

        public virtual string ToJson()
        {
            return this.WriteJson(WeConst.WRITE_SETTINGS);
        }
    }
}
