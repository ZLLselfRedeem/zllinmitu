using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public sealed class WeMenu : WeixinResult
    {
        internal WeMenu()
        {
            Buttons = new List<MenuButton>();
        }

        internal WeMenu(QueryMenuData menuData)
        {
            ErrorCode = menuData.ErrorCode;
            ErrorMsg = menuData.ErrorMsg;
        }

        [ObjectElement(IsMultiple = true, LocalName = "button", UseConstructor = true)]
        internal List<MenuButton> Buttons { get; private set; }

        public void AddButton(MenuButton button)
        {
            TkDebug.AssertArgumentNull(button, "button", this);
            TkDebug.Assert(Buttons.Count <= 3, "当前的菜单数已经超过3个，这是微信允许的最大数量", this);

            Buttons.Add(button);
        }

        public string ToJson()
        {
            return this.WriteJson(WeConst.WRITE_SETTINGS);
        }

        private WeixinResult InternalCreateMenu(string url)
        {
            string json = ToJson();
            WeixinResult result = new WeixinResult();
            return WeUtil.PostToUri(url, json, result);
        }

        //internal WeixinResult CreateMenu(string appId, string appSecret)
        //{
        //    AccessToken token = AccessToken.CreateInternalToken(appId, appSecret);
        //    string url = string.Format(ObjectUtil.SysCulture, WeConst.CREATE_MENU, token.Token);
        //    string json = ToJson();
        //    WeixinResult result = new WeixinResult();
        //    return WeUtil.PostToUri(url, json, result);
        //}

        public WeixinResult CreateMenu()
        {
            string url = WeUtil.GetUrl(WeConst.CREATE_MENU);
            return InternalCreateMenu(url);
        }

        public WeixinResult CreateCorpMenu(int appId)
        {
            string url = WeCorpUtil.GetCorpMenuUrl(WeCorpConst.CREATE_MENU, appId);
            return InternalCreateMenu(url);
        }

        private static WeMenu InternalQueryMenu(string url)
        {
            QueryMenuData menuData = WeUtil.GetFromUri<QueryMenuData>(url);
            if (menuData.IsError)
                return new WeMenu(menuData);
            else
                return menuData.Menu;
        }

        public static WeMenu QueryMenu()
        {
            string url = WeUtil.GetUrl(WeConst.QUERY_MENU);
            return InternalQueryMenu(url);
        }

        public static WeMenu QueryCorpMenu(int appId)
        {
            string url = WeCorpUtil.GetCorpMenuUrl(WeCorpConst.QUERY_MENU, appId);
            return InternalQueryMenu(url);
        }

        public static WeixinResult DeleteMenu()
        {
            string url = WeUtil.GetUrl(WeConst.DELETE_MENU);
            return WeUtil.GetFromUri<WeixinResult>(url);
        }

        public static WeixinResult DeleteCorpMenu(int appId)
        {
            string url = WeCorpUtil.GetCorpMenuUrl(WeCorpConst.DELETE_MENU, appId);
            return WeUtil.GetFromUri<WeixinResult>(url);
        }
    }
}
