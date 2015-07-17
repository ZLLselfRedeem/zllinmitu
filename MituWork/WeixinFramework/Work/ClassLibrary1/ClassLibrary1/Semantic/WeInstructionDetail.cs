using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeInstructionDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int? Number { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Value { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Operator { get; private set; }
    }
}
