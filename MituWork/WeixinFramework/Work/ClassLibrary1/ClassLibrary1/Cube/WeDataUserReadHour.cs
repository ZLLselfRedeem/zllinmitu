using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeDataUserReadHour
    {
        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        public List<WeUserReadHour> List { get; private set; }
    }
}
