using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpAgentBrief
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int AgentId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string SquareLogoUrl { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string RoundLogoUrl { get; private set; }
    }
}
