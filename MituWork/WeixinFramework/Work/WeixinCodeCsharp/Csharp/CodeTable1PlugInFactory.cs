using System;
using YJC.Toolkit.Sys;

namespace Csharp
{
    public class CodeTable1PlugInFactory : BasePlugInFactory
    {
        public const string REG_NAME = "_tk_CodeTable1";
        private const string DESCRIPTION = "CodeTable1插件工厂";

        public CodeTable1PlugInFactory()
            : base(REG_NAME, DESCRIPTION)
        {
        }
    }
}
