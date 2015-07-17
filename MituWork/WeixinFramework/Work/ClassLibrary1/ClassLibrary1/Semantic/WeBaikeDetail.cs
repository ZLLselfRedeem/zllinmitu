using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeBaikeDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Keyword { get; private set; }
    }
}
