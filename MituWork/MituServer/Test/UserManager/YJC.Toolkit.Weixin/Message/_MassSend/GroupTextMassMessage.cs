using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class GroupTextMassMessage : GroupMassMessage
    {
        public GroupTextMassMessage(int groupId, string content)
            : base(groupId)
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
