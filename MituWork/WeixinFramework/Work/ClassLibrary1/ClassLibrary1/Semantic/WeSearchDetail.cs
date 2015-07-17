using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeSearchDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Keyword { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Channel { get; private set; }
    }
}
