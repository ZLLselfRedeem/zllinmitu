using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeSelfMenu
    {
        private WeSelfMenu()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsMenuOpen { get; private set; }

        [TagElement(Order = 20, LocalName = "selfmenu_info")]
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public List<WeSelfButton> Button { get; private set; }

        public static WeSelfMenu GetMenuInfo()
        {
            string url = WeUtil.GetUrl(WeConst.SELF_MENU);
            WeSelfMenu result = NetUtil.HttpGetReadJson(new Uri(url), new WeSelfMenu());
            return result;
        }
    }
}
