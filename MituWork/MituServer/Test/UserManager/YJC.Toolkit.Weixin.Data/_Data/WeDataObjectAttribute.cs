using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal sealed class WeDataObjectAttribute : BasePlugInAttribute
    {
        public WeDataObjectAttribute()
        {
            Suffix = "Retriever";
        }

        public override string FactoryName
        {
            get
            {
                return WeDataObjectPlugInFactory.REG_NAME;
            }
        }
    }
}
