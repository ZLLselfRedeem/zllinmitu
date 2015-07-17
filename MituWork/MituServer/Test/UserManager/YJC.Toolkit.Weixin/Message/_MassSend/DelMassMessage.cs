using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    class DelMassMessage
    {
        [SimpleElement(LocalName = "msg_id")]
        public long MsgId { get; protected set; }
    }
}
