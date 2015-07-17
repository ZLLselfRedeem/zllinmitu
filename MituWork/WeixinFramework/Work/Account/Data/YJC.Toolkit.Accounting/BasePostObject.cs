using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    public abstract class BasePostObject
    {
        protected BasePostObject()
        {
        }

        [ObjectElement]
        public ReportInfo Info { get; set; }

        public abstract string WriteXml();
    }
}
