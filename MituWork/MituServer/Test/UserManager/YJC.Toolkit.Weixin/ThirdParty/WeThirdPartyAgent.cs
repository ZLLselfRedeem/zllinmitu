using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyAgent
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Agentid { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string SquareLogoUrl { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string RoundLogoUrl { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Appid { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public List<string> ApiGroup { get; private set; }
    }
}
