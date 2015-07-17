using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class ImageSendMessage : BaseSendMessage
    {
        public ImageSendMessage(string toUser, string mediaId)
            : base(toUser, MessageType.Image)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        internal ImageSendMessage(ReceiveMessage receive, string mediaId)
            : this(receive.FromUserName, mediaId)
        {
        }

        [TagElement(LocalName = "Image", Order = 50)]
        [SimpleElement(LocalName = "MediaId")]
        public string MediaId { get; private set; }
    }
}
