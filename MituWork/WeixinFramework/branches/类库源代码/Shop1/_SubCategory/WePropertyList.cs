using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WePropertyList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.Camel)]
        public List<SubElement> Properties { get; private set; }
    }
}
