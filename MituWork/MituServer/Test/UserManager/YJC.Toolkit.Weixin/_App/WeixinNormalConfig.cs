using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinNormalConfig : BaseItemConfig
    {
        [SimpleAttribute]
        public string OpenId { get; private set; }

        [SimpleAttribute]
        public MessageMode MessageMode { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public PaymentConfigItem Pay { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "TemplateMessage")]
        public RegNameList<TemplateMessageConfig> TemplateMessages { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public WeixinServiceConfigItem Service { get; private set; }
    }
}
