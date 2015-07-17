using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeShortUrlResponse : BasePayResponse
    {
        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string ShortUrl { get; private set; }
    }
}
