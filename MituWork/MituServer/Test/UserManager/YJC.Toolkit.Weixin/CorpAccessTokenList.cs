using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Threading;

namespace YJC.Toolkit.Weixin
{
    class CorpAccessTokenList
    {
        private static CorpAccessTokenList fCurrent;
        private RegNameList<CorpAccessToken> fList;

        public CorpAccessTokenList()
        {
            fList = new RegNameList<CorpAccessToken>();
        }

        [ObjectElement(IsMultiple = true, UseConstructor = true)]
        public RegNameList<CorpAccessToken> CorpTokens
        {
            get
            {
                return fList;
            }
        }

        public void AddToken(CorpAccessToken token)
        {
            fList.Add(token);
        }

        private static string GetTokenFileName()
        {
            string fileName = Path.Combine(WeixinSettings.Current.WeixinPath, @"weixin\corptoken.json");
            return fileName;
        }

        public static void LoadToken()
        {
            string fileName = GetTokenFileName();
            if (File.Exists(fileName))
            {
                fCurrent = new CorpAccessTokenList();
                fCurrent.ReadFromFile("Json", null, fileName, ReadSettings.Default, QName.Toolkit);
            }

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void SaveToken()
        {
            if (fCurrent == null)
                return;
            string fileName = GetTokenFileName();
            FileUtil.VerifySaveFile(fileName, fCurrent.WriteJson(), Encoding.UTF8);
        }

        public static string GetToken(string secret)
        {
            TkDebug.AssertArgumentNullOrEmpty(secret, "secret", null);

            IRWLock rwLock = BaseGlobalVariable.Current.CreateRWLock();
            CorpAccessToken token;
            using (rwLock)
            {
                if (fCurrent == null)
                {
                    token = RWLock.WriteLockAction(rwLock, () =>
                    {
                        CorpAccessToken result = CorpAccessToken.CreateToken(secret);
                        fCurrent = new CorpAccessTokenList();
                        fCurrent.AddToken(result);
                        SaveToken();
                        return result;
                    });
                    return token.Token;
                }
                else
                {
                    token = RWLock.ReadLockAction(rwLock, () =>
                    {
                        CorpAccessToken result = fCurrent.CorpTokens[secret];
                        if (result == null || result.IsExpire)
                        {
                            result = RWLock.WriteLockAction(rwLock, () =>
                            {
                                CorpAccessToken newToken = CorpAccessToken.CreateToken(secret);
                                fCurrent.CorpTokens.AddOrReplace(newToken);
                                SaveToken();
                                return newToken;
                            });
                        }
                        return result;
                    });
                    return token.Token;
                }
            }
        }
    }
}
