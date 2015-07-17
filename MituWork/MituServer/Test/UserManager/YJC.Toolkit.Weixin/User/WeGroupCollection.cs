using YJC.Toolkit.Cache;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    [DayChangeCache]
    internal class WeGroupCollection : WeixinResult
    {
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Camel, UseConstructor = true)]
        public RegNameList<WeGroup> Groups { get; private set; }
    }
}
