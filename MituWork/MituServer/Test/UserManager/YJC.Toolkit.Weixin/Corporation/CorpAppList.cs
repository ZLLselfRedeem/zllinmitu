using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpAppList : WeixinResult
    {
        internal CorpAppList()
        {
        }

        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.Lower, UseConstructor = true)]
        public List<CorpAppSimpleInfo> AgentList { get; private set; }
    }
}
