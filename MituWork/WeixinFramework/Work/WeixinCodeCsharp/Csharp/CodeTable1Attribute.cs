using System;
using YJC.Toolkit.Sys;

namespace Csharp
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class CodeTable1Attribute : BasePlugInAttribute
    {
        public CodeTable1Attribute()
        {
            Suffix = "CodeTable1";
        }

        public override string FactoryName
        {
            get
            {
                return CodeTable1PlugInFactory.REG_NAME;
            }
        }
    }
}
