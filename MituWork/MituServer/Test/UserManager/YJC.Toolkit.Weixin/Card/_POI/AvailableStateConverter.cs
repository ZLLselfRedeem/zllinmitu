using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class AvailableStateConverter : NullableConverter
    {
        public AvailableStateConverter()
            : base(new EnumIntTypeConverter(typeof(AvailableState)))
        {
        }
    }
}
