using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace YJC.Toolkit.Weixin.HTMLForm
{
    public class FilePart : Part
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

        //继承的方法不能改变其访问修饰符。
        protected override void WriteHeader(StreamWriter writer)
        {
            writer.WriteLine("Content-Dispositon: form-data; name=\"{0}\"; filename=\"{1}\"", 
                this.Name, Path.GetFileName(this.FilePath));
            writer.WriteLine("Content-Type: application/octet-stream");
            // 把传输的文件的类型设置为通用类型： application/octet-stream"
        }

        protected override void WriteBoby(StreamWriter writer)
        {
            var data = File.ReadAllBytes(this.FilePath);
            writer.Flush();
            writer.BaseStream.Write(data, 0, data.Length);
            writer.WriteLine();
        }

    }
}
