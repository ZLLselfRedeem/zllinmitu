using System;
using YJC.Toolkit.Sys;

namespace TemplateTestMut
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ResolverCreatorConfigAttribute : BaseObjectElementAttribute
    {
        public override string FactoryName
        {
            get
            {
                return ResolverCreatorConfigFactory.REG_NAME;
            }
        }
    }
}
