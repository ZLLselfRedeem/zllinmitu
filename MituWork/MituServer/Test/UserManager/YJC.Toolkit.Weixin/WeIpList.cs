using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeIpList : WeixinResult
    {
        [SimpleElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public List<string> IpList { get; private set; }
    }
}
