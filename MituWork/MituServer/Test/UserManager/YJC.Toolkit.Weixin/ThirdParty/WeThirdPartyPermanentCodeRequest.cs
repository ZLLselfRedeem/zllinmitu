using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal class WeThirdPartyPermanentCodeRequest
    {
        public WeThirdPartyPermanentCodeRequest()
        {
            SuiteId = "id_value";
        }

        public WeThirdPartyPermanentCodeRequest(string authCode)
            : this()
        {
            AuthCode = authCode;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string AuthCode { get; private set; }
    }
}
