using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeDateInfo
    {
        public WeDateInfo()
        {
        }

        public WeDateInfo(DateTime beg, DateTime end)
        {
            Type = CardDateType.DateInterval;
            BeginTimestamp = beg;
            EndTimestamp = end;
        }

        public WeDateInfo(int term, int begTerm)
        {
            Type = CardDateType.DaySpan;
            FixedTerm = term;
            FixedBeginTerm = begTerm;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CardDateType Type { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime BeginTimestamp { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime EndTimestamp { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int FixedTerm { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int FixedBeginTerm { get; private set; }
    }
}
