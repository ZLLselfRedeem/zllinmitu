using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpTagMembers : CorpUserList
    {
        [SimpleElement(Order = 40, IsMultiple = true, NamingRule = NamingRule.Lower)]
        public List<int> PartyList { get; private set; }
    }
}
