using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeLocationBatchAdd
    {
        public WeLocationBatchAdd(params WeLocationInit[] locationList)
        {
            LocationList = new List<WeLocationInit>(locationList);
        }

        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public List<WeLocationInit> LocationList { get; private set; }
    }
}
