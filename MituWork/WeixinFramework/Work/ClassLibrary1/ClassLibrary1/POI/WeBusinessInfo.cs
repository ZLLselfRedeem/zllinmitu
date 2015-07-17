using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeBusinessInfo
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public WePoiBaseInfo BaseInfo { get; private set; }
    }
}
