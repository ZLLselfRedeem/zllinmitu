using System.Drawing;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    class ColorTypeConverter : ITkTypeConverter
    {
        #region ITkTypeConverter 成员

        public string DefaultValue
        {
            get
            {
                return "#000000";
            }
        }

        public object ConvertFromString(string text, ReadSettings settings)
        {
            return ColorTranslator.FromHtml(text);
        }

        public string ConvertToString(object value, WriteSettings settings)
        {
            try
            {
                Color c = (Color)value;
                return "#" + c.R.ToString("X2", null) + c.G.ToString("X2", null)
                    + c.B.ToString("X2", null);
            }
            catch
            {
                return DefaultValue;
            }
        }

        #endregion
    }
}
