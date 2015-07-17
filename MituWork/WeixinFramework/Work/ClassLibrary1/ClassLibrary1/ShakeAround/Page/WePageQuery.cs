using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class WePageQuery
    {
        public WePageQuery(int beg, int cnt)
        {
            Begin = beg;
            Count = cnt;
        }
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Begin { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public int Count { get; private set; }
    }
}
