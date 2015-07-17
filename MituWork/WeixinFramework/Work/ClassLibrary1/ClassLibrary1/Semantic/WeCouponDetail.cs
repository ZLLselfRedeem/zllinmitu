using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeCouponDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeLocation Location { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.Lower)]
        public WeNumber Price { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower)]
        public WeNumber Radius { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Keyword { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CouponType Coupon { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CouponSort Sort { get; private set; }

    }
}
