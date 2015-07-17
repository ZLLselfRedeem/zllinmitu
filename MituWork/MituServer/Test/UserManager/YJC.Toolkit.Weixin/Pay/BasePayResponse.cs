using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class BasePayResponse : BasePayData
    {
        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public PayResult ReturnCode { get; protected set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string ReturnMsg { get; protected set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(UpperCaseEnumConverter), UseObjectType = true)]
        public PayResult ResultCode { get; protected set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string ErrCodeDes { get; protected set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public PayErrorCode ErrCode { get; protected set; }
    }
}
