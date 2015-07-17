using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class MessageLogConfigAttribute : BaseObjectElementAttribute
    {
        public override string FactoryName
        {
            get
            {
                return MessageLogConfigFactory.REG_NAME;
            }
        }
    }
}
