using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCash
    {
        internal WeCash()
        {
        }

        public WeCash(WeCardBaseInfo baseInfo, int reduceCost)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInfo = baseInfo;
            ReduceCost = reduceCost;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int LeastCost { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int ReduceCost { get; private set; }
    }
}
