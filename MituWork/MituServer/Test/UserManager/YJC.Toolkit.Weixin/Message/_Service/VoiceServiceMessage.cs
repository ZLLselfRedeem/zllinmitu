using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class VoiceServiceMessage : BaseServiceMessage
    {
        public VoiceServiceMessage(string toUser, string mediaId)
            : base(toUser, MessageType.Voice)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        [TagElement(LocalName = "voice", Order = 50)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }
    }
}
