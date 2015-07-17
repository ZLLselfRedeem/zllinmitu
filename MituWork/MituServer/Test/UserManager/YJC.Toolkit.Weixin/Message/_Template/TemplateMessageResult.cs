using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    class TemplateMessageResult : WeixinResult
    {
        [SimpleElement(LocalName = "msgid", Order = 30)]
        public long MsgId { get; private set; }
    }
}
