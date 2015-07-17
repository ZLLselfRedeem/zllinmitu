using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialization
{
    class Program
    {
        private static byte[] ReadFile(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin); // 文件指针设置到文件的开头
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch 
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                {
                    pFileStream.Close();
                }
            }
        }

        //使用反序列化手段进行
        private static void DeSerializeByteArray(byte[] source, string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = File.OpenWrite(fileName))
            {
                formatter.Deserialize(new MemoryStream(source));
            }
        }

        //写byte[] 到fileName
        private static bool writeFile(byte[] buffer, string fileName)
        {
            //using(FileStream fs = File.OpenWrite(fileName))
            //{
            //    fs.Write(buffer, 0, buffer.Length);
            //}
            //return true;
            
            // using语法与try-catch-finally 语法之间的比较。
            // try-catch-finally 在过程中可以更好的控制，监视。
            FileStream jpgFile = null;
            try
            {
                jpgFile = new System.IO.FileStream(@"D:\WebPage\reWeb.jpg", FileMode.Create);
                jpgFile.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                return false;
            }
            finally
            {
                jpgFile.Close();
            }
            return true;

        }
        static void Main(string[] args)
        {
            string fileName = @"D:\前端\Img\HeadImg.jpg";
            byte[] buffer = ReadFile(fileName);
            string rFileName = @"D:\前端\Img\return.jpg";
            bool fileResult = writeFile(buffer, rFileName);

            int[] iArray = new int[0];
            int[] tArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            iArray = tArray;
        }
    }
}
