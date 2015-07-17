using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    public class WeMaterialPageData
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public int TotalCount { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int ItemCount { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.Lower,UseConstructor = true,
            ObjectType = typeof(WeMaterialItem), LocalName = "item")]
        public List<WeMediaId> Items { get; private set; }
    }
}
