using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class MenuConfigItem
    {
        private readonly List<IConfigCreator<MenuButton>> fButtons;

        public MenuConfigItem()
        {
            fButtons = new List<IConfigCreator<MenuButton>>();
        }

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
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true,
            LocalName = "Button", ObjectType = typeof(ButtonConfigItem))]
        public List<IConfigCreator<MenuButton>> Buttons
        {
            get
            {
                return fButtons;
            }
        }
    }
}