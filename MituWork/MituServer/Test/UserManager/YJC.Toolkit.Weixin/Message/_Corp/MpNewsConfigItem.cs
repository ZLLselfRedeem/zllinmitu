using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    internal class MpNewsConfigItem
    {
        public MpNewsConfigItem()
        {
            Articles = new List<MpNewsArticle>();
        }

        [ObjectElement(NamingRule = NamingRule.Camel, IsMultiple = true, Order = 10)]
        public List<MpNewsArticle> Articles { get; private set; }
    }
}
