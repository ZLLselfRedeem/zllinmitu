using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeNumber
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Type { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Begin { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string End { get; private set; }
    }
}
