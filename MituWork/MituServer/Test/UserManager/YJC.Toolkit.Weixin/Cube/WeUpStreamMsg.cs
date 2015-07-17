using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeUpStreamMsg
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public DataMessage MsgType { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int MsgUser { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int MsgCount { get; protected set; }
    }
}
