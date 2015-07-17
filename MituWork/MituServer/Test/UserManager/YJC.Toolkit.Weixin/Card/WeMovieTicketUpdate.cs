using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeMovieTicketUpdate : WeCodeUnavailable
    {
        public WeMovieTicketUpdate(string code, string ticketClass, DateTime showTime, int duration,
            string screeningRoom, params string[] seatNumber)
            : base(code)
        {
            TicketClass = ticketClass;
            ShowTime = showTime;
            Duration = duration;
            ScreeningRoom = screeningRoom;
            SeatNumber = new List<string>(seatNumber);
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string TicketClass { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime ShowTime { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public int Duration { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string ScreeningRoom { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public List<string> SeatNumber { get; private set; }
    }
}
