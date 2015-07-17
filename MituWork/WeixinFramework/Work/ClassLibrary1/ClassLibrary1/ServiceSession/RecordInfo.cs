using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    public class RecordInfo
    {
        internal RecordInfo()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string OpenId { get; private set; }

        [SimpleElement(Order = 20, LocalName = "opercode")]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public SessionStatus OperatorCode { get; private set; }

        [SimpleElement(Order = 30, LocalName = "text")]
        public string RecordText { get; private set; }

        [SimpleElement(Order = 40, LocalName = "time")]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; private set; }

        [SimpleElement(Order = 50, LocalName = "worker")]
        public string Account { get; private set; }
    }
}
