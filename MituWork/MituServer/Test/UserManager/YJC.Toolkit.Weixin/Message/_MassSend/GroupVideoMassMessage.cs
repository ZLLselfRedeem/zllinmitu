using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class GroupVideoMassMessage : GroupMassMessage
    {
        public GroupVideoMassMessage(int groupId, string title,
            string description, string mediaId)
            : base(groupId)
        {
            TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", null);

            MediaId = new VideoServiceMediaType
            {
                MediaId = mediaId,
                Title = title,
                Description = description
            };
            MsgType = MessageType.MpVideo;
        }

        [ObjectElement(LocalName = "mpvideo", Order = 30)]
        internal VideoServiceMediaType MediaId { get; private set; }
    }
}
