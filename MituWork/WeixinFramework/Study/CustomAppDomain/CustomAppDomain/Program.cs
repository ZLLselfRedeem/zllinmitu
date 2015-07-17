using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CustomAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;
            ListAllAssembliesInAppDomain(defaultAD);

            MakeNewAppDomain();
            Console.ReadLine();
        }

        private static void MakeNewAppDomain() 
        {
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (o, s) =>
                {
                    Console.WriteLine("The second AppDomain has been unloaded");
                };
            try
            {
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            ListAllAssembliesInAppDomain(newAD);

            AppDomain.Unload(newAD);
        }

        static void ListAllAssembliesInAppDomain(AppDomain defaultAD)
        {
            Console.WriteLine("***** Here are the assemblies loaded in {0} *****\n",defaultAD.FriendlyName);
            var laLinq = from llq in defaultAD.GetAssemblies()
                         orderby llq.GetName().Name
                         select string.Format("->Name: {0},Version: {0}\n", 
                         llq.GetName().Name, llq.GetName().Version);
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
    }
}
