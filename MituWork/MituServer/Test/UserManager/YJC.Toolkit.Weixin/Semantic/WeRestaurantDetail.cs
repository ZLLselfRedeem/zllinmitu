using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeRestaurantDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeLocation Location { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Category { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Special { get; private set; }

        [ObjectElement(Order = 50, NamingRule = NamingRule.Lower)]
        public WeNumber Price { get; private set; }

        [ObjectElement(Order = 60, NamingRule = NamingRule.Lower)]
        public WeNumber Radius { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CouponType Coupon { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public RestaurantSort Sort { get; private set; }
    }
}
