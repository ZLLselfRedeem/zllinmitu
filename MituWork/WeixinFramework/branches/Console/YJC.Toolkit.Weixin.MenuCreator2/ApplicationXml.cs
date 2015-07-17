using System.Collections.Generic;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.MenuCreator
{
    internal class ApplicationXml : ToolkitConfig
    {
        [TagElement(NamespaceType.Toolkit)]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "Host")]
        public List<HostConfigItem> Hosts { get; protected set; }
    }
}