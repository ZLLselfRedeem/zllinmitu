using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeRefundQueryRequest : WeCloseOrderRequest
    {
        internal WeRefundQueryRequest()
        {
            DeviceInfo = WeixinSettings.Current.DeviceInfo;
        }

        public WeRefundQueryRequest(OrderType orderType, string orderId)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);

            switch (orderType)
            {
                case OrderType.TransactionId:
                    TransactionId = orderId;
                    break;
                case OrderType.OutTradeNo:
                    OutTradeNo = orderId;
                    break;
                case OrderType.OutRefundNo:
                    OutRefundNo = orderId;
                    break;
                case OrderType.RefundId:
                    RefundId = orderId;
                    break;
            }
        }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string OutRefundNo { get; set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string RefundId { get; set; }
    }
}
