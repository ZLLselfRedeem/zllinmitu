using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyAllowUserInfo
    {
        [ObjectElement(IsMultiple = true, Order = 10, LocalName = "user")]
        public List<WeThirdPartyUser> Users { get; private set; }
    }
}
