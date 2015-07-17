using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeNewsDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Keyword { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }
    }
}
