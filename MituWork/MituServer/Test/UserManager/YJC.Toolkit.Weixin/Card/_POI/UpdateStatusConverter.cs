using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class UpdateStatusConverter : NullableConverter
    {
        public UpdateStatusConverter()
            : base(new EnumIntTypeConverter(typeof(UpdateStatus)))
        {
        }
    }
}
