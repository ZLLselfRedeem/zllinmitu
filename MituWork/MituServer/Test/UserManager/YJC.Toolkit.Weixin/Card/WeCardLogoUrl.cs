using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardLogoUrl : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Url { get; private set; }
    }
}
