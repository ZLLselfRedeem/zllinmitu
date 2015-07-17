using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace ReflectSharedAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** the Shared Asm Reflector App *****\n");
            string displayName = null;
            displayName = "System.Windows.Forms," + "Version=4.0.0.0," + "PublicKeyToken=b77a5c561934e089," + @"Culture=""";
            Assembly asm = Assembly.Load(displayName);
            DisplayInfo(asm);
            Console.WriteLine("Done");
        }

        private static void DisplayInfo(Assembly a) 
        {
            Console.WriteLine("***** Info about Assembly");
            Console.WriteLine("Loaded form GAC?{0}", a.GlobalAssemblyCache);
            Console.WriteLine("Asm Name: {0}", a.GetName().Name);
            Console.WriteLine("Asm Version: {0}", a.GetName().Version);
            Console.WriteLine("Asm Culture: {0}", a.GetName().CultureInfo.DisplayName);

            Console.WriteLine("\n here are the public enums:");
            Type[] types = a.GetTypes();
            var publicEnums = from pe in types
                              where pe.IsEnum && pe.IsPublic
                              select pe;
            foreach(var pe in publicEnums)
                Console.WriteLine(pe);
        }
    }
}
