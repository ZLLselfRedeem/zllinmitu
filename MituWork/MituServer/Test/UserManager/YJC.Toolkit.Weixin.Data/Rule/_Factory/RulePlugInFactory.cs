using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    [XmlBaseClass(RuleConfigItem.BASE_CLASS, typeof(XmlConfigRule))]
    [XmlPlugIn(PATH, typeof(WeixinRuleXml), SearchPattern = "*Rule.xml")]
    public class RulePlugInFactory : BaseXmlPlugInFactory
    {
        public const string REG_NAME = "_tk_Weixin_Rule";
        public const string PATH = "Weixin";
        private const string DESCRIPTION = "微信回复规则的插件工厂";

        public RulePlugInFactory()
            : base(REG_NAME, DESCRIPTION)
        {
        }
    }
}
