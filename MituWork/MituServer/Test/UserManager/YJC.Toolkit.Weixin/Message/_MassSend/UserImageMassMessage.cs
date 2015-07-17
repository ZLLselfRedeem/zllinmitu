using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class UserImageMassMessage : UserMassMessage
    {
        public UserImageMassMessage(string user, string mediaId)
            : this(EnumUtil.Convert(user), mediaId)
        {
        }

        public UserImageMassMessage(IEnumerable<string> users, string mediaId)
            : base(users)
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
