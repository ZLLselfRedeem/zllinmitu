using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace SimpleSerialize
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioId = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    // 注意Serializable特性时不可继承的
    // 可以从Serializable特性类的定义中可以看到 Inherited=false
    [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car
    {
        public JamesBondCar()
        {
 
        }

        public JamesBondCar(bool skyWorthy, bool seaWorthy)
        {
            canFly = skyWorthy;
            canSubmerge = seaWorthy;
        }

        [XmlAttribute]
        public bool canFly;
        private bool canSubmerge;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Serialization ******\n");
            // Make a JamesBondCar and set state
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;

            jbc.theRadio.stationPresets = new double[] { 89.3, 105.1, 97.1 };
            jbc.theRadio.hasTweeters = true;

            List<JamesBondCar> myCars = new List<JamesBondCar>();
            myCars.Add(new JamesBondCar(true, true));
            myCars.Add(new JamesBondCar(true, false));
            myCars.Add(new JamesBondCar(false, false));
            SavedAsXmlFormats(myCars, "CarCollection.xml");

            // now save the car to a specific file in a binary format
            SavedAsXmlFormat(jbc, "CarData.xml");
            BinaryFormatter binFormat = new BinaryFormatter();
            // read the JamesBondCar From the binary file
            //using (Stream fStream = File.OpenRead("CarData.soap"))
            //{
            //    JamesBondCar carFromDis = (JamesBondCar)binFormat.Deserialize(fStream);
            //    Console.WriteLine("Can this car fly? : {0}", carFromDis.canFly);
            //}

            Console.ReadLine();
        }

        private static void SavedAsXmlFormats(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<JamesBondCar>));
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }

        private static void SavedAsXmlFormat(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }
        private static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream(fileName, 
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in SOAP format");
        }

        private static void SaveAsBinaryFormat(object objGraph, string fileName)
        { 
            // Save object to a file named CarData.dat in binary
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in binary format!");
        }
    }
}
