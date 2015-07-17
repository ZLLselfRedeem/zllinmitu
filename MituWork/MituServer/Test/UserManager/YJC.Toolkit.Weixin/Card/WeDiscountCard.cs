using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeDiscountCard
    {
        internal WeDiscountCard()
        {
        }

        public WeDiscountCard(WeCardBaseInfo baseInfo, int discount)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInfo = baseInfo;
            Discount = discount;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public int Discount { get; private set; }
    }
}
