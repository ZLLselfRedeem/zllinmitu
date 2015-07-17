using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeNearbyDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeLocation Location { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Keyword { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Limit { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.Lower)]
        public WeNumber Price { get; private set; }

        [ObjectElement(Order = 50, NamingRule = NamingRule.Lower)]
        public WeNumber Radius { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Service { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CouponType Coupon { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public RestaurantSort Sort { get; private set; }


    }
}
