using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeBillId
    {
        internal WeBillId()
        {
        }

        public WeBillId(string orderId)
        {
            OrderId = orderId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string OrderId { get; private set; }
    }
}
