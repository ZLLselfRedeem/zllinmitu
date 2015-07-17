using System.IO;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    class WeixinInitialization : IInitialization
    {
        #region IInitialization 成员

        public void AppStarting(object application, BaseAppSetting appsetting,
            BaseGlobalVariable globalVariable)
        {
            string path = Path.Combine(appsetting.XmlPath, "weixin.xml");
            if (File.Exists(path))
            {
                WeixinXml xml = new WeixinXml();
                xml.ReadXmlFromFile(path);
                WeixinSettings.Current = new WeixinSettings(xml);
                if (WeixinSettings.Current.Mode == WeixinMode.Normal)
                {
                    AccessToken.LoadToken();
                    JsAccessToken.LoadToken();
                }
                else
                {
                    CorpAccessTokenList.LoadToken();
                }
            }
        }

        public void AppStarted(object application, BaseAppSetting appsetting,
            BaseGlobalVariable globalVariable)
        {
        }

        public void AppEnd(object application)
        {
        }

        #endregion
    }
}
