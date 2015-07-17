using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyPartyids
    {
        [SimpleElement(IsMultiple = true, Order = 10, LocalName = "pratyid")]
        public List<int> Partyids { get; private set; }
    }
}
