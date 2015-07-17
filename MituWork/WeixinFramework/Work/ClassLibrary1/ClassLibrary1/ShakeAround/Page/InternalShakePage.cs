using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class InternalShakePage
    {
        public InternalShakePage(string title, string description, string pageUrl, string iconUrl)
        {
            Title = title;
            Description = description;
            PageUrl = pageUrl;
            IconUrl = iconUrl;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Title { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PageUrl { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Comment { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string IconUrl { get; private set; }

        public int Add()
        {
            string url = WeUtil.GetUrl(WeShakeConst.PAGE_ADD);
            string strJson = this.WriteJson();
            var result = WeUtil.PostDataToUri(url, strJson , new WePageId());
            return result.PageId;
        }
    }
}
