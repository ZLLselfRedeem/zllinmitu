using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AppConfigReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppSettingsReader ar = new AppSettingsReader();
            int numbOfTimes = (int)ar.GetValue("RepeatCount", typeof(int));
            string textColor = (string)ar.GetValue("TextColor", typeof(string));
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), textColor);

            ConsoleColor cs = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Blue;
            for(int i = 0; i < numbOfTimes; i++)
                Console.WriteLine("Howdy!");

            Console.BackgroundColor = cs;
            Console.ReadLine();
        }
    }
}
