using YJC.Toolkit.Collections;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.UserTool
{
    internal class ApplicationXml : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "Database")]
        [TagElement(NamespaceType.Toolkit)]
        public RegNameList<DbContextConfig> Databases { get; protected set; }
    }
}