using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeJsApiRequest
    {
        public WeJsApiRequest(WePaymentResponse payResponse)
        {
            TkDebug.AssertArgumentNull(payResponse, "payResponse", null);

            AppId = WeixinSettings.Current.AppId;
            NonceStr = WeUtil.CreateNonceStr();
            SignType = "MD5";
            Package = "prepay_id=" + payResponse.PrepayId;
            TimeStamp = DateTime.Now;
            PaySign = WePayUtil.CreateSign(this);
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        public string AppId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime TimeStamp { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Camel)]
        public string NonceStr { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Camel)]
        public string Package { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Camel)]
        public string SignType { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Camel)]
        public string PaySign { get; private set; }
    }
}
