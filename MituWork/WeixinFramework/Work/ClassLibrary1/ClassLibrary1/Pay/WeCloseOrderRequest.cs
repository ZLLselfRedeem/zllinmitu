using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeCloseOrderRequest : BasePayRequest
    {
        protected WeCloseOrderRequest()
            : base()
        {
        }

        public WeCloseOrderRequest(string outTradeNo)
            : base()
        {
            TkDebug.AssertArgumentNullOrEmpty(outTradeNo, "outTradeNo", null);

            OutTradeNo = outTradeNo;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string OutTradeNo { get; set; }
    }
}
