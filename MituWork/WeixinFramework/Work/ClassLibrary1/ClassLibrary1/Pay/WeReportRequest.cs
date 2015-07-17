using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeReportRequest : WeCloseOrderRequest
    {
        public WeReportRequest(string outTradeNo)
            : base(outTradeNo)
        {
            DeviceInfo = WeixinSettings.Current.DeviceInfo;
            UserIp = WeixinSettings.Current.DeviceIp;
            Time = DateTime.Now;
        }

        public WeReportRequest(BasePayResponse response, string outTradeNo,
            string interfaceUrl, int executeTime)
            : this(outTradeNo)
        {
            TkDebug.AssertArgumentNull(response, "response", null);
            TkDebug.AssertArgumentNullOrEmpty(interfaceUrl, "interfaceUrl", null);

            InterfaceUrl = interfaceUrl;
            ExecuteTime = executeTime;
            ReturnCode = response.ReturnCode;
            ReturnMsg = response.ReturnMsg;
            ResultCode = response.ResultCode;
            ErrCode = response.ErrCode;
            ErrCodeDes = response.ErrCodeDes;
        }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string InterfaceUrl { get; private set; }

        [SimpleElement(Order = 90, LocalName = "execute_time_")]
        public int ExecuteTime { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public PayResult ReturnCode { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string ReturnMsg { get; set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public PayResult ResultCode { get; private set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCodeDes { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public PayErrorCode ErrCode { get; set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.UnderLineLower)]
        public string UserIp { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateTimeStringTypeConverter))]
        public DateTime Time { get; set; }
    }
}
