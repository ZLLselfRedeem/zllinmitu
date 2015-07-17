using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeLocationId : WeixinResult
    {
        [SimpleElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public List<int> LocationIdList { get; private set; }
    }
}
