using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class BaseMessage
    {
        protected BaseMessage()
        {
        }

        [SimpleElement(Order = 10, UseCData = true)]
        public string ToUserName { get; protected set; }

        [SimpleElement(Order = 20, UseCData = true)]
        public string FromUserName { get; protected set; }

        [SimpleElement(Order = 30)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; protected set; }

        [SimpleElement(Order = 40, UseCData = true)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public MessageType MsgType { get; protected set; }

        public string ToXml()
        {
            string result = this.WriteXml(WeConst.WRITE_SETTINGS, WeConst.ROOT);
            return result;
        }

        public string ToJson()
        {
            string result = this.WriteJson(WeConst.WRITE_SETTINGS);
            return result;
        }
    }
}
