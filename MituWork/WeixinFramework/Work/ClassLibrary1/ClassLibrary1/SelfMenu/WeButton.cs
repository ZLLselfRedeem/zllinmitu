using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeButton
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public ButtonType Type { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Url { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Value { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Key { get; protected set; }

        [TagElement(Order = 60, LocalName = "news_info")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<MenuMpNewsArticle> NewsList { get; protected set; }

        [TagElement(Order = 70, LocalName = "sub_button")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<WeButton> ButtonList { get; private set; }
    }
}
