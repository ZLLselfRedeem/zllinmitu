using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public abstract class BaseAccessToken : WeixinResult
    {
        protected BaseAccessToken()
        {
        }

        [SimpleElement]
        internal DateTime ExpireTime { get; set; }

        [SimpleElement(LocalName = "access_token", Order = 10)]
        [NameModel(WeConst.JS_MODE, LocalName = "ticket")]
        public string Token { get; protected set; }

        [SimpleElement(LocalName = "expires_in", Order = 20)]
        internal int ExpiresIn { get; set; }

        internal bool IsExpire
        {
            get
            {
                return ExpireTime < DateTime.Now;
            }
        }

        protected internal void SetExpireTime()
        {
            // 比过期时间少60秒
            ExpireTime = DateTime.Now.AddSeconds(ExpiresIn - 60);
        }

        public override string ToString()
        {
            return Token;
        }


        protected static T ReadToken<T>(string url, string modelName, T token) where T : BaseAccessToken
        {
            token = WeUtil.GetFromUri(url, modelName, token, true);
            token.SetExpireTime();
            //SaveToken(token);
            return token;
        }

        protected static T ReadToken<T>(string url, T token) where T : BaseAccessToken
        {
            return ReadToken(url, null, token);
        }
    }
}
