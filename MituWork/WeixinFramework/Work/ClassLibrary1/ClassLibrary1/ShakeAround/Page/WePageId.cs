using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class WePageId : WeixinResult
    {
        [TagElement(Order = 30, LocalName = "data")]
        [SimpleElement(NamingRule = NamingRule.UnderLineLower)]
        public int PageId { get; private set; }
    }
}
