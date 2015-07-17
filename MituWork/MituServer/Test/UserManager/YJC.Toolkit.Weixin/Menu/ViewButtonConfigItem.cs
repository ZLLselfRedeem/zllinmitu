using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class ViewButtonConfigItem : IConfigCreator<MenuButton>
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText Caption { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, LocalName = "Url", ObjectType = typeof(UrlConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, LocalName = "AuthUrl",
            ObjectType = typeof(AuthUrlConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, LocalName = "CorpAuthUrl",
            ObjectType = typeof(CorpAuthUrlConfigItem))]
        public UrlConfigItem Url { get; private set; }

        #region IConfigCreator<MenuButton> 成员

        public MenuButton CreateObject(params object[] args)
        {
            string url = Url.ToUri();

            return MenuButton.CreateViewMenu(Caption.ToString(), url);
        }

        #endregion
    }
}