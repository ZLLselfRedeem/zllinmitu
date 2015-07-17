using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeStockDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Code { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.Lower)]
        public WeDateTime Datetime { get; private set; }
    }
}
