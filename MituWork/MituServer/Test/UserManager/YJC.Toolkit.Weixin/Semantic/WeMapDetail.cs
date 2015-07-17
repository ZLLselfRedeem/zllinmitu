using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeMapDetail
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeLocation StartArea { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public WeLocation StartLoc { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public WeLocation EndArea { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public WeLocation EndLoc { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string RouteType { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public int? BusNum { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string SubwayNum { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public MapSort Type { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        public string Keyword { get; private set; }
    }
}
