using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeShelfControlInfos
    {
        public WeShelfControlInfos()
        {
            ModuleInfos = new List<AllShelfControlInfo>();
        }

        //public WeModuleInfos(params ModuleBase[] moduleInfos)
        //    : this()
        //{
        //    TkDebug.AssertArgumentNull(moduleInfos, "moduleInfos", null);
        //    ModuleInfos.AddRange(moduleInfos);
        //}

        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public List<AllShelfControlInfo> ModuleInfos { get; private set; }
    }
}
