using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeMeetingTicketUpdate : WeCodeUnavailable
    {
        public WeMeetingTicketUpdate(string code, DateTime beg, DateTime end)
            : base(code)
        {
            BeginTime = beg;
            EndTime = end;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Zone { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Entrance { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string SeatNumber { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime BeginTime { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime EndTime { get; private set; }
    }
}
