using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeProductStatus
    {
        internal WeProductStatus()
        {
        }

        public WeProductStatus(ProductStatusType status)
        {
            Status = status;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public ProductStatusType Status { get; private set; }

    }
}
