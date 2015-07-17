using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class MenuMpNewsArticle
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Author { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Digest { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool ShowCover { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string CoverUrl { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string ContentUrl { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string SourceUrl { get; private set; }
    }
}
