using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Menu
{
    public class WeAPIButton : WeAPISubButton
    {
        [TagElement(Order = 50, LocalName = "sub_button")]
        [ObjectElement(IsMultiple = true, LocalName = "list")]
        public List<WeAPISubButton> ButtonList { get; private set; }
    }
}
