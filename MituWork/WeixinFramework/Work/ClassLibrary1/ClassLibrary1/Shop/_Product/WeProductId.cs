using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeProductId : WeixinResult
    {
        public WeProductId()
        {
        }

        public WeProductId(string productId)
        {
            ProductId = productId;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; protected set; }
    }
}
