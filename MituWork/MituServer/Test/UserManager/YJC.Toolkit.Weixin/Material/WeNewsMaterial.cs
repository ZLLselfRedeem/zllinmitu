using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Material
{
    public class WeNewsMaterial : WeBaseMaterial
    {
        internal WeNewsMaterial()
        {
            Articles = new List<MpNewsArticle>();
        }

        internal WeNewsMaterial(List<MpNewsArticle> articles)
            : this(articles.ToArray())
        {
        }

        public WeNewsMaterial(params MpNewsArticle[] articles)
        {
            TkDebug.AssertArgumentNull(articles, "articles", null);

            Articles = new List<MpNewsArticle>(articles);
        }

        public void AddArticle(MpNewsArticle article)
        {
            TkDebug.AssertArgumentNull(article, "article", null);

            Articles.Add(article);
        }

        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        [NameModel(WeMaterialConst.NAME_MODEL, LocalName = "news_item")]
        public List<MpNewsArticle> Articles { get; protected set; }

        public override WeMediaId Add()
        {
            string url = WeUtil.GetUrl(WeMaterialConst.ADD_NEWS);
            var result = WeUtil.PostDataToUri(url, this.WriteJson(), new WeMediaId());
            return result;
        }

        public WeixinResult Update(WeMediaId mediaId, int index)
        {
            TkDebug.AssertArgumentNull(mediaId, "mediaId", null);

            string url = WeUtil.GetUrl(WeMaterialConst.UPDATE_NEWS);
            WeNewsUpdate request = new WeNewsUpdate(mediaId, index, this.Articles[0]);
            string res = request.WriteJson();

            var result = WeUtil.PostDataToUri(url, res, new WeixinResult());
            return result;
        }

        public static WeMaterialPageData GetMaterials(int pageSize, int pageCount)
        {
            return WeBaseMaterial.GetPageData(MediaType.News, pageSize, pageCount);
        }

        public static int TotalCount
        {
            get
            {
                return WeBaseMaterial.Count().NewsCount;
            }
        }
    }
}
