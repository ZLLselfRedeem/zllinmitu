using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpUserIdList
    {
        public CorpUserIdList(IEnumerable<string> userIdList)
        {
            UserIdList = new List<string>(userIdList);
        }

        [SimpleElement(IsMultiple = true, NamingRule = NamingRule.Lower)]
        public List<string> UserIdList { get; private set; }
    }
}
