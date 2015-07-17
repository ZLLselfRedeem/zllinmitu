using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    internal class MusicServiceMediaType
    {
        [SimpleElement(NamingRule = NamingRule.Lower, Order = 10)]
        public string Title { get; set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 20)]
        public string Description { get; set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 30)]
        public string MusicUrl { get; set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 40)]
        public string HQMusicUrl { get; set; }

        [SimpleElement(NamingRule = NamingRule.UnderLineLower, Order = 50)]
        public string ThumbMediaId { get; set; }
    }
}
