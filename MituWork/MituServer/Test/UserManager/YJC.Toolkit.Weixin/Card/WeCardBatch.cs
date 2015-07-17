using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCardBatch : WeixinResult
    {
        [SimpleElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public List<string> CardIdList { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int TotalNum { get; private set; }
    }
}
