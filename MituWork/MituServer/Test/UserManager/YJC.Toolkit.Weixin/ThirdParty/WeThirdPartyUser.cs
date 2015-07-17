using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyUser
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Userid { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Status { get; private set; }
    }
}
