using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.ThirdParty;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpAppUpdateInfo
    {
        public CorpAppUpdateInfo(CorpApp app)
        {
            AgentId = app.AgentId;
            ReportLocationFlag = app.ReportLocationFlag;
            LogoMediaId = app.LogoMediaId;
            Name = app.Name;
            Description = app.Description;
            RedirectDomain = app.RedirectDomain;
            IsReportUser = app.IsReportUser;
            IsReportEnter = app.IsReportEnter;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int AgentId { get; protected set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeThirdPartyLocationFlag ReportLocationFlag { get; set; }

        [SimpleElement(Order = 50, LocalName = "logo_mediaid")]
        public string LogoMediaId { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Name { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Description { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public string RedirectDomain { get; set; }

        [SimpleElement(Order = 90, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportUser { get; set; }

        [SimpleElement(Order = 100, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportEnter { get; set; }

    }
}
