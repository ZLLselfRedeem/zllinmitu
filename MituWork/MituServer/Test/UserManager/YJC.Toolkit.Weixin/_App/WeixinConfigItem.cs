using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinConfigItem
    {
        [SimpleAttribute]
        public string AppId { get; private set; }

        [SimpleAttribute]
        public bool LogRawMessage { get; private set; }

        [SimpleAttribute]
        public bool UseLogOnRight { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public WeixinNormalConfig Normal { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public CorpSecretConfig CorpSecret { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "CorpApp")]
        public RegNameList<WeixinCorpConfig> CorpApps { get; private set; }

        //[ObjectElement(NamespaceType.Toolkit)]
        //public DefaultMessageConfigItem DefaultMessage { get; private set; }
    }
}