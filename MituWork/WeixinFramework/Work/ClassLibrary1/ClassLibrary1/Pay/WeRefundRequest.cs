using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    internal class WeRefundRequest : WeCloseOrderRequest
    {
        internal WeRefundRequest()
        {
            DeviceInfo = WeixinSettings.Current.DeviceInfo;
        }

        public WeRefundRequest(OrderType orderType, string orderId, string outRefundNo, int totalFee, int refundFee)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(orderId, "orderId", null);
            TkDebug.AssertArgumentNullOrEmpty(outRefundNo, "outRefundNo", null);

            switch (orderType)
            {
                case OrderType.TransactionId:
                    TransactionId = orderId;
                    break;
                case OrderType.OutTradeNo:
                    OutTradeNo = orderId;
                    break;
                case OrderType.OutRefundNo:
                case OrderType.RefundId:
                    TkDebug.ThrowToolkitException(string.Format(ObjectUtil.SysCulture,
                        "当前不支持{0}这种枚举，请确认", orderType), null);
                    break;
            }

            OutRefundNo = outRefundNo;
            TotalFee = totalFee;
            RefundFee = refundFee;
            OpUserId = MchId;
        }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string DeviceInfo { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string OutRefundNo { get; private set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public int TotalFee { get; private set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public int RefundFee { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public string OpUserId { get; set; }
    }
}
