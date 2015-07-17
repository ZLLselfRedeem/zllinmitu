using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class SubElement : WeSubCateProperty
    {
        [ObjectElement(Order = 30, IsMultiple = true, NamingRule = NamingRule.UnderLineLower)]
        public List<WeSubCateProperty> PropertyValue { get; private set; }
    }
}
