using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    abstract class KeyButtonConfigItem : IConfigCreator<MenuButton>
    {
        private readonly ButtonType fButtonType;

        protected KeyButtonConfigItem(ButtonType buttonType)
        {
            fButtonType = buttonType;
        }

        #region IConfigCreator<MenuButton> 成员

        public MenuButton CreateObject(params object[] args)
        {
            return MenuButton.CreateKeyMenu(fButtonType, Caption.ToString(), Key);
        }

        #endregion

        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText Caption { get; protected set; }

        [SimpleElement(NamespaceType.Toolkit)]
        public string Key { get; protected set; }
    }
}
