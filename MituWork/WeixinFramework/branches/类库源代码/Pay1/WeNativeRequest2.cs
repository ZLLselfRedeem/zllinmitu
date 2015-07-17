using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeNativeRequest2 : WePaymentBase
    {
        internal WeNativeRequest2()
        {

        }

        public WeNativeRequest2(string openid, bool isSubscribe, string productId)
        {
            TkDebug.AssertArgumentNullOrEmpty(openid, "openid", null);
            TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);

            Openid = openid;
            IsSubscribe = isSubscribe;
            ProductId = productId;
        }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Openid { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinBoolTypeConverter))]
        public bool IsSubscribe { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; private set; }
    }
}
