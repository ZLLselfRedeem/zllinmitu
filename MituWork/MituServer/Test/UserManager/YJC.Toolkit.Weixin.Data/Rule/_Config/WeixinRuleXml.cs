using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    internal class WeixinRuleXml : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit)]
        [XmlPlugInItem]
        public RuleConfigItem Rule { get; private set; }
    }
}