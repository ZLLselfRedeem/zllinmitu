using System.Collections.Generic;
using System.Web;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.SimpleRight
{
    [Source(Author = "YJC", CreateDate = "2014-07-10", Description = "主界面")]
    internal class MainPageSource : ISource
    {
        #region ISource 成员

        public OutputData DoAction(IInputData input)
        {
            IUserInfo userInfo = WebGlobalVariable.Info;

            Dictionary<string, string> result = new Dictionary<string, string>();
            result["Menu"] = WebGlobalVariable.SessionGbl.AppRight.CreateMenu(userInfo);
            result["UserName"] = userInfo.UserName;
            result["StartUrl"] = WebUtil.ResolveUrl(input.QueryString["StartUrl"]);
            result["HomeUrl"] = WebUtil.ResolveUrl("~/Library/WebModuleContentPage.tkx?Source=UserManager/MainPage&StartUrl="
                + HttpUtility.UrlEncode(WebAppSetting.WebCurrent.HomePath));
            result["FullName"] = WebAppSetting.WebCurrent.AppFullName;
            result["ShortName"] = WebAppSetting.WebCurrent.AppShortName;

            return OutputData.CreateObject(result);
        }

        #endregion
    }
}
