using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRecalllCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex"+"2");
            sb.Append(2);
            sb.Append(true);
            sb.Replace("2", "two");
            Console.WriteLine(sb.ToString());
        }
    }
}
