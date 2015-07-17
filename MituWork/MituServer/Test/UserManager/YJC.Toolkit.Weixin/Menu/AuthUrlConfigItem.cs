using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class AuthUrlConfigItem : CorpAuthUrlConfigItem
    {
        [SimpleAttribute]
        public AuthType AuthType { get; private set; }

        public override string ToUri()
        {
            if (string.IsNullOrEmpty(Content))
            {
                Content = "Library/WeAuth.tkx";
            }
            string url = LocalToUri();
            return WeUtil.CreateAuthUrl(url, AuthType, State);
        }
    }
}
