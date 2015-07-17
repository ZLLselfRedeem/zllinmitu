using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class SubSkuTable : WeSubCateProperty
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [NameModel(WeShopConst.LIST_NAME_MODEL, LocalName = "property_value")]
        public List<WeSubCateProperty> ValueList { get; private set; }
    }
}
