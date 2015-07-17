using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeShortUrlRequest : WePaymentBase
    {
        internal WeShortUrlRequest()
        {
        }

        public WeShortUrlRequest(string longUrl)
        {
            LongUrl = longUrl;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string LongUrl { get; protected set; }
    }
}
