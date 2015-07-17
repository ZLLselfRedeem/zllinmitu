using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeDownloadBillRequest : BasePayRequest
    {
        internal WeDownloadBillRequest()
        {
            DeviceInfo = WeixinSettings.Current.DeviceInfo;
        }

        public WeDownloadBillRequest(DateTime billDate)
            : this()
        {
            BillDate = billDate;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(DateStringTypeConverter))]
        public DateTime BillDate { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public BillType BillType { get; set; }
    }
}
