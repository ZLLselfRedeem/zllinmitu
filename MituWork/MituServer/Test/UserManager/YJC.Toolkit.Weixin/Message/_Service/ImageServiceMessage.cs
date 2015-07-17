using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class ImageServiceMessage : BaseServiceMessage
    {
        public ImageServiceMessage(string toUser, string mediaId)
            : base(toUser, MessageType.Image)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
        }

        [TagElement(LocalName = "image", Order = 50)]
        [SimpleElement(NamingRule = NamingRule.UnderLineLower)]
        public string MediaId { get; private set; }
    }
}
