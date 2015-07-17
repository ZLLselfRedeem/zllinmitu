using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace MyFirstCSharpApp
{
    class Tstring 
    {
        public string test;
    }
    struct RefTest 
    {
        public Tstring name;
        public int age;
    }

    enum Colors
    {
        Red = 0,
        Yellow = 1,
        Black = 2,
        Green = 3,
        White = 4,
        Gray = 300
    }

    class Program
    {
        static void Main(string[] args)
        {
            //for (int i =0; i < args.Length; i++) 
            //{
            //    Console.WriteLine("Arg:{0}", args[i]);
            //}

            //foreach (var v in args) 
            //{
            //    Console.WriteLine("Arg:{0}", v);
            //}

            //string[] theArgs = Environment.GetCommandLineArgs();
            //foreach (var v in theArgs)
            //    Console.WriteLine("Arg:{0}", v);
            Colors background = Colors.Gray;
            Colors frontcolor = (Colors)300;
            Console.WriteLine(Enum.GetUnderlyingType(background.GetType()));
            Array enumData = Enum.GetValues(typeof(Colors));
            Console.WriteLine(enumData.GetType().Name);
            for (int i = 0; i < enumData.Length; ++i) 
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",enumData.GetValue(i));
            }

            RefTest rt1 = new RefTest() { name = new Tstring() { test = "zll"}, age = 26 };
            RefTest rt2 = rt1;
            rt2.name.test = "zyd";
            rt2.age = 20;
            Console.WriteLine("Name: {0}, Value: {1}", rt1.name.test, rt1.age);
            Console.WriteLine("Name: {0}, Value: {1}", rt2.name.test, rt2.age);
        }

        private static void testArray(int[] testarray) 
        {
            for (int i = 0; i < testarray.Length; ++i) 
            {
                testarray[i] *= 2; 
            }
        }

        private static int Add(int x, int y) 
        {
            return x + y; 
        }

        private static double Add(double x, double y)
        {
            return x + y;
        }

        private static long Add(long x, long y) 
        {
            return x + y;
        }

        private static void SwitchEnumExample() 
        {
            Console.WriteLine("Enter your favorite day of the week:");
            DayOfWeek favDay;
            try 
            {
                favDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bad input");
                return;
            }

            switch (favDay) 
            {
                case DayOfWeek.Friday:
                    Console.WriteLine("Yes, Friday rules");
                    break;
                case DayOfWeek.Monday:
                    Console.WriteLine("Yes, Friday rules");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("Yes, Friday rules");
                    break;
            }
        }
        private static void LingQueryInts() 
        {
            int[] numbers = { 10, 2, 3, 17, 98, 64, 7, 9, 4, 14 };
            var subset = from i in numbers
                         where i > 10
                         select i;
            foreach (int i in subset)
                Console.WriteLine(i);
            Console.WriteLine();
            var type = subset.GetType().Name;
            Console.WriteLine("subset is a {0}", type);
            Console.WriteLine("subse is defined in {0}", subset.GetType().Namespace);
        }
        private static void EcapeChars() 
        {
            Console.WriteLine("=> Escape characters: \a");
            string strWithTabs = "Modele\tColor\tSpeed\tPet Name\a";
            Console.WriteLine(strWithTabs);
            Console.WriteLine(@"\MyApp\Wechate\xml");
            string myLongString = @"This is a
                very
                        very
                                very 
                                        long string";
            Console.WriteLine(myLongString);
            string test = @"ta shuo ""wo shi yi ge hao hai zi !""";
            Console.WriteLine(test);
        }

        private static void UseStringFormat()
        {
            Console.WriteLine("The value 99999 in various formats:");
            Console.WriteLine("c format: {0:c}", 99999);
            Console.WriteLine("d9 format: {0:d}", 99999);
            Console.WriteLine("f3 format: {0:f3}", 99999);
            Console.WriteLine("n format: {0:n}", 99999);

            Console.WriteLine("e format: {0:e}", 99999);
            Console.WriteLine("E format: {0:E}", 99999);
            Console.WriteLine("x format: {0:x}", 99999);
            Console.WriteLine("X format: {0:X}", 99999);
        }

        private static void UseBigInteger()
        {
            Console.WriteLine("=> Use BIgInteger:");
            BigInteger biggy = BigInteger.Parse("999999999999999999999999999999999999999999999999999");
            Console.WriteLine("Value of biggy is {0}", biggy);
            Console.WriteLine("Is biggy an even value?: {0}", biggy.IsEven);
            Console.WriteLine("Is biggy a power of two?: {0}", biggy.IsPowerOfTwo);
            BigInteger reallyBig = BigInteger.Multiply(biggy, BigInteger.Parse("888888888888888888888888888888888888888888888888888888888888888"));
            Console.WriteLine("Value of reallyBig is {0}", reallyBig);
        }

        static void ShowEnvironmentDetails() 
        {
            foreach (string drive in Environment.GetLogicalDrives())
                Console.WriteLine("Derive: {0}", drive);

            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version: {0}", Environment.Version);
        }

        static void DataTypeFunctionality() 
        {
            Console.WriteLine("Max of int: {0}", int.MaxValue);
            Console.WriteLine("Min of int: {0}", int.MinValue);
            Console.WriteLine("Max of double: {0}", double.MaxValue);
            Console.WriteLine("Min of double: {0}", double.MinValue);
            Console.WriteLine("double.Epsilon: {0}", double.Epsilon);
            Console.WriteLine("double.PositiveInfinity: {0}", double.PositiveInfinity);
            Console.WriteLine("double.NegativeInfinity: {0}", double.NegativeInfinity);
            Console.WriteLine("bool.FalseString: {0}", bool.FalseString);

            bool b = bool.Parse("true");

            Console.WriteLine(b);
        }
    }
}
