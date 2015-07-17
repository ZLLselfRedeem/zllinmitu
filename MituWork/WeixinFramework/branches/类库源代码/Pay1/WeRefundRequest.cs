using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeRefundRequest : WeCloseOrderRequest
    {
        internal WeRefundRequest()
        {
            DeviceInfo = "1000";
        }

        public WeRefundRequest(string orderId, int totalFee, int refundFee, string opUserId, WeOrderName orderName)
            : this()
        {
            if (orderName == WeOrderName.TransactionId)
            {
                TransactionId = orderId;
            }
            else if (orderName == WeOrderName.OutTradeNo)
            {
                OutTradeNo = orderId;
            }

            TotalFee = totalFee;
            RefundFee = refundFee;
            OpUserId = opUserId;
        }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string OutRefundNo { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public int TotalFee { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public int RefundFee { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string OpUserId { get; private set; }
    }
}
