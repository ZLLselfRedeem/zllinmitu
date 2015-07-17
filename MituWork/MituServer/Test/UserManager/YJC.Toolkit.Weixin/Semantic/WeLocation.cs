using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeLocation
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public LocType Type { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Country { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Province { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string ProvinceSimple { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string City { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string CitySimple { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Town { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string TowmSimple { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        public string Poi { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string LocOri { get; private set; }
    }
}
