using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinXml : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public WeixinConfigItem Weixin { get; private set; }
    }
}