using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeBoardingPass
    {
        internal WeBoardingPass()
        {
        }

        public WeBoardingPass(WeCardBaseInfo baseInfo, string from, string to, string flight)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(from, "from", null);
            TkDebug.AssertArgumentNullOrEmpty(to, "to", null);
            TkDebug.AssertArgumentNullOrEmpty(flight, "flight", null);

            BaseInfo = baseInfo;
            From = from;
            To = to;
            Flight = flight;
        }

        public WeBoardingPass(WeCardBaseInfo baseInfo)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInfo = baseInfo;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string From { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string To { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Flight { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime DepartureTime { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime LandingTime { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string CheckInUrl { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        public string Gate { get; set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime BoardingTime { get; set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string AirModel { get; set; }
    }
}
