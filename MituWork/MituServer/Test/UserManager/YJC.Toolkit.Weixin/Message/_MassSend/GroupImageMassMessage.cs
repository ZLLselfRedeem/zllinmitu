using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class GroupImageMassMessage : GroupMassMessage
    {
        public GroupImageMassMessage(int groupId, string mediaId)
            : base(groupId)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
            MsgType = MessageType.Image;
        }

        [TagElement(LocalName = "image", Order = 30)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }
    }
}
