using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeBillStatus
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeBillStatusType Status { get; set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime BeginTime { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", Status, BeginTime);
        }
    }
}
