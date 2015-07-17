using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeArticleTotal
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public DateTime RefDate { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Msgid { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 40, NamingRule = NamingRule.Lower)]
        public List<WeArticleDetails> Details { get; private set; }
    }
}
