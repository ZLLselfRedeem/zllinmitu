using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyAgentSet
    {
        public WeThirdPartyAgentSet(int agentid, WeThirdPartyLocationFlag reportLocationFlag,
            string logoMediaid, string name, string description, string redirectDomain, bool isReportUser)
        {
            Agentid = agentid;
            ReportLocationFlag = reportLocationFlag;
            LogoMediaid = logoMediaid;
            Name = name;
            Description = description;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Agentid { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeThirdPartyLocationFlag ReportLocationFlag { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string LogoMediaid { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Description { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string RedirectDomain { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportUser { get; private set; }
    }
}
