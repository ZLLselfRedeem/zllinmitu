using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Cube
{
    public class WeNewsBase
    {
        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int IntPageReadUser { get; protected set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int IntPageReadCount { get; protected set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public int OriPageReadUser { get; protected set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public int OriPageReadCount { get; protected set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public int ShareUser { get; protected set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public int ShareCount { get; protected set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public int AddToFavUser { get; protected set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public int AddToFavCount { get; protected set; }
    }
}
