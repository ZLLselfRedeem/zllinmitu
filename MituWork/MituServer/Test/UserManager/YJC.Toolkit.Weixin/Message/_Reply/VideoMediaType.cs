using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    internal class VideoMediaType
    {
        [SimpleElement(Order = 10)]
        public string MediaId { get; set; }

        [SimpleElement(Order = 20)]
        public string Title { get; set; }

        [SimpleElement(Order = 30)]
        public string Description { get; set; }
    }
}
