using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StreamWriterReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with StreamWriter/StreamReader *****\n");
            // Get a StreamWriter and wirte string data.
            // 下面两行是等价的 
            // using(StreamWriter write = new StreamWriter("reminders.txt"))
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("Don't forget bring in boook...");
                writer.Write("hello!");
                writer.WriteLine("Text!?");
                writer.WriteLine("Don't forget thest number:");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Created file and wrote some thoungts...");
            Console.WriteLine("Here are your thoughts:\n");
            // using(StreamReader reader = new StreamReader("reminders.txt"))
            using (StreamReader reader = File.OpenText("reminders.txt"))
            {
                string input = null;
                while((input = reader.ReadLine())!= null)
                {
                    Console.WriteLine(input);
                }
            }

            //
            // StringWirter/StringReader
            //
            Console.WriteLine("***** Fun with StringWriter/StringReader *****\n");
            //carete a StringWriter and emit character data to memory
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                strWriter.WriteLine("you are my mother!!");
                Console.WriteLine("Contents of StringWriter:\n{0}", strWriter);

                // Get the internal Stringbuilder
                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "HeyZ!!! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey!!! ".Length);
                Console.WriteLine("-> {0}", sb.ToString());

                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }

            //
            // Binary Writers / Readers 
            //

            Console.WriteLine("****** Fun with Binary Writers / Readers *****\n");
            // Open a binary writer for a file
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                // Print out the type of BaseStream.
                // (System.IO.FileStream in this case).
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);
                // Create some data to save in the file
                double aDouble = 1234.77;
                double testDouble = 12.0230;
                int anInt = 23563;
                string aString = "A, B, C";
                // Write the data
                bw.Write(aDouble);
                bw.Write(testDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }

            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}
