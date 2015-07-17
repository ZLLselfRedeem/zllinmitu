using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class MpNewsMassMessage
    {
        public MpNewsMassMessage()
        {
            Articles = new List<MpNewsArticle>();
        }

        [ObjectElement(NamingRule = NamingRule.Camel, IsMultiple = true, Order = 10)]
        internal List<MpNewsArticle> Articles { get; private set; }

        public void AddArticle(MpNewsArticle article)
        {
            TkDebug.AssertArgumentNull(article, "article", this);

            Articles.Add(article);
        }

        public MediaId UploadMessage()
        {
            string url = WeUtil.GetUrl(WeConst.NEWS_MASS_URL);
            var mediaId = WeUtil.PostToUri(url, this.WriteJson(), new MediaId());
            return mediaId;
        }

        public long Send(int groupId)
        {
            MediaId mediaId = UploadMessage();
            var msg = new GroupMpNewsMassMessage(groupId, mediaId.Id);
            return msg.Send();
        }

        public long Send(IEnumerable<string> users)
        {
            MediaId mediaId = UploadMessage();
            var msg = new UserMpNewsMassMessage(users, mediaId.Id);
            return msg.Send();
        }
    }
}
