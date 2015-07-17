using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class NewsSendMessage : BaseSendMessage
    {
        private readonly List<Article> fList;

        public NewsSendMessage(string toUser)
            : base(toUser, MessageType.News)
        {
            fList = new List<Article>();
        }

        internal NewsSendMessage(ReceiveMessage message)
            : this(message.FromUserName)
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value")]
        [SimpleElement(Order = 50)]
        public int ArticleCount
        {
            get
            {
                return fList.Count;
            }
            private set
            {
            }
        }

        [TagElement(Order = 60)]
        [ObjectElement(IsMultiple = true, LocalName = "item")]
        public IEnumerable<Article> Articles
        {
            get
            {
                return fList;
            }
        }

        public void Add(Article article)
        {
            fList.Add(article);
        }
    }
}
