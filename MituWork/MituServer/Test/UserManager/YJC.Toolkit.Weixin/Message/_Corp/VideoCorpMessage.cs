using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class VideoCorpMessage : BaseCorpMessage
    {
        public VideoCorpMessage(string mediaId, string title, string description)
            : base(MessageType.Video)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            Video = new VideoServiceMediaType
            {
                MediaId = mediaId,
                Title = title,
                Description = description
            };
        }

        [ObjectElement(NamingRule = NamingRule.Camel, Order = 50)]
        internal VideoServiceMediaType Video { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 100)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Safe { get; set; }
    }
}
