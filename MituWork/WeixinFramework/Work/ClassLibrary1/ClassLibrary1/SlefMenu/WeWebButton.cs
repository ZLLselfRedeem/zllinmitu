using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeWebButton : WeWebSubButton
    {
        [TagElement(Order = 60, LocalName = "sub_button")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<WeWebSubButton> ButtonList { get; private set; }

    }
}
