using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public static class WePayConst
    {
        //运行时常量，readonly区别于const，const为编译时常量。
        public static readonly QName QNAME_XML = QName.Get("xml");

        public const string UNIFIED_ORDER_URL = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        public const string ORDER_QUERY_URL = "https://api.mch.weixin.qq.com/pay/orderquery";

        public const string CLOSE_ORDER_URL = "https://api.mch.weixin.qq.com/pay/closeorder";

        public const string REFUND_URL = "https://api.mch.weixin.qq.com/secapi/pay/refund";

        public const string REFUND_QUERY_URL = "https://api.mch.weixin.qq.com/pay/refundquery";

        public const string DOWNLOAD_BILL_URL = "https://api.mch.weixin.qq.com/pay/downloadbill";

        public const string SHORT_URL = "https://api.mch.weixin.qq.com/tools/shorturl";

        public const string REPORT_URL = "https://api.mch.weixin.qq.com/payitil/report";

        public const string MICRO_PAY_URL = "https://api.mch.weixin.qq.com/pay/micropay";

        public const string REVERSE_URL = "https://api.mch.weixin.qq.com/secapi/pay/reverse";
    }
}
