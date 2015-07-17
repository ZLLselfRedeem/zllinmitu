using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class WePageIdList
    {
        public WePageIdList(params int[] idList)
        {
            PageIds = new List<int>(idList);
        }

        [SimpleElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public List<int> PageIds { get; private set; }
    }
}
