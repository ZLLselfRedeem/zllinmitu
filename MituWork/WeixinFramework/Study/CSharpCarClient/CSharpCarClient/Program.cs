using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarLibrary;

namespace CSharpCarClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** C# CarLibrary Client App *****");
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();

            MiniVan mv = new MiniVan();
            mv.TurboBoost();

            Console.WriteLine("Done, Press any key to teminate");
            Console.ReadLine();
        }
    }
}
