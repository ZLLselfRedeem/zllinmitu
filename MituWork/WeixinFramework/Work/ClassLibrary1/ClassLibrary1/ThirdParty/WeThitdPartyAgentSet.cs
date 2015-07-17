using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThitdPartyAgentSet
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string AuthCorpid { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PermanentCode { get; private set; }
    }
}
