using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class WePicUrl : WeixinResult
    {
        [TagElement(Order = 30, LocalName = "data")]
        [SimpleElement(NamingRule = NamingRule.UnderLineLower)]
        public string PicUrl { get; private set; }
    }
}
