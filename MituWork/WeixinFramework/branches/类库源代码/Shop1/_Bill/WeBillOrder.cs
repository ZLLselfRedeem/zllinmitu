using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeBillOrder : WeixinResult
    {
        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower)]
        public WeBill Order { get; private set; }
    }
}
