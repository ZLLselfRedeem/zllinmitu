using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class SkuListElement
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SkuId { get; set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        public int Price { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string IconUrl { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string ProductCode { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int OriPrice { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Camel)]
        public int Quantity { get; set; }
    }
}
