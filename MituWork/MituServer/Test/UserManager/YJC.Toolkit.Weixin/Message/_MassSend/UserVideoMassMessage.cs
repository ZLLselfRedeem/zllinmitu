using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class UserVideoMassMessage : UserMassMessage
    {
        public UserVideoMassMessage(string user, string title,
            string description, string mediaId)
            : this(EnumUtil.Convert(user), title, description, mediaId)
        {
        }

        public UserVideoMassMessage(IEnumerable<string> users, string title,
            string description, string mediaId)
            : base(users)
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
