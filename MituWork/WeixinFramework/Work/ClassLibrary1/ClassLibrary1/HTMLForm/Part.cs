using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YJC.Toolkit.Weixin.HTMLForm
{
    public abstract class Part
    {
        protected Part()
        {
        }

        protected abstract void WriteHeader(StreamWriter writer);
        protected abstract void WriteBoby(StreamWriter writer);

        public void Writer(StreamWriter writer)
        {
            this.WriteHeader(writer);
            writer.WriteLine();
            this.WriteBoby(writer);
        }
    }
}
