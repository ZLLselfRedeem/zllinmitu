using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeNativeRequest1 : WePaymentBase
    {
        internal WeNativeRequest1()
        {
            TimeStamp = DateTime.Now;
        }

        public WeNativeRequest1(string productId)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);

            ProductId = productId;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime TimeStamp { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; private set; }
    }
}
