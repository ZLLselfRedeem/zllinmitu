using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WePaymentRequest : WeCloseOrderRequest
    {
        private WePaymentRequest()
        {
            DeviceInfo = WeixinSettings.Current.DeviceInfo;
            SpbillCreateIp = WeixinSettings.Current.DeviceIp;
            NotifyUrl = WeixinSettings.Current.PayNotifyUrl;
        }

        public WePaymentRequest(TradeType tradeType, string body,
            int totalFee)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(body, "body", null);

            Body = body;
            TotalFee = totalFee;
            TradeType = tradeType;
        }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Camel, UseCData = true)]
        public string Body { get; private set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Camel)]
        public string Attach { get; set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public int TotalFee { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public string SpbillCreateIp { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeStart { get; set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeExpire { get; set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string GoodsTag { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public string NotifyUrl { get; private set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public TradeType TradeType { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.Lower)]
        public string OpenId { get; set; }

        [SimpleElement(Order = 170, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; set; }

        public WeMicroPayResponse Prepay()
        {
            CreateSign();
            var result = WeUtil.PostDataToUri(WePayConst.MICRO_PAY_URL, ToXml(), new WeMicroPayResponse());
            return result;
        }
    }
}
