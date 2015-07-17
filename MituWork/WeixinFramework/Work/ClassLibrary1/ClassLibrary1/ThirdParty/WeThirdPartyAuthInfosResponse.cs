using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyAuthInfosResponse
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyAuthCorp AuthCorpInfo { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyAuth AuthInfo { get; private set; }
    }
}
