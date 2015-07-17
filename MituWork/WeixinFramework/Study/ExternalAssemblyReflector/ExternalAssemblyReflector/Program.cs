using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach(Type t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            //AssemblyName asmName = new AssemblyName();
            //asmName.Name = "CarLibrary";
            //Version v = new Version("1.0.0.0");
            //asmName.Version = v;
            //Assembly asbly = Assembly.Load(asmName);

            Console.WriteLine("***** External Assembly Viewer *****");
            string asmName = "";
            Assembly asm = null;

            do
            {
                Console.WriteLine("\nEnter an assembly to evaluate");
                Console.Write("Or enter Q to quit: ");
                asmName = Console.ReadLine();
                if (asmName.ToUpper() == "Q") 
                {
                    break;
                }

                try
                {
                    asm = Assembly.Load(asmName);
                    //可以用Assembly.LoadFrom()实现同样的功能，同时该方法可以传入要查看的
                    //程序集的绝对路径
                    asm = Assembly.LoadFrom(asmName);

                    DisplayTypesInAsm(asm);
                }
                catch 
                {
                    Console.WriteLine("Sorry, can't find assembly");
                }
            } while (true);
        }
    }
}
