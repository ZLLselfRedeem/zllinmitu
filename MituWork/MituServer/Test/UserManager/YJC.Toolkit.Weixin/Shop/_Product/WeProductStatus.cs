using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeProductStatus
    {
        internal WeProductStatus()
        {
        }

        public WeProductStatus(ProductStatus status)
        {
            Status = status;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public ProductStatus Status { get; private set; }

    }
}
