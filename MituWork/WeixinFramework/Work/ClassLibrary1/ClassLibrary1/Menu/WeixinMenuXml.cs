using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class WeixinMenuXml : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public MenuConfigItem Menu { get; private set; }

        public WeMenu CreateMenu()
        {
            if (Menu == null)
                return null;

            WeMenu menu = new WeMenu();
            foreach (var item in Menu.Buttons)
            {
                MenuButton button = item.CreateObject();
                menu.AddButton(button);
            }
            return menu;
        }
    }
}