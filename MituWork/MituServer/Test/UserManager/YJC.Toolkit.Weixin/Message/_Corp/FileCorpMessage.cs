using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class FileCorpMessage : BaseCorpMessage
    {
        public FileCorpMessage(string mediaId)
            : base(MessageType.File)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        [TagElement(LocalName = "file", Order = 50)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 100)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Safe { get; set; }
    }
}
