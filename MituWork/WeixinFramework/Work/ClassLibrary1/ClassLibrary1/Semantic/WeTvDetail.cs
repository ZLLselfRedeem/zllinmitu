using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeTvDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeDateTime Datetime { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string TvName { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string TvChannel { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string ShowName { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }
    }
}
