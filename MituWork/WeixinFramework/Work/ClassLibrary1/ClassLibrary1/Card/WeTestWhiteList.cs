using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeTestWhiteList
    {
        public WeTestWhiteList(string[] idList, string[] nameList)
        {
            OpenId = new List<string>(idList);
            UserName = new List<string>(nameList);
        }

        [SimpleElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        public List<string> OpenId { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 20, NamingRule = NamingRule.Lower)]
        public List<string> UserName { get; private set; }
    }
}
