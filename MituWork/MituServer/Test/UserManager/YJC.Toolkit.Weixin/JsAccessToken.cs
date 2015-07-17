using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Threading;

namespace YJC.Toolkit.Weixin
{
    public sealed class JsAccessToken : BaseAccessToken
    {
        private static JsAccessToken fCurrent;

        private JsAccessToken()
        {
        }

        private static JsAccessToken CreateToken()
        {
            string url;
            if (WeixinSettings.Current.Mode == WeixinMode.Normal)
                url = WeUtil.GetUrl(WeConst.JS_TICKET);
            else
                url = WeCorpUtil.GetCorpUrl(WeCorpConst.JS_TICKET, WeixinSettings.Current.CorpUserManagerSecret);
            JsAccessToken token = ReadToken(url, WeConst.JS_MODE, new JsAccessToken());
            SaveToken(token);
            return token;
        }

        private static string GetTokenFileName()
        {
            string fileName = Path.Combine(WeixinSettings.Current.WeixinPath, @"weixin\jstoken.json");
            return fileName;
        }

        private static void SaveToken(JsAccessToken fCurrent)
        {
            string fileName = GetTokenFileName();
            FileUtil.VerifySaveFile(fileName, fCurrent.WriteJson(WeConst.JS_MODE), Encoding.UTF8);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void SaveToken()
        {
            if (fCurrent == null)
                return;
            SaveToken(fCurrent);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LoadToken()
        {
            string fileName = GetTokenFileName();
            if (File.Exists(fileName))
            {
                fCurrent = new JsAccessToken();
                fCurrent.ReadFromFile("Json", WeConst.JS_MODE, fileName, ReadSettings.Default, QName.Toolkit);
            }
        }

        public static string CurrentToken
        {
            get
            {
                IRWLock rwLock = BaseGlobalVariable.Current.CreateRWLock();
                using (rwLock)
                {
                    if (fCurrent == null)
                    {
                        fCurrent = RWLock.WriteLockAction(rwLock, CreateToken);
                        return fCurrent.Token;
                    }
                    else
                    {
                        fCurrent = RWLock.ReadLockAction(rwLock, () =>
                        {
                            if (fCurrent.IsExpire)
                            {
                                fCurrent = RWLock.WriteLockAction(rwLock, CreateToken);
                            }
                            return fCurrent;
                        });
                        return fCurrent.Token;
                    }
                }
            }
        }
    }
}
