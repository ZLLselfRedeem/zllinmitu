using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Data;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinExtraConfigItem
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public DefaultExtraConfigItem Normal { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "CorpApp")]
        public RegNameList<DefaultExtraConfigItem> CorpApps { get; private set; }

        [TagElement(NamespaceType.Toolkit)]
        [DynamicElement(MessageLogConfigFactory.REG_NAME)]
        public IConfigCreator<IMessageLog> MessageLog { get; private set; }
    }
}