using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    internal class QueryMenuData : WeixinResult
    {
        [ObjectElement(NamingRule = NamingRule.Camel, UseConstructor = true)]
        public WeMenu Menu { get; private set; }
    }
}
