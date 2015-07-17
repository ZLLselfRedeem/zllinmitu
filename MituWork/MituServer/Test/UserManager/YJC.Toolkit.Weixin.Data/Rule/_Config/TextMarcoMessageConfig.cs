using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2014-03-18", Description = "文本消息，支持宏，可以使用{OpenId}")]
    internal class TextMarcoMessageConfig : IRule, IConfigCreator<IRule>
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public MarcoConfigItem Content { get; private set; }

        #region IReplyMessage 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            string content = Expression.Execute(Content, message);
            return new TextSendMessage(message, content);
        }

        #endregion

        #region IConfigCreator<IReplyMessage> 成员

        public IRule CreateObject(params object[] args)
        {
            return this;
        }

        #endregion
    }
}