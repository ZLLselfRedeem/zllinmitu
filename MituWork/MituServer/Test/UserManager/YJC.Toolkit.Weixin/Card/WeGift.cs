using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeGift
    {
        internal WeGift()
        {
        }

        public WeGift(WeCardBaseInfo baseInfo, string gift)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(gift, "gift", null);

            BaseInfo = baseInfo;
            Gift = gift;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Gift { get; private set; }
    }
}
