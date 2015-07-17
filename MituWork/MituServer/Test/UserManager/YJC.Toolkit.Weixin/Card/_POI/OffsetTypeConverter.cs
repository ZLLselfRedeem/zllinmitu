using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class OffsetTypeConverter : NullableConverter
    {
        public OffsetTypeConverter()
            : base(new EnumIntTypeConverter(typeof(OffsetType)))
        {
        }
    }
}
