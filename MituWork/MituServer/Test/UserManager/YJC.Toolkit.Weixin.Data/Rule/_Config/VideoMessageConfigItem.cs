using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    internal class VideoMessageConfigItem
    {

        [SimpleAttribute]
        public string Title { get; private set; }

        [SimpleAttribute]
        public string Description { get; private set; }

        [SimpleAttribute]
        public string FileName { get; private set; }

        [SimpleAttribute]
        public FilePathPosition Position { get; private set; }
    }
}