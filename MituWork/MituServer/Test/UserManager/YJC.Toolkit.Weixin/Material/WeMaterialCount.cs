using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Material
{
    internal class WeMaterialCount : WeixinResult
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public int VoiceCount { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int VideoCount { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int ImageCount { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int NewsCount { get; private set; }
    }
}
