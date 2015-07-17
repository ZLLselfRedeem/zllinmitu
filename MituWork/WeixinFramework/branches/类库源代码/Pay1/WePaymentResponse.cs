using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WePaymentResponse : WeCloseOrderResponse
    {
        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentType TradeType { get; private set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string PrepayId { get; private set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string CodeUrl { get; private set; }
    }
}
