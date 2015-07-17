using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeJSAPIRequest
    {
        internal WeJSAPIRequest()
        {
            AppId = "wx2421b1c4370ec43b";
            NonceStr = WeUtil.CreateNonceStr();
            SignType = "MD5";
            TimeStamp = DateTime.Now;
            CreateSign();
        }

        public WeJSAPIRequest(string package)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(package, "package", null);

            Package = package;
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

        public void CreateSign()
        {
            string queryString = this.WriteQueryString(QueryStringOutput.WeixinOutput);
            queryString += "&key=8934e7d15453e97507";
            PaySign = WeUtil.Md5(queryString);
        }

        public string ToXml()
        {
            return WeUtil.ToXml(this);
        }
    }
}
