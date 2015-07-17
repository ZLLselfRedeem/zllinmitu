using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    internal class VideoServiceMediaType
    {
        [SimpleElement(LocalName = "media_id", Order = 10)]
        public string MediaId { get; set; }

        [SimpleElement(LocalName = "title", Order = 20)]
        public string Title { get; set; }

        [SimpleElement(LocalName = "description", Order = 30)]
        public string Description { get; set; }
    }
}
