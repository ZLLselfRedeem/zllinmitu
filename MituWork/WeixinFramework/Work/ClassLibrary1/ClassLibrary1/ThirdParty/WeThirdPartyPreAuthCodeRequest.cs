using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal class WeThirdPartyPreAuthCodeRequest
    {
        public WeThirdPartyPreAuthCodeRequest()
        {
            SuiteId = "id_value";
        }

        public WeThirdPartyPreAuthCodeRequest(string[] Ids)
            : this()
        {
            Appid = new List<string>(Ids);
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteId { get; private set; }

        [SimpleElement(IsMultiple = true, Order = 20, NamingRule = NamingRule.Lower)]
        public List<string> Appid { get; private set; }
    }
}
