using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeLocationBatch : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public List<WeLocationInfo> LocationList { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public int Count { get; private set; }
    }
}
