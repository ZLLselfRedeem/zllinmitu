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
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.UnderLineLower)]
        public List<MenuButton> Button { get; private set; }

        public static WeSelfMenu GetMenuInfo()
        {
            string url = WeUtil.GetUrl("https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}");
            WeSelfMenu result = NetUtil.HttpGetReadJson(new Uri(url), new WeSelfMenu());
            return result;
        }
    }
}
