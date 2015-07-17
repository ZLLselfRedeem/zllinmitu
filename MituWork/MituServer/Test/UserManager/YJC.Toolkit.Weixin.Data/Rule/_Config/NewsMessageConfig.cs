using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [ReplyMessageConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
       CreateDate = "2014-03-03", Description = "图文消息")]
    internal class NewsMessageConfig : IRule, IConfigCreator<IRule>
    {
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "Article")]
        public List<ArticleConfigItem> Articles { get; private set; }

        #region IReplyMessage 成员

        public BaseSendMessage Reply(ReceiveMessage message)
        {
            NewsSendMessage result = new NewsSendMessage(message);
            if (Articles != null)
                foreach (var item in Articles)
                    result.Add(item.CreateArticle());

            return result;
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