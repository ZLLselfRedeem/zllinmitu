using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeRefundResponse : WeCloseOrderResponse
    {
        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; private set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string OutTradeNo { get; private set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string OutRefundNo { get; private set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public string RefundId { get; private set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WeRefundChannel RefundChannel { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        public int RefundFee { get; private set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public int CouponRefundFee { get; private set; }
    }
}
