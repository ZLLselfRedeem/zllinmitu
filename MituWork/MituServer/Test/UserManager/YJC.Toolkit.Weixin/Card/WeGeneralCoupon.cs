using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeGeneralCoupon
    {
        internal WeGeneralCoupon()
        {
        }

        public WeGeneralCoupon(WeCardBaseInfo baseInfo, string defaultDetail)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(defaultDetail, "defaultDetail", null);

            BaseInfo = baseInfo;
            DefaultDetail = defaultDetail;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string DefaultDetail { get; private set; }
    }
}
