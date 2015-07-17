using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeReportRequest : WeCloseOrderRequest
    {
        public WeReportRequest()
        {
            DeviceInfo = "1000";
            UserIp = WePaymentRequest.LocallIp;
        }

        public WeReportRequest(string interfaceUrl, int executeTime, WePaymentResultCode returnCode,
            WePaymentResultCode resultCode)
            : this()
        {
            InterfaceUrl = interfaceUrl;
            ExecuteTime = executeTime;
            ReturnCode = returnCode;
            ResultCode = resultCode;
        }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string InterfaceUrl { get; private set; }

        [SimpleElement(Order = 90, LocalName = "execute_time_")]
        public int ExecuteTime { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ReturnCode { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string ReturnMsg { get; set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ResultCode { get; private set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCodeDes { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCode { get; set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        public string UserIp { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime Time { get; set; }
    }
}
