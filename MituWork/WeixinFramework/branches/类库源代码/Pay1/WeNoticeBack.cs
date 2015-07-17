using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeNoticeBack
    {
        internal WeNoticeBack()
        {
        }

        public WeNoticeBack(WePaymentResultCode returnCode)
        {
            ReturnCode = returnCode;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public WePaymentResultCode ReturnCode { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string ReturnMsg { get; set; }

        public string ToXml()
        {
            return WeUtil.ToXml(this);
        }
    }
}
