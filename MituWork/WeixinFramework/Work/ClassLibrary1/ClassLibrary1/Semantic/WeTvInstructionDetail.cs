using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeTvInstructionDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string TvName { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string TvChannel { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public int? Number { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Value { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Operator { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Device { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string FileType { get; private set; }
    }
}
