using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeRefundQueryRequest : WeCloseOrderRequest
    {
        internal WeRefundQueryRequest()
        {
            DeviceInfo = "1000";
        }

        public WeRefundQueryRequest(string orderid, WeOrderName orderName)
            : this()
        {
            if (orderName == WeOrderName.RefundId)
            {
                RefundId = orderid;
            }
            else if (orderName == WeOrderName.OutRefundNo)
            {
                OutRefundNo = orderid;
            }
            else if (orderName == WeOrderName.TransactionId)
            {
                TransactionId = orderid;
            }
            else if (orderName == WeOrderName.OutTradeNo)
            {
                OutTradeNo = orderid;
            }
        }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string OutRefundNo { get; set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public string RefundId { get; set; }
    }
}
