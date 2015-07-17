using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Threading;

namespace YJC.Toolkit.Weixin
{
    public sealed class AccessToken : BaseAccessToken
    {
        private static AccessToken fCurrent;

        private AccessToken()
        {
        }

        private static AccessToken CreateToken()
        {
            string url = string.Format(ObjectUtil.SysCulture, WeConst.TOKEN_URL,
                WeixinSettings.Current.AppId, WeixinSettings.Current.AppSecret);
            AccessToken token = ReadToken(url, new AccessToken());
            SaveToken(token);
            return token;
        }

        internal static AccessToken CreateInternalToken(string appId, string appSecret)
        {
            string url = string.Format(ObjectUtil.SysCulture, WeConst.TOKEN_URL, appId, appSecret);
            AccessToken token = ReadToken(url, new AccessToken());
            return token;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void LoadToken()
        {
            string fileName = GetTokenFileName();
            if (File.Exists(fileName))
            {
                fCurrent = new AccessToken();
                fCurrent.ReadFromFile("Json", null, fileName, ReadSettings.Default, QName.Toolkit);
            }
        }

        private static void SaveToken(AccessToken fCurrent)
        {
            string fileName = GetTokenFileName();
            FileUtil.VerifySaveFile(fileName, fCurrent.WriteJson(), Encoding.UTF8);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void SaveToken()
        {
            if (fCurrent == null)
                return;
            SaveToken(fCurrent);
        }

        private static string GetTokenFileName()
        {
            string fileName = Path.Combine(WeixinSettings.Current.WeixinPath, @"weixin\token.json");
            return fileName;
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
