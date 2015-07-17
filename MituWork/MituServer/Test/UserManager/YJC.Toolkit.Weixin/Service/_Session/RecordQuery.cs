using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class RecordQuery
    {
        internal RecordQuery(DateTime start, DateTime end, int index, int size)
        {
            StartTime = start;
            EndTime = end;
            PageIndex = index;
            PageSize = size;
        }

        [SimpleElement(Order = 5, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime StartTime { get; private set; }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime EndTime { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string OpenId { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int PageIndex { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public int PageSize { get; private set; }
    }
}
