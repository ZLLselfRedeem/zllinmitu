using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeDataUserRead
    {
        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        public List<WeUserRead> List { get; private set; }
    }
}
