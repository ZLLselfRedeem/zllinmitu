using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.ThirdParty;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpAppUpdate
    {
        public CorpAppUpdate(int agentid)
        {
            AgentId = agentid;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int AgentId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeThirdPartyLocationFlag ReportLocationFlag { get; set; }

        [SimpleElement(Order = 30, LocalName = "logo_mediaid")]
        public string LogoMediaId { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Name { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Description { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string RedirectDomain { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportUser { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportEnter { get; set; }

        public WeixinResult Update()
        {
            string url = WeCorpUtil.GetCorpUrl(CorpAppConst.AGENT_SET, WeixinSettings.Current.CorpUserManagerSecret);
            WeixinResult result = WeUtil.PostToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
