using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class VoiceSendMessage : BaseSendMessage
    {
        public VoiceSendMessage(string toUser, string mediaId)
            : base(toUser, MessageType.Voice)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        internal VoiceSendMessage(ReceiveMessage receive, string mediaId)
            : this(receive.FromUserName, mediaId)
        {
        }

        [TagElement(LocalName = "Voice", Order = 50)]
        [SimpleElement(LocalName = "MediaId")]
        public string MediaId { get; private set; }
    }
}
