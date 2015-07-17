using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringFormatTest
{
    class Person 
    {
        public string Name { get; set; }
        
        public override string ToString()
        {
            return Name;
        }

        public string ToString(string format) 
        {
            switch (format) 
            {
                case "UPP":
                    return Name.ToUpper();
                case "LOW":
                    return Name.ToLower();
                default:
                    return Name + "1";
            }
        }
    }

    public class Person2 : IFormattable 
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        #region IFormattable Members
        public string ToString(string format, IFormatProvider formatProvider) 
        {
            if (string.IsNullOrEmpty(format))
                return ToString();
            switch (format) 
            {
                case "UPP":
                    return Name.ToUpper();
                case "LOW":
                    return Name.ToLower();
                default:
                    return Name;
            }
        }
        #endregion
    }

    public class Person3 : IFormattable
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        #region IFormattable Members
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                return ToString()+"Hello";
            switch (format)
            {
                case "UPP":
                    return Name.ToUpper();
                case "LOW":
                    return Name.ToLower();
                default:
                    return Name+"IFormattable Method";
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person3 ps = new Person3() { Name = "Fuhongchang" };
            string test = string.Format("I am {0}", ps);
            Console.WriteLine(test);
        }
    }
}
