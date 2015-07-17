using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinServiceConfigItem
    {
        [SimpleAttribute(DefaultValue = true)]
        public bool Enabled { get; private set; }

        [SimpleAttribute]
        public string WeixinAccount { get; private set; }
    }
}
