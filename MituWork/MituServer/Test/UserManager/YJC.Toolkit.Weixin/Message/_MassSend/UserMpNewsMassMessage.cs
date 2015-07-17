using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class UserMpNewsMassMessage : UserMassMessage
    {
        public UserMpNewsMassMessage(string user, string mediaId)
            : this(EnumUtil.Convert(user), mediaId)
        {
        }

        public UserMpNewsMassMessage(IEnumerable<string> users, string mediaId)
            : base(users)
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
