using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Menu;

namespace YJC.Toolkit.Weixin.Message
{
    public class NewsReplyInfo : SimpleReplyInfo
    {
        internal NewsReplyInfo()
        {
        }

        [TagElement(Order = 15, LocalName = "news_info")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<MenuMpNewsArticle> NewsList { get; private set; }
    }
}
