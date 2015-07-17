using System;
using System.Data;
using System.Web;
using YJC.Toolkit.Data;
using YJC.Toolkit.LogOn;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.SimpleRight
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-12-03", Description = "普通的Logon数据源")]
    internal sealed class SimpleLogOnObjectSource : IInsertObjectSource, IDisposable, IDbDataSource
    {
        private const string COOKIE_NAME = "LogOnName";

        public SimpleLogOnObjectSource()
        {
            DataSet = new DataSet(ToolkitConst.TOOLKIT) { Locale = ObjectUtil.SysCulture };
            Context = DbContextUtil.CreateDefault();
        }

        #region IObjectInsertSource 成员

        public object CreateNew(IInputData input)
        {
            LogOnData data = new LogOnData();
            var request = WebGlobalVariable.Request;
            var logonName = request.Cookies[COOKIE_NAME];
            if (logonName != null && !string.IsNullOrEmpty(logonName.Value))
                data.LogOnName = logonName.Value;
            return data;
        }

        public OutputData Insert(IInputData input, object instance)
        {
            LogOnData data = instance.Convert<LogOnData>();
            using (UserResolver resolver = new UserResolver(this))
            {
                IUserInfo userInfo = resolver.CheckUserLogOn(data.LogOnName, data.Password, 0);
                if (userInfo == null)
                {
                }
                WebGlobalVariable.SessionGbl.AppRight.Initialize(userInfo);

                var response = WebGlobalVariable.Response;
                HttpCookie cookie = new HttpCookie(COOKIE_NAME, data.LogOnName)
                {
                    Expires = DateTime.Now.AddDays(30)
                };
                response.Cookies.Set(cookie);
                CookieUserInfo cookieInfo = new CookieUserInfo(data, userInfo);
                cookie = new HttpCookie(RightConst.USER_INFO_COOKIE_NAME, cookieInfo.Encode())
                {
                    Expires = GetExpireDate()
                };
                response.Cookies.Set(cookie);

                WebSuccessResult result;
                var request = WebGlobalVariable.Request;
                string retUrl = request.QueryString["RetURL"];
                if (!string.IsNullOrEmpty(retUrl))
                    result = new WebSuccessResult(retUrl);
                else
                {
                    WebAppSetting appSetting = WebAppSetting.WebCurrent;
                    if (string.IsNullOrEmpty(appSetting.MainPath))
                        result = new WebSuccessResult(appSetting.HomePath);
                    else
                    {
                        string url = HttpUtility.UrlEncode(appSetting.HomePath);
                        string mainUrl = UriUtil.AppendQueryString(appSetting.MainPath, "StartUrl=" + url);
                        result = new WebSuccessResult(mainUrl);
                    }
                }

                return OutputData.CreateToolkitObject(result);
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            DataSet.Dispose();
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDbDataSource 成员

        public DataSet DataSet { get; private set; }

        public TkDbContext Context { get; private set; }

        #endregion

        private static DateTime GetExpireDate()
        {
            DateTime nextDay = DateTime.Today.AddDays(1);
            DateTime eightHour = DateTime.Now.AddHours(8);

            return nextDay > eightHour ? eightHour : nextDay;
        }
    }
}
