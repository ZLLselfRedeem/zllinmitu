using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class VideoServiceMessage : BaseServiceMessage
    {
        public VideoServiceMessage(string toUser, string mediaId, string title, string description)
            : base(toUser, MessageType.Video)
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
    }
}
