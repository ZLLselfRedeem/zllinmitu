using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    class ShortUrlResult : WeixinResult
    {
        [SimpleElement(LocalName = "", Order = 30)]
        public string ShortUrl { get; private set; }
    }
}
