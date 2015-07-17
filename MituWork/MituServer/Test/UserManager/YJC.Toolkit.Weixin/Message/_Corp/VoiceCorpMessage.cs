using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class VoiceCorpMessage : BaseCorpMessage
    {
        public VoiceCorpMessage(string mediaId)
            : base(MessageType.Voice)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        [TagElement(LocalName = "voice", Order = 50)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }
    }
}
