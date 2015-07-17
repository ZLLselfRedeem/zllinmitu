using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ShakeAround
{
    internal class WeTargetPageList
    {
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Lower, Order = 10, UseConstructor = true)]
        public List<WeShakePage> Pages { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int TotalCount { get; private set; }
    }
}
