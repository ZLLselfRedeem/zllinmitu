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
                    return ProductStatusType.On;
                case 1:
                    return ProductStatusType.Down;
                default:
                    return ProductStatusType.On;
            }
        }

        public string ConvertToString(object value, WriteSettings settings)
        {
            ProductStatusType msg = (ProductStatusType)value;
            switch (msg)
            {
                case ProductStatusType.On:
                    return "0";
                case ProductStatusType.Down:
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
