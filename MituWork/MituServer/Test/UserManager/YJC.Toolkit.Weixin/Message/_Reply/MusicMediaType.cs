using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    internal class MusicMediaType
    {
        [SimpleElement(Order = 10)]
        public string Title { get; set; }

        [SimpleElement(Order = 20)]
        public string Description { get; set; }

        [SimpleElement(Order = 30)]
        public string MusicUrl { get; set; }

        [SimpleElement(Order = 40)]
        public string HQMusicUrl { get; set; }

        [SimpleElement(Order = 50)]
        public string ThumbMediaId { get; set; }
    }
}
