using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class ImageCorpMessage : BaseCorpMessage
    {
        public ImageCorpMessage(string mediaId)
            : base(MessageType.Image)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        [TagElement(LocalName = "image", Order = 50)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 100)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Safe { get; set; }
    }
}
