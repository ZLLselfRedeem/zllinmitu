using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeUserShare
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public SceneType ShareScene { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int ShareCount { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int ShareUser { get; protected set; }
    }
}
