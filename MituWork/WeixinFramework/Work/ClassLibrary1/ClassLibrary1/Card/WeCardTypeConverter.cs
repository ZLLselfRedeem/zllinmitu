using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardTypeConverter : NullableConverter
    {
        public WeCardTypeConverter()
            : base(new EnumFieldValueTypeConverter(typeof(CardType)))
        {
        }
    }
}
