using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    public class AuthToken : WeixinResult
    {
        [SimpleElement(LocalName = "access_token")]
        public string AccessToken { get; private set; }

        [SimpleElement(LocalName = "expires_in")]
        public int ExpiresIn { get; private set; }

        [SimpleElement(LocalName = "refresh_token")]
        public string RefreshToken { get; private set; }

        [SimpleElement(LocalName = "openid")]
        public string OpenId { get; private set; }

        [SimpleElement(LocalName = "scope")]
        public string Scope { get; private set; }

        [SimpleElement]
        internal DateTime ExpireTime { get; private set; }

        private void SetExpireTime()
        {
            ExpireTime = DateTime.Now.AddSeconds(ExpiresIn - 60);
        }
    }
}
