using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class ButtonConfigItem : IConfigCreator<MenuButton>
    {
        private readonly List<IConfigCreator<MenuButton>> fButtons;

        public ButtonConfigItem()
        {
            fButtons = new List<IConfigCreator<MenuButton>>();
        }

        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText Caption { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "ScanCodePush", ObjectType = typeof(ScanCodePushConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "ScanCodeWaitmsg", ObjectType = typeof(ScanCodeWaitmsgConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "PicSysPhoto", ObjectType = typeof(PicSysPhotoConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "PicPhotoAlbum", ObjectType = typeof(PicPhotoAlbumConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "PicWeixin", ObjectType = typeof(PicWeixinConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "LocationSelect", ObjectType = typeof(LocationSelectConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "ClickButton", ObjectType = typeof(ClickButtonConfigItem))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "ViewButton", ObjectType = typeof(ViewButtonConfigItem))]
        public IEnumerable<IConfigCreator<MenuButton>> Buttons
        {
            get
            {
                return fButtons;
            }
        }

        #region IConfigCreator<MenuButton> 成员

        public MenuButton CreateObject(params object[] args)
        {
            MenuButton[] sub = new MenuButton[fButtons.Count];
            for (int i = 0; i < fButtons.Count; i++)
                sub[i] = fButtons[i].CreateObject();
            return MenuButton.CreateMenu(Caption.ToString(), sub);
        }

        #endregion
    }
}