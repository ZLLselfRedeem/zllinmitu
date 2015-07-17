using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class VideoSendMessage : BaseSendMessage
    {
        public VideoSendMessage(string toUser, string mediaId, string title, string description)
            : base(toUser, MessageType.Video)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            Video = new VideoMediaType
            {
                MediaId = mediaId,
                Title = title,
                Description = description
            };
        }

        internal VideoSendMessage(ReceiveMessage message, string mediaId, string title, string description)
            : this(message.FromUserName, mediaId, title, description)
        {
        }

        [ObjectElement(Order = 50)]
        internal VideoMediaType Video { get; private set; }
    }
}
