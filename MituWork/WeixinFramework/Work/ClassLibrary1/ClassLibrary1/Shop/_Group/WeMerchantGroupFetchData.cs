using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeMerchantGroupFetchData : WeixinResult
    {
        internal WeMerchantGroupFetchData()
        {
        }

        public WeMerchantGroupFetchData(WeMerchantGroup groupDetail)
        {
            GroupDetail = groupDetail;
        }

        [ObjectElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public WeMerchantGroup GroupDetail { get; private set; }
    }
}
