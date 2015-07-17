using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeWebSubButton : WeBaseButton
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Value { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public WebButtonType Type { get; protected set; }

        [TagElement(Order = 50, LocalName = "news_info")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<MpNewsArticle> NewsList { get; protected set; }
    }
}
