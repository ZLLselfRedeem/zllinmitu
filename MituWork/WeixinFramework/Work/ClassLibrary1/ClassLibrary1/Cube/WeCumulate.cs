using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeCumulate
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int CumulateUser { get; private set; }
    }
}
