using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class Attrex
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Camel, UseConstructor = true)]
        public Location Location { get; set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsPostFree { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsHasReceipt { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsUnderGuaranty { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsSupportReplace { get; set; }
    }
}
