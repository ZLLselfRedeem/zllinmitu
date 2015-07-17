using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class CorpAuthUrlConfigItem : UrlConfigItem
    {
        [SimpleAttribute]
        public string State { get; protected set; }

        public override string ToUri()
        {
            if (string.IsNullOrEmpty(Content))
            {
                Content = "Library/WeCorpAuth.tkx";
            }
            string url = LocalToUri();
            return WeUtil.CreateAuthUrl(url, AuthType.Base, State);
        }
    }
}
