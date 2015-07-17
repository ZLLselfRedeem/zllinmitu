using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WePoiInfoList : WeixinResult
    {
        [ObjectElement(Order = 30, IsMultiple = true, NamingRule = NamingRule.UnderLineLower)]
        public List<WeBusinessInfo> BusinessList { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int TotalCount { get; private set; }
    }
}
