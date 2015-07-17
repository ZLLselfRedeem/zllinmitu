using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyPermanentCodeResponse : WeThirdPartyCorpTokenResponse
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PermanentCode { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyAuthCorp AuthCorpInfo { get; private set; }

        [ObjectElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyAuth AuthInfo { get; private set; }
    }
}
