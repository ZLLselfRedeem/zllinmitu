using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class SkuTypeConverter : ITkTypeConverter
    {
        public object ConvertFromString(string text, ReadSettings settings)
        {
            return null;
        }

        public string ConvertToString(object value, WriteSettings settings)
        {
            List<WeProductProperty> lp = (List<WeProductProperty>)value;
            //List<string> ls = new List<string>();
            //foreach (var n in lp)
            //{
            //    ls.Add(n.ToString());
            //}
            //Join<T>(String, IEnumerable<T>) 是一个便利方法，通过它可以串联 IEnumerable<T> 
            //集合的每个成员，无需事先将它们转换为字符串。 IEnumerable<T> 
            //集合中每个对象的字符串表示形式通过调用对象的ToString 方法派生。
            string result = string.Join(";", lp);
            return result;
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
