using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.MenuCreator
{
    internal class HostConfigItem
    {
        [SimpleAttribute]
        public string Key { get; private set; }

        [SimpleAttribute]
        public string Value { get; private set; }
    }
}
