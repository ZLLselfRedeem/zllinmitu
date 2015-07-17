using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinExtraXml : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public WeixinExtraConfigItem Weixin { get; private set; }
    }
}