using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WePaymentBase
    {
        protected WePaymentBase()
        {
            Appid = "wx2421b1c4370ec43b";
            MchId = "10000100";
            NonceStr = WeUtil.CreateNonceStr();
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        public string Appid { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string MchId { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string NonceStr { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Camel)]
        public string Sign { get; protected set; }

        public void CreateSign()
        {
            string queryString = this.WriteQueryString(QueryStringOutput.WeixinOutput);
            queryString += "&key=8934e7d15453e97507";
            Sign = WeUtil.Md5(queryString);
        }

        public string ToXml()
        {
            return WeUtil.ToXml(this);
        }
    }
}
