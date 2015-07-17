using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class TextCorpMessage : BaseCorpMessage
    {
        public TextCorpMessage(string content)
            : base(MessageType.Text)
        {
            TkDebug.AssertArgumentNullOrEmpty(content, "content", null);

            Content = content;
        }

        [TagElement(LocalName = "text", Order = 40)]
        [SimpleElement(LocalName = "content")]
        public string Content { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 100)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Safe { get; set; }
    }
}
