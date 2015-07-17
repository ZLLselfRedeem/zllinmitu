using System.Web;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Web;

namespace YJC.Toolkit.SimpleRight
{
    [Source(Author = "YJC", Description = "退出系统", CreateDate = "2014-08-05")]
    [OutputRedirector]
    class SimpleLogOffSource : ISource
    {
        #region ISource 成员

        public OutputData DoAction(IInputData input)
        {
            WebGlobalVariable.Session.Abandon();
            var emptyCookie = new HttpCookie(RightConst.USER_INFO_COOKIE_NAME, null);
            WebGlobalVariable.Response.Cookies.Set(emptyCookie);

            string url = WebAppSetting.WebCurrent.LogOnPath;
            return OutputData.Create(url);
        }

        #endregion
    }
}
