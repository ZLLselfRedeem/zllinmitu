using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticProperty
{
    class Program
    {
        private static int fPrice;
        public static int Price 
        {
            get
            {
                Console.WriteLine(" I am Running!");
                fPrice = 5;
                return 5;
            }

        }

        static void Main(string[] args)
        {
            Program pg = new Program();
            Console.WriteLine(Program.Price);
        }
    }
}
