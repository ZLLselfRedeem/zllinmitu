using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeMembercardUpdateResponse : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int ResultBonus { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int ResultBalance { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string OpenId { get; private set; }
    }
}
