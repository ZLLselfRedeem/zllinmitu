using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeDataUpStreamMsgHour
    {
        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        public List<WeUpStreamMsgHour> List { get; private set; }
    }
}
