using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Excel
{
    internal class ImportConfigXml : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit)]
        public ImportConfigItem Import { get; private set; }
    }
}
