using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace DefaultAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("与默认应用程序域进行交互");
            ListAllAssembliesInAppDomain();
        }

        private static void DisplayDADStats()
        {
            // 通过该属性获得默认的应用程序域
            AppDomain defaultAD = AppDomain.CurrentDomain;
            Console.WriteLine("Name of this domain: {0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in the process: {0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain: {0}", defaultAD.IsDefaultAppDomain());
            Console.WriteLine("Base directory of this domain: {0}", defaultAD.BaseDirectory);
        }

        static void ListAllAssembliesInAppDomain()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            var laLinq = from llq in defaultAD.GetAssemblies()
                         orderby llq.GetName().Name
                         select string.Format("->Name: {0},Version: {0}\n", llq.GetName().Name, llq.GetName().Version);
            foreach (var lq in laLinq)
            {
                Console.WriteLine(lq);
                //}
                //Assembly[] la = defaultAD.GetAssemblies();
                //foreach (Assembly ab in la)
                //{
                //    Console.WriteLine("->Name: {0}", ab.GetName().Name);
                //    Console.WriteLine("->Version: {0}", ab.GetName().Version);
                //}
            }
        }
        private static void InitDAD()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            defaultAD.AssemblyLoad += (o, s) =>
                {
                    Console.WriteLine("{0} has been loaded!", s.LoadedAssembly.GetName().Name);
                };
        }
    }
}
