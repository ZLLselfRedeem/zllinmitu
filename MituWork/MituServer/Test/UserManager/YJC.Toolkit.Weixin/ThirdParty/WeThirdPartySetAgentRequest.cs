using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal class WeThirdPartySetAgentRequest
    {
        public WeThirdPartySetAgentRequest()
        {
            SuiteId = "id_value";
        }

        public WeThirdPartySetAgentRequest(string authCorpid, string permanetCode,
            WeThirdPartyAgentSet agent)
            : this()
        {
            AuthCorpid = authCorpid;
            PermanentCode = permanetCode;
            Agent = agent;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string AuthCorpid { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PermanentCode { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.Lower)]
        public WeThirdPartyAgentSet Agent { get; private set; }
    }
}
