using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeShortUrlRequest : BasePayRequest
    {
        public WeShortUrlRequest(string longUrl)
        {
            TkDebug.AssertArgumentNullOrEmpty(longUrl, "longUrl", null);

            LongUrl = longUrl;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string LongUrl { get; protected set; }
    }
}
