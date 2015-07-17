using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeUpStreamMsgDist
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public CountIntervalLevel CountInterval { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int MsgUser { get; private set; }
    }
}
