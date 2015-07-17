using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public abstract class BasePayData
    {
        protected BasePayData()
        {
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string AppId { get; protected set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string MchId { get; protected set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string NonceStr { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Camel)]
        public string Sign { get; protected set; }
    }
}
