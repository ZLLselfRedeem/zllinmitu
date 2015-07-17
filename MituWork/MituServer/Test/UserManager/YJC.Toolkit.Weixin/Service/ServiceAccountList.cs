using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class ServiceAccountList
    {
        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public RegNameList<ServiceAccount> KfList { get; private set; }
    }
}
