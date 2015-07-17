using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeDateTime
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public TimeType Type { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Date { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string DateOri { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Time { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string TimeOri { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string EndDate { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string EndDateOri { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string EndTime { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string EndTimeOri { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.Lower)]
        public string Repeat { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string RepeatOri { get; private set; }
    }
}
