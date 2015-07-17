using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyTagids
    {
        [SimpleElement(IsMultiple = true, Order = 10, LocalName = "tagid")]
        public List<int> Tagids { get; private set; }
    }
}
