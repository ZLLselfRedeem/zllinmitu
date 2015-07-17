using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeSlefMenu<T> where T : WeBaseButton, new()
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsMenuOpen { get; private set; }

        [TagElement(Order = 20, LocalName = "selfmenu_info")]
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Lower)]
        public List<T> Button { get; private set; }

        public static WeSlefMenu<T> GetMenuInfo<T>(WeSlefMenu<T> result) where T : WeBaseButton, new()
        {
            string url = WeUtil.GetUrl("https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}");
            result = NetUtil.HttpGetReadJson(new Uri(url), result);
            return result;
        }
    }
}
