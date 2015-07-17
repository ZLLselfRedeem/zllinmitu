using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeUserRead : WeNewsBase
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; protected set; }
    }
}
