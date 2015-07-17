using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class ShelfControlList
    {
        internal ShelfControlList()
        {
            Modules = new List<WeBaseShelfControl>();
        }

        internal ShelfControlList(WeShelfControlInfos wsc)
            : this()
        {
            TkDebug.AssertArgumentNull(wsc, "wsc", null);

            foreach (var v in wsc.ModuleInfos)
                Modules.Add(v.ConvertToShelf());
        }

        public ShelfControlList(params WeBaseShelfControl[] modules)
            : this()
        {
            TkDebug.AssertArgumentNull(modules, "modules", null);
            Modules.AddRange(modules);
        }

        [ObjectElement(IsMultiple = true, LocalName = "module_infos")]
        public List<WeBaseShelfControl> Modules { get; private set; }
    }
}
