using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeLocationInfo
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public int LocationId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string BusinessName { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Phone { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Address { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public double Longitude { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public double Latitude { get; private set; }
    }
}
