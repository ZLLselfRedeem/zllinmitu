using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class TextSendMessage : BaseSendMessage
    {
        public TextSendMessage(string toUser, string content)
            : base(toUser, MessageType.Text)
        {
            TkDebug.AssertArgumentNull(content, "content", null);

            Content = content;
        }

        internal TextSendMessage(ReceiveMessage receive, string content)
            : this(receive.FromUserName, content)
        {
        }

        [SimpleElement(Order = 50, UseCData = true)]
        public string Content { get; private set; }
    }
}
