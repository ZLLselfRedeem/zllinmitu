using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeInputNativeRequest : BasePayRequest
    {
        internal WeInputNativeRequest()
        {
        }

        //public WeInputNativeRequest(string openid, bool isSubscribe, string productId)
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(openid, "openid", null);
        //    TkDebug.AssertArgumentNullOrEmpty(productId, "productId", null);

        //    OpenId = openid;
        //    IsSubscribe = isSubscribe;
        //    ProductId = productId;
        //}

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string OpenId { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinBoolTypeConverter))]
        public bool IsSubscribe { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; private set; }
    }
}
