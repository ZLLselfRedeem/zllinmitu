using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class SubSkuTable : WeCategoryProperty
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [NameModel(WeShopConst.LIST_NAME_MODEL, LocalName = "property_value")]
        public List<WeCategoryProperty> ValueList { get; private set; }
    }
}
