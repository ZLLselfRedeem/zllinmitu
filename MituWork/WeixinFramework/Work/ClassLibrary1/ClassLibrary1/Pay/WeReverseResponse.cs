using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    public class WeReverseResponse : BasePayResponse
    {
        [SimpleElement(Order = 100, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(WeixinBoolTypeConverter))]
        public bool Recall { get; private set; }
    }
}
