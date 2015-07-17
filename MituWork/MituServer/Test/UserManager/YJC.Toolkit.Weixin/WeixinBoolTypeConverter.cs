using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public sealed class WeixinBoolTypeConverter : ITkTypeConverter
    {
        #region ITkTypeConverter 成员

        public string DefaultValue
        {
            get
            {
                return "N";
            }
        }

        public object ConvertFromString(string text, ReadSettings settings)
        {
            if (string.Compare(text, "Y", StringComparison.OrdinalIgnoreCase) == 0)
                return true;
            return false;
        }

        public string ConvertToString(object value, WriteSettings settings)
        {
            try
            {
                bool boolValue = (bool)value;
                return boolValue ? "Y" : "N";
            }
            catch
            {
                return "N";
            }
        }

        #endregion
    }
}
