using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeOrderQueryResponse : WeCloseOrderResponse
    {
        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string Devicenfo { get; protected set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string Openid { get; protected set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinBoolTypeConverter))]
        public bool IsSubscribe { get; protected set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentType TradeType { get; protected set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public string BankType { get; protected set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        public int TotalFee { get; protected set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        public int CouponFee { get; protected set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public string FeeType { get; protected set; }

        [SimpleElement(Order = 180, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; protected set; }

        [SimpleElement(Order = 190, NamingRule = NamingRule.UnderLineLower)]
        public string OutTradeNo { get; protected set; }

        [SimpleElement(Order = 200, NamingRule = NamingRule.UnderLineLower)]
        public String Attach { get; protected set; }

        [SimpleElement(Order = 210, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeEnd { get; protected set; }

        [SimpleElement(Order = 220, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WeTradeState TradeState { get; private set; }
    }
}
