using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpAppSimpleInfo : WeixinResult
    {
        internal CorpAppSimpleInfo()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int AgentId { get; protected set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Name { get; protected set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string SquareLogoUrl { get; protected set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string RoundLogoUrl { get; protected set; }

        public static List<CorpAppSimpleInfo> GetAppList()
        {
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.AGENT_LIST,
                WeixinSettings.Current.CorpUserManagerSecret);
            var list = WeUtil.GetFromUri(url, new CorpAppList());
            return list.AgentList;
        }
    }
}
