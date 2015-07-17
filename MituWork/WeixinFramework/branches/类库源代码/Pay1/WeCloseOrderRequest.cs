using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeCloseOrderRequest : WePaymentBase
    {
        public WeCloseOrderRequest()
        {
        }

        public WeCloseOrderRequest(string outTradeNo)
        {
            TkDebug.AssertArgumentNullOrEmpty(outTradeNo, "outTradeNo", null);

            OutTradeNo = outTradeNo;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string OutTradeNo { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string TransactionId { get; set; }
    }
}
