using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public sealed class WeixinDateTimeConverter : ITkTypeConverter
    {
        #region ITkTypeConverter 成员

        public string DefaultValue
        {
            get
            {
                return WeUtil.ToCreateTime(DateTime.Now).ToString(ObjectUtil.SysCulture);
            }
        }

        public object ConvertFromString(string text, ReadSettings settings)
        {
            try
            {
                int value = int.Parse(text, ObjectUtil.SysCulture);
                return WeUtil.ToDateTime(value);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public string ConvertToString(object value, WriteSettings settings)
        {
            try
            {
                DateTime date = (DateTime)value;
                return WeUtil.ToCreateTime(date).ToString(ObjectUtil.SysCulture);
            }
            catch
            {
                return DefaultValue;
            }
        }

        #endregion
    }
}
