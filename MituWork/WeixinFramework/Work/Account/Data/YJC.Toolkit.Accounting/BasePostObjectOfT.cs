using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    public class BasePostObject<T> : BasePostObject where T : new()
    {
        private static readonly WriteSettings Settings = new WriteSettings { Encoding = Encoding.Default };

        [ObjectElement]
        public T ReportData { get; protected set; }

        public override string WriteXml()
        {
            if (ReportData == null)
                return string.Empty;
            return ReportData.WriteXml(Settings, QName.ToolkitNoNS);
        }
    }
}
