using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Material
{
    internal class WeMaterialItem : WeMediaId
    {
        [TagElement(Order = 40, LocalName = "content")]
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.UnderLineLower,
            UseConstructor = true)]
        public List<MpNewsArticle> NewsItem { get; private set; }

        public override WeNewsMaterial CreateNewsMaterial()
        {
            WeNewsMaterial weNews = new WeNewsMaterial(NewsItem);
            return weNews;
        }

    }
}
