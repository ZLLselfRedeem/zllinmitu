using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class NullDateTimeConverter : NullableConverter
    {
        public NullDateTimeConverter()
            : base(new WeixinDateTimeConverter())
        {
        }
    }
}
