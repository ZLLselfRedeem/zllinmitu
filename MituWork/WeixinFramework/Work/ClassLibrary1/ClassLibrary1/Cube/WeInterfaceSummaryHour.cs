using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeInterfaceSummaryHour : WeInterfaceSummary
    {
        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int RefHour { get; private set; }
    }
}
