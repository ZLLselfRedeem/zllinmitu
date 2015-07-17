using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class MicroPayRequest : WeCloseOrderRequest
    {
        internal MicroPayRequest()
        {
            DeviceInfo = "1000";
            SpbillCreateIp = WePaymentRequest.LocallIp;
        }

        public MicroPayRequest(string body, int totalFee, string authCode)
            : this()
        {
            Body = body;
            TotalFee = totalFee;
            AuthCode = authCode;
        }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Camel, UseCData = true)]
        public string Body { get; private set; }

        [SimpleElement(Order = 80, NamingRule =  NamingRule.Lower)]
        public string Detail { get;  set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Camel)]
        public string Attach { get; set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public int TotalFee { get; private set; }

        [SimpleElement(Order= 110, NamingRule = NamingRule.UnderLineLower)]
        public string FeeType { get;  set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string SpbillCreateIp { get; private set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeStart { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime TimeExpire { get; set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        public string GoodsTag { get; set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        public string AuthCode { get; private set; }
    }
}
