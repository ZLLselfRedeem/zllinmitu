using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeServer<T> : WeSemanticBase
    {
        [ObjectElement(Order = 70, NamingRule = NamingRule.Lower)]
        public WeSematicTemplate<T> Semantic { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 60, LocalName = "result")]
        public List<WeStockResult> Results { get; private set; }
    }
}
