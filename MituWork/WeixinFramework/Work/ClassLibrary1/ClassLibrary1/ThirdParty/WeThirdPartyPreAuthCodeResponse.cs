using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal class WeThirdPartyPreAuthCodeResponse : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PreAuthCode { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int ExpiresIn { get; private set; }
    }
}
