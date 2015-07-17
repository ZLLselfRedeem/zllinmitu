using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.IO;

namespace SerializationAll
{
    // To make an object available to .NET serialization services, 
    // all you need to do is decorate each related class with the [Serialization] attribute
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioID = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio theRadio = new Radio();
        public bool isHatchBack;
    }

    // you cannot inherit the [Serializable] attribute from a parent class.
    [Serializable]
    public class JamesBondCar : Car 
    {
        public bool cnaFly;
        public bool canSUbmerge;
    }

    [Serializable]
    public class UserPrefs
    {
        public string WindowColor;
        public int FontSize;
    }

    [Serializable]
    public class Person
    {

        public bool isAlive = true;

        private int personAge = 21;

        // 这个字段在BinaryFormater和SoapFormatter进行序列化的时候显示出来
        // 而被XmlSerialize序列化中不存在这个private 字段。
        private string fName = "Hello HanMM";
        public string FirstName 
        {
            get { return fName; }
            set { fName = value; }
        }
    }

    class Program
    {
        static void PersisUser()
        {
            List<JamesBondCar> myCars = new List<JamesBondCar>();

            XmlSerializer xmlSer = new XmlSerializer(typeof(Person));
            Person ps = new Person();
            using (Stream fStream = new FileStream("Person.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSer.Serialize(fStream, ps);
            }

            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("Person.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, ps);
            }

            BinaryFormatter binFormat = new BinaryFormatter();
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yelllow";
            userData.FontSize = 50;
            //Store object in a local file
            using (Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }
        }
        static void Main(string[] args)
        {
            PersisUser();
        }
    }
}
