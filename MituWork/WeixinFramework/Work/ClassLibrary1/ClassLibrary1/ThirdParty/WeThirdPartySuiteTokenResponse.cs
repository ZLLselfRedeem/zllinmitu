using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal class WeThirdPartySuiteTokenResponse
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteAccessToken { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int ExpiresIn { get; private set; }
    }
}
