using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    class DefaultExtraConfigItem : IRegName
    {
        [SimpleAttribute]
        public int AppId { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public DefaultMessageConfigItem DefaultMessage { get; private set; }

        #region IRegName 成员

        public string RegName
        {
            get
            {
                return AppId.ToString();
            }
        }

        #endregion
    }
}
