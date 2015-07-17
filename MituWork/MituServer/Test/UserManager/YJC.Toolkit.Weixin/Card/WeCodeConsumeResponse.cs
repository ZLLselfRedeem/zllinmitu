using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCodeConsumeResponse : WeixinResult
    {
        [TagElement(Order = 30, LocalName = "card")]
        [SimpleElement(NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; private set; }

        [SimpleElement(Order = 40, LocalName = "openid")]
        public string OpenId { get; private set; }
    }
}
