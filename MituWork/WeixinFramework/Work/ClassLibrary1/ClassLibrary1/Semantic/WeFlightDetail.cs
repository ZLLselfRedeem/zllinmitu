using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeFlightDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string FlightNo { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public WeLocation StartLoc { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public WeLocation EndLoc { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public WeDateTime StartDate { get; private set; }

        [ObjectElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public WeDateTime EndDate { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Airline { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Seat { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public FlightSort Sort { get; private set; }
    }
}
