using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyAuth
    {
        [ObjectElement(IsMultiple = true, Order = 10, LocalName = "agent")]
        public List<WeThirdPartyAgent> Agents { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 20, LocalName = "department")]
        public List<WeThirdPartyDepartment> Departments { get; private set; }
    }
}
