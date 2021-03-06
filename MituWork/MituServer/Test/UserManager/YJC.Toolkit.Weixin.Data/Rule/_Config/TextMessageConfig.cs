﻿using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2014-03-03", Description = "文本消息")]
    internal class TextMessageConfig : IRule, IConfigCreator<IRule>
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText Content { get; private set; }

        #region IReplyMessage 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            return new TextSendMessage(message, Content.ToString());
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