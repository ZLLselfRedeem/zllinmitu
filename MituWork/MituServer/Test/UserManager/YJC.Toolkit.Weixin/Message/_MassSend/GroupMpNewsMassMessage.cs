using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class GroupMpNewsMassMessage : GroupMassMessage
    {
        public GroupMpNewsMassMessage(int groupId, string mediaId)
            : base(groupId)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
            MsgType = MessageType.MpNews;
        }

        [TagElement(LocalName = "mpnews", Order = 30)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }
    }
}
