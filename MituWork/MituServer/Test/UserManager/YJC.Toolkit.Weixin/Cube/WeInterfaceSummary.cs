using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeInterfaceSummary
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int CallbackCount { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int FailCount { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int TotalTimeCost { get; protected set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public int MaxTimeCost { get; protected set; }
    }
}
