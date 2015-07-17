using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    internal class ArticleConfigItem
    {
        [ObjectElement(NamespaceType.Toolkit, Order = 10)]
        public MultiLanguageText Title { get; set; }

        [ObjectElement(NamespaceType.Toolkit, Order = 20)]
        public MultiLanguageText Description { get; set; }

        [ObjectElement(NamespaceType.Toolkit, Order = 30)]
        internal UrlConfigItem PicUrl { get; set; }

        [ObjectElement(NamespaceType.Toolkit, Order = 40)]
        internal UrlConfigItem Url { get; set; }

        public Article CreateArticle()
        {
            return new Article
            {
                Title = Title.ToString(),
                Description = Description.ConvertToString(),
                PicUrl = UrlConfigItem.ToString(PicUrl),
                Url = UrlConfigItem.ToString(Url)
            };
        }
    }
}
