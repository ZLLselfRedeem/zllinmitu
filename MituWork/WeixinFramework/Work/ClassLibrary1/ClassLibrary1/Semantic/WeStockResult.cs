using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeStockResult
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Cd { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Np { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Ap { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Apn { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string TpMax { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string TpMin { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Dn { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string De { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        public string Pe { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.Lower)]
        public string Sz { get; private set; }
    }
}
