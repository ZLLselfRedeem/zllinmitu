using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeProductModStatus
    {
        internal WeProductModStatus()
        {
        }

        public WeProductModStatus(ProductStatus status, string productId)
        {
            Status = status;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string ProductId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(StatusTypeConverter))]
        public ProductStatus Status { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "{0}:{1}", ProductId, Status);
        }
    }
}
