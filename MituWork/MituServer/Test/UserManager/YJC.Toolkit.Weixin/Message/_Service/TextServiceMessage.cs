using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class TextServiceMessage : BaseServiceMessage
    {
        public TextServiceMessage(string toUser, string content)
            : base(toUser, MessageType.Text)
        {
            TkDebug.AssertArgumentNullOrEmpty(content, "content", null);

            Content = content;
        }

        [TagElement(LocalName = "text", Order = 30)]
        [SimpleElement(LocalName = "content")]
        public string Content { get; private set; }
    }
}
