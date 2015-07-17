using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WePoiQuery
    {
        public WePoiQuery(int beg, int limit)
        {
            Begin = beg;
            Limit = limit;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Begin { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public int Limit { get; private set; }
    }
}
