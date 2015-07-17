using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeSelfButton
    {
        internal WeSelfButton()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public ButtonType Type { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Url { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Value { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Key { get; private set; }

        [TagElement(Order = 60, LocalName = "news_info")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<MenuMpNewsArticle> NewsArticles { get; private set; }

        [TagElement(Order = 60, LocalName = "sub_button")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<WeSelfButton> ButtonList { get; private set; }
    }
}
