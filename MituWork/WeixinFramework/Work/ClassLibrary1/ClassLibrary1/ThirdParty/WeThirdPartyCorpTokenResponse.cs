using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyCorpTokenResponse
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string AccessToken { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int ExpiresIn { get; protected set; }
    }
}
