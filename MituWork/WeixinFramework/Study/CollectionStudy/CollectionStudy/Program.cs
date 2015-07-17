using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CollectionStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] strArray = { "First", "Second", "Third" };
            //Console.WriteLine("This array has {0} items", strArray.Length);
            //Console.WriteLine();

            //foreach (string s in strArray) 
            //{
            //    Console.WriteLine("Array Entry: {0}", s);
            //}

            //Console.WriteLine();
            //Array.Reverse(strArray);

            //foreach (string s in strArray)
            //{
            //    Console.WriteLine("Array Entry: {0}", s);
            //}

            // Working with the ArrayList
            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] { "First", "Second", "Third" });
            Console.WriteLine("This collection has {0} items.", strArray.Count);
            strArray.Add("string");
            Console.WriteLine("This collection now has {0} items", strArray.Count);
            foreach (string s in strArray) 
            {
                Console.WriteLine("Entry: {0}", s);
            }
            Console.ReadLine();
        }
    }
}
