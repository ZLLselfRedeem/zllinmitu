using System;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Rule
{
    public class UrlMacroConfig : MarcoConfigItem
    {
        [SimpleAttribute]
        public string Base { get; private set; }

        public string ToUri(string content)
        {
            if (string.IsNullOrEmpty(Base))
                return new Uri(content).ToString();

            return UriUtil.CombineUri(Base, content).ToString();
        }
    }
}
