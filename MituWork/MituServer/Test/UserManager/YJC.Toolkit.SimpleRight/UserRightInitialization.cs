using System.Web;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.SimpleRight
{
    class UserRightInitialization : IWebInitialization
    {
        #region IWebInitialization 成员

        public void SessionEnd(HttpApplication application)
        {
        }

        public void SessionStart(HttpApplication application, SessionGlobal sessionGlobal)
        {
            if (sessionGlobal != null)
            {
                sessionGlobal.AppRight.LogOnRight = new UserLogOnRight();
                sessionGlobal.AppRight.ScriptBuilder = new BootstrapMenuBuilder();
                sessionGlobal.AppRight.FunctionRight = new SimpleFunctionRight();
            }
        }

        #endregion

        #region IInitialization 成员

        public void AppEnd(object application)
        {
        }

        public void AppStarted(object application, BaseAppSetting appsetting,
            BaseGlobalVariable globalVariable)
        {
        }

        public void AppStarting(object application, BaseAppSetting appsetting,
            BaseGlobalVariable globalVariable)
        {
        }

        #endregion
    }
}
