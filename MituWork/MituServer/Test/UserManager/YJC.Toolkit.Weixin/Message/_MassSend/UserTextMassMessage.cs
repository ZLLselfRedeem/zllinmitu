using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class UserTextMassMessage : UserMassMessage
    {
        public UserTextMassMessage(string user, string content)
            : this(EnumUtil.Convert(user), content)
        {
        }

        public UserTextMassMessage(IEnumerable<string> users, string content)
            : base(users)
        {
            TkDebug.AssertArgumentNullOrEmpty(content, "content", null);

            Content = content;
            MsgType = MessageType.Text;
        }

        [TagElement(LocalName = "text", Order = 30)]
        [SimpleElement(LocalName = "content")]
        public string Content { get; private set; }
    }
}
