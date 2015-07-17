using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    internal class WeDataTimespan
    {
        internal WeDataTimespan(DateTime begTime, DateTime endTime)
        {
            BeginDate = begTime;
            EndDate = endTime;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateStringTypeConverter))]
        public DateTime BeginDate { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateStringTypeConverter))]
        public DateTime EndDate { get; private set; }
    }
}
