using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeCloseOrderResponse : WePaymentBase
    {
        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ReturnCode { get; protected set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string ReturnMsg { get; protected set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ResultCode { get; protected set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCodeDes { get; protected set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCode { get; protected set; }
    }
}
