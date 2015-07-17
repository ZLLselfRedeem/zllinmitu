using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CustomSerialization
{
    [Serializable]
    public class StringData
    {
        public string dataItemOne = "First data block";
        public string dataItemTwo = "More data";

    //    public StringData()
    //    {
    //    }
        [OnSerializing]
        private void OnSerializing(StreamingContext ctx) 
        {
            // Rehydrate member variables from stream.
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext ctx)
        {
            // Fill up the SerializationInfo object with the formatted data.
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }
    }

    [Serializable]
    public class TestStringData : ISerializable
    {
        public string dataItemOne = "First data block";
        public string dataItemTwo = "More data";

        public TestStringData()
        {
        }

        // 实现了ISerializable接口的类型必须定义一个特性的构造函数，这个构造函数传入SerializationInfo和StreamingContext两个参数
        // 以前在反序列化的时候，自动调用该构造函数。
        protected TestStringData(SerializationInfo si, StreamingContext ctx)
        {
            // Rehydrate member variables from stream.
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("HelloWorld").ToLower();
        }

        // 显示实现接口 该方法默认为private
        // the GetObjectData() method is called automatically by a given formatter 
        // during the serialization process
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            // Fill up the SerializationInfo object with the formatted data.
            info.AddValue("HelloWorld", "Hello Serialization".ToUpper());
            info.AddValue("First_Item", dataItemOne.ToUpper());
            //info.AddValue("dataItemTwo", dataItemTwo.ToUpper());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Custom Serialization *****");

            //// Recall that this type implements ISerializable
            //StringData myData = new StringData();

            //// Save to a local file in SOAP format
            //SoapFormatter soapFormat = new SoapFormatter();
            //using (Stream fStream = new FileStream("MyData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    soapFormat.Serialize(fStream, myData);
            //}

            //using (Stream fStream = File.OpenRead("MyData.soap"))
            //{
            //    myData = (StringData)soapFormat.Deserialize(fStream);
            //}

            StringData testData = new StringData();
            SoapFormatter xmlSer = new SoapFormatter();
            using (Stream fStream = new FileStream("TestData.soap", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlSer.Serialize(fStream, testData);
            
            }
            using (Stream fSteam = File.OpenRead("TestData.soap"))
            {
                testData = (StringData)xmlSer.Deserialize(fSteam);
            }
            Console.ReadLine();
        }
    }
}
