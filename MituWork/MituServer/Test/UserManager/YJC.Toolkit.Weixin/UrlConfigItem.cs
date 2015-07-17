using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class UrlConfigItem
    {
        [SimpleAttribute]
        public string Base { get; protected set; }

        [TextContent]
        public string Content { get; protected set; }

        protected string LocalToUri()
        {
            if (string.IsNullOrEmpty(Base))
                return new Uri(Content).ToString();

            return UriUtil.CombineUri(Base, Content).ToString();
        }

        public virtual string ToUri()
        {
            return LocalToUri();
        }

        public static string ToString(UrlConfigItem config)
        {
            if (config == null)
                return null;
            return config.ToUri();
        }
    }
}
