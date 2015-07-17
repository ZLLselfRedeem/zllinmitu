using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class MpNewsCorpMessage : BaseCorpMessage
    {
        public MpNewsCorpMessage()
            : base(MessageType.MpNews)
        {
            MpNews = new MpNewsConfigItem();
        }

        [ObjectElement(LocalName = "mpnews", Order = 50)]
        internal MpNewsConfigItem MpNews { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 100)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Safe { get; set; }

        //public void SetMediaId(string mediaId)
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(mediaId, "mediaId", this);

        //    MpNews.MediaId = mediaId;
        //}

        public void Add(MpNewsArticle article)
        {
            TkDebug.AssertArgumentNull(article, "article", this);

            MpNews.Articles.Add(article);
        }
    }
}
