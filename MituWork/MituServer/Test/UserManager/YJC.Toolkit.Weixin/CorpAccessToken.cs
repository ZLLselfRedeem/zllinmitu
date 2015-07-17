using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public sealed class CorpAccessToken : BaseAccessToken, IRegName
    {
        private CorpAccessToken()
        {
        }

        #region IRegName 成员

        public string RegName { get; private set; }

        #endregion

        internal static CorpAccessToken CreateToken(string secret)
        {
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.TOKEN_URL,
                WeixinSettings.Current.AppId, secret);
            CorpAccessToken token = ReadToken(url, new CorpAccessToken());
            token.RegName = secret;
            return token;
        }

        public static string GetTokenWithAppId(int appId)
        {
            string secret = WeixinSettings.Current.GetCorpSecret(appId);
            return GetTokenWithSecret(secret);
        }

        public static string GetTokenWithSecret(string secret)
        {
            return CorpAccessTokenList.GetToken(secret);
        }
    }
}
