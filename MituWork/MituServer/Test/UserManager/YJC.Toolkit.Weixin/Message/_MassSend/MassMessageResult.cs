using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    internal class MassMessageResult : WeixinResult
    {
        internal MassMessageResult()
        {
        }

        internal MassMessageResult(long msgId)
        {
            MsgId = msgId;
        }

        [SimpleElement(LocalName = "msg_id", Order = 30)]
        public long MsgId { get; private set; }

        public long ResultId
        {
            get
            {
                if (IsError)
                    return -1L;
                return MsgId;
            }
        }
    }
}
