using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class StatusTypeConverter : ITkTypeConverter
    {
        public object ConvertFromString(string text, ReadSettings settings)
        {
            int value = text.Value<int>();
            switch (value)
            {
                case 0:
                    return ProductStatus.On;
                case 1:
                    return ProductStatus.Down;
                default:
                    return ProductStatus.On;
            }
        }

        public string ConvertToString(object value, WriteSettings settings)
        {
            ProductStatus msg = (ProductStatus)value;
            switch (msg)
            {
                case ProductStatus.On:
                    return "0";
                case ProductStatus.Down:
                    return "1";
                default:
                    return "0";
            }
        }

        public string DefaultValue
        {
            get
            {
                return "0";
            }
        }
    }
}
