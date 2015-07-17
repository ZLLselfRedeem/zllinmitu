using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal class WeThirdPartySuiteTokenRequest
    {
        public WeThirdPartySuiteTokenRequest()
        {
            SuiteId = "id_value";
            SuiteSecret = "secret_value";
        }

        public WeThirdPartySuiteTokenRequest(string suiteTicket)
            : this()
        {
            SuiteTicket = suiteTicket;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteSecret { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteTicket { get; private set; }
    }
}
