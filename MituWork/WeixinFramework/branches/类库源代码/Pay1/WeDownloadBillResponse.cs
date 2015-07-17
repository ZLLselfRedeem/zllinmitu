using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeDownloadBillResponse
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ReturnCode { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string ReturnMsg { get; protected set; }
    }
}
