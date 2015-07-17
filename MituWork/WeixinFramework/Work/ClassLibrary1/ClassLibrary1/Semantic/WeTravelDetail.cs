using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeTravelDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public WeLocation Location { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Spot { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower)]
        public WeDateTime Datatime { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Tag { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public TravelCategory Category { get; private set; }
    }
}
