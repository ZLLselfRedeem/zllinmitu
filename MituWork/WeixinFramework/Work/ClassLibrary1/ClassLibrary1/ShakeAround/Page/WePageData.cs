using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class WePageData : WeixinResult
    {
        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower)]
        public WeTargetPageList Data { get; private set; }
    }
}
