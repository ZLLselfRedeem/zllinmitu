using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace ContractSerializer
{
    //data contract name
    // data contract namespace
    [DataContract(Name = "Candidate", Namespace = "http://orilly.com/nutshell")]
    public class Person
    {
        [DataMember(Name = "FirstName")]
        public string Name;
        [DataMember(Name = "ClaimeAge")]
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Name = "曾小丹", Age = 18 };
            var ds = new DataContractSerializer(typeof(Person));
            var s = new MemoryStream();
            using (XmlDictionaryWriter w = XmlDictionaryWriter.CreateBinaryWriter(s))
            {
                ds.WriteObject(w, p);
            }

            var s2 = new MemoryStream(s.ToArray());
            Person p2;
            using (XmlDictionaryReader r = XmlDictionaryReader.CreateBinaryReader(s2, XmlDictionaryReaderQuotas.Max))
            {
                p2 = (Person)ds.ReadObject(r);
            }
            //XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            //using (XmlWriter w = XmlWriter.Create(@"D:\WebPage\Img\perosn.xml", settings))
            //{
            //    ds.WriteObject(w, p);
            //}
            System.Diagnostics.Process.Start(@"D:\WebPage\Img\perosn.xml");
            // 使用程序打开该文件？！
            //using (Stream s = File.Create(@"D:\WebPage\Img\perosn.xml"))
            //{
            //    ds.WriteObject(s, p);
            //}

            Person p2;
            using (Stream s = File.OpenRead(@"D:\WebPage\Img\perosn.xml"))
            {
                p2 = (Person)ds.ReadObject(s);
            }
            Console.WriteLine(p2.Name + "" + p2.Age);
        }
    }
}
