using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeReportResponse : WeDownloadBillResponse
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ResultCode { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCodeDes { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCode { get; set; }
    }
}
