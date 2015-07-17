using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    internal class MusicMessageConfigItem
    {

        [SimpleAttribute]
        public string Title { get; private set; }

        [SimpleAttribute]
        public string Description { get; private set; }

        [SimpleAttribute]
        public string MusicUrl { get; private set; }

        [SimpleAttribute]
        public string HQMusicUrl { get; private set; }

        [SimpleAttribute]
        public string ThumbMediaFileName { get; private set; }

        [SimpleAttribute]
        public FilePathPosition Position { get; private set; }
    }
}