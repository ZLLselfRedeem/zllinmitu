using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeUserReadHour : WeUserRead
    {
        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int RefHour { get; private set; }
    }
}
