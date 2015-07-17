using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class GroupVoiceMassMessage : GroupMassMessage
    {
        public GroupVoiceMassMessage(int groupId, string mediaId)
            : base(groupId)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = mediaId;
            MsgType = MessageType.Voice;
        }

        [TagElement(LocalName = "voice", Order = 30)]
        [SimpleElement(LocalName = "media_id")]
        public string MediaId { get; private set; }
    }
}
