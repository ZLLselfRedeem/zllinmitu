using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    class DetailAuthStateConfig : AuthStateConfig
    {
        [SimpleAttribute]
        public string IdName { get; private set; }

        public override string GetUrl(string id)
        {
            string split;
            if (Url.Contains("?"))
            {
                if (Url.EndsWith("&", StringComparison.Ordinal))
                    split = string.Empty;
                else
                    split = "&";
            }
            else
                split = "?";
            return string.Format(ObjectUtil.SysCulture, "{0}{1}{2}={3}", Url, split, IdName, id);
        }
    }
}
