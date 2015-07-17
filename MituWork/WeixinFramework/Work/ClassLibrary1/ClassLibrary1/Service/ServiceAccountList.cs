using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class ServiceAccountList
    {
        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public List<ServiceAccount> KfList { get; private set; }
    }
}
