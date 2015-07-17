using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    class ShortUrlInput
    {
        public ShortUrlInput()
        {
            Action = "long2short";
        }

        [SimpleElement(LocalName = "action", Order = 10)]
        public string Action { get; private set; }

        [SimpleElement(LocalName = "long_url", Order = 20)]
        public string LongUrl { get; set; }
    }
}
