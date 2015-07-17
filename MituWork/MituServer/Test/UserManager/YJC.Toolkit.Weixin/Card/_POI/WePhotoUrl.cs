using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WePhotoUrl
    {
        internal WePhotoUrl()
        {
        }

        public WePhotoUrl(string phUrl)
        {
            PhotoUrl = phUrl;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string PhotoUrl { get; private set; }
    }
}
