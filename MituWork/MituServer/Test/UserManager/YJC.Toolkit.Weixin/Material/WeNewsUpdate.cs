using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Material
{
    internal class WeNewsUpdate
    {
        internal WeNewsUpdate(WeMediaId mediaId, int index, MpNewsArticle articles)
        {
            MediaId = mediaId.MediaId;
            Index = index;
            Articles = articles;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string MediaId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public int Index { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower)]
        public MpNewsArticle Articles { get; private set; }
    }
}
