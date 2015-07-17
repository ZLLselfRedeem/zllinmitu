using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public sealed class MenuButton
    {
        internal MenuButton()
        {
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public ButtonType Type { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        public string Name { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 30)]
        public string Url { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 42)]
        public string Key { get; private set; }

        [ObjectElement(IsMultiple = true, LocalName = "sub_button", Order = 50, UseConstructor = true)]
        public List<MenuButton> SubButtons { get; private set; }

        private void AddSubButtons(string name, IEnumerable<MenuButton> subButtons)
        {
            Name = name;
            SubButtons = new List<MenuButton>();
            foreach (MenuButton button in subButtons)
            {
                TkDebug.AssertNotNull(button.Type,
                    "子菜单中不能添加带有子菜单的按钮", button);
                SubButtons.Add(button);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        internal static MenuButton CreateKeyMenu(ButtonType buttonType, string name, string key)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);
            TkDebug.AssertArgumentNullOrEmpty(key, "key", null);

            MenuButton menu = new MenuButton
            {
                Type = buttonType,
                Name = name,
                Key = key
            };
            return menu;
        }

        public static MenuButton CreateClickMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.Click, name, key);
        }

        public static MenuButton CreateScanCodePushMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.ScanCodePush, name, key);
        }

        public static MenuButton CreateScanCodeWaitmsgMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.ScanCodeWaitmsg, name, key);
        }

        public static MenuButton CreatePicSysPhotoMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.PicSysPhoto, name, key);
        }

        public static MenuButton CreatePicPhotoAlbumMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.PicPhotoAlbum, name, key);
        }

        public static MenuButton CreatePicWeixinMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.PicWeixin, name, key);
        }

        public static MenuButton CreateLocationSelectMenu(string name, string key)
        {
            return CreateKeyMenu(ButtonType.LocationSelect, name, key);
        }

        public static MenuButton CreateViewMenu(string name, string url)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);
            TkDebug.AssertArgumentNullOrEmpty(url, "url", null);

            MenuButton menu = new MenuButton
            {
                Type = ButtonType.View,
                Name = name,
                Url = url
            };
            return menu;
        }

        public static MenuButton CreateMenu(string name, params MenuButton[] subButtons)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);
            TkDebug.AssertArgumentNull(subButtons, "subButtons", null);

            MenuButton menu = new MenuButton();
            menu.AddSubButtons(name, subButtons);
            return menu;
        }
    }
}
