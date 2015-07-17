using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeSematicTemplate<T>
    {
        [ObjectElement(Order = 10, NamingRule = NamingRule.Lower)]
        public T Details { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Intent { get; private set; }
    }
}
