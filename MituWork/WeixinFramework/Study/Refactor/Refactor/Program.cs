using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // 建立Console UI(CUI)
            ConfigureCUI();
            Console.ReadKey();
        }

        private static void ConfigureCUI()
        {
            Console.Title = "My Rocking App";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("#######################################");
            Console.WriteLine("##### Welcome to My Rocking App #######");
            Console.WriteLine("#######################################");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
