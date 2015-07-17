using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class UserVoiceMassMessage : UserMassMessage
    {
        public UserVoiceMassMessage(string user, string mediaId)
            : this(EnumUtil.Convert(user), mediaId)
        {
        }

        public UserVoiceMassMessage(IEnumerable<string> users, string mediaId)
            : base(users)
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
