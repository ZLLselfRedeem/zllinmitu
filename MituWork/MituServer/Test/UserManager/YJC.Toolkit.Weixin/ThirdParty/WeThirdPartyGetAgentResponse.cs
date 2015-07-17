using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyGetAgentResponse : WeixinResult
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int Agentid { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string SquareLogoUrl { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string RoundLogoUrl { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

        [ObjectElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyAllowUserInfo AllowUserinfos { get; private set; }

        [ObjectElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyPartyids AllowPartys { get; private set; }

        [ObjectElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public WeThirdPartyTagids AllowTags { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Close { get; private set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string RedirectDomain { get; private set; }

        [ObjectElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeThirdPartyLocationFlag ReportLocationFlag { get; private set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportUser { get; private set; }
    }
}
