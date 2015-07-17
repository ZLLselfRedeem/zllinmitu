using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class BillStatusConverter : NullableConverter
    {
        public BillStatusConverter()
            : base(new EnumIntTypeConverter(typeof(BillStatus)))
        {
        }
    }
}
