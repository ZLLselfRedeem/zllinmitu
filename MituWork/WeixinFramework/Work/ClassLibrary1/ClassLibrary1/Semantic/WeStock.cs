using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeStock : WeSemanticBase
    {
        [ObjectElement(Order = 50, NamingRule = NamingRule.Lower)]
        public WeStockSemantic Semantic { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 60, LocalName = "result")]
        public List<WeStockResult> Results { get; private set; }
    }
}
