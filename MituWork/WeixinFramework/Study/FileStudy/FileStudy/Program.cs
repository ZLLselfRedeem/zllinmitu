using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** Simple I/O with the File Type ******\n");
            string[] myTasks = { "Fix bathroom", "Call Dave", "Call Mon and Dad", "Play Xbox 360" };

            //Write out all data to file on C drive
            File.WriteAllLines(@"D:\tasks.txt", myTasks);

            // Read it all back and print out
            foreach (string task in File.ReadAllLines(@"D:\tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }

            foreach (char ch in File.ReadAllText(@"D:\tasks.txt"))
            {
                Console.WriteLine("Todo: {0}", ch);
            }
            Console.ReadLine();
        }
    }
}
