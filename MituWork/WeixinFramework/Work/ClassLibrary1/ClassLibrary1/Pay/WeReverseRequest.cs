using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeReverseRequest : WeCloseOrderRequest
    {
        public WeReverseRequest(OrderType orderType, string orderId)
            : base()
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
                case OrderType.RefundId:
                    TkDebug.ThrowToolkitException(string.Format(ObjectUtil.SysCulture,
                        "当前不支持{0}这种枚举，请确认", orderType), null);
                    break;
            }
        }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; private set; }
    }
}
