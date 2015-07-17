using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeSubCategoryList : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public List<WeCategoryProperty> CateList { get; private set; }
    }
}
