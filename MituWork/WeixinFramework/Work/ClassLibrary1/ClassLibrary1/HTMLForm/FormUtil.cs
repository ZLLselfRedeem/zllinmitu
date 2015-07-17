using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace YJC.Toolkit.Weixin.HTMLForm
{
    public static class FormUtil
    {
        private static void Write(StreamWriter writer, IEnumerable<Part> parts)
        {
            var guidBytes = Guid.NewGuid().ToByteArray();
            var boundary = "----------------" + Convert.ToBase64String(guidBytes);

            foreach (var p in parts)
            {
                writer.WriteLine(boundary);
                p.Writer(writer);
            }

            writer.WriteLine(boundary + "--");
        }

        // 
        public static void PostForm(Uri postUrl, string contentTyep, byte[] formData)
        { 
        }
    }
}
