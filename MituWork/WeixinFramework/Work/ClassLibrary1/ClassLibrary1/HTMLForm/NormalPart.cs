using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace YJC.Toolkit.Weixin.HTMLForm
{
    public class NormalPart : Part
    {
        public string Name { get; set; }
        public string Value { get; set; }

        protected override void WriteHeader(StreamWriter writer)
        {
            writer.WriteLine("Content-Dispositon: form-data; name=\"{0}\"", this.Name);
        }

        protected override void WriteBoby(StreamWriter writer)
        {
            writer.WriteLine(this.Value);
        }
    }
}
