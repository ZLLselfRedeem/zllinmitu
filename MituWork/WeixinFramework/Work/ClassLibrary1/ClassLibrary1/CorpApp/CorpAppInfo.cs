using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.ThirdParty;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpAppInfo : WeixinResult
    {
        private CorpAppInfo()
        {
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int AgentId { get; protected set; }

        [SimpleElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeThirdPartyLocationFlag ReportLocationFlag { get; set; }

        //[SimpleElement(Order = 50, LocalName = "logo_mediaid")]
        //public string LogoMediaId { get; set; }
        
        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public string Name { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.Lower)]
        public string Description { get; set; }

        [SimpleElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public string RedirectDomain { get; set; }

        [SimpleElement(Order = 140, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportUser { get; set; }

        [SimpleElement(Order = 150, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsReportEnter { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string SquareLogoUrl { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string RoundLogoUrl { get; private set; }

        [TagElement(Order = 80, LocalName = "allow_userinfos")]
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Lower)]
        public List<CorpUser> User { get; private set; }

        [TagElement(Order = 90, LocalName = "allow_partys")]
        [SimpleElement(IsMultiple = true, LocalName = "partyid")]
        public List<int> PartyIds { get; private set; }

        [TagElement(Order = 100, LocalName = "allow_tags")]
        [SimpleElement(IsMultiple = true, LocalName = "tagid")]
        public List<int> TagIds { get; private set; }

        [SimpleElement(Order = 110, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Close { get; private set; }

        public static CorpAppInfo Query(int agentId)
        {
            string url = string.Format(ObjectUtil.SysCulture, CorpAppConst.AGENT_GET, 
                CorpAccessToken.GetTokenWithSecret(WeixinSettings.Current.CorpUserManagerSecret), agentId);
            CorpAppInfo result = WeUtil.GetFromUri(url, new CorpAppInfo());
            return result;
        }

        public static WeixinResult Update(int agentId, WeThirdPartyLocationFlag locationFlag, 
            string mediaId, string desc, string rdomain, bool isReportUser, bool isReportEnter)
        {
            CorpAppUpdate agentUpdate = new CorpAppUpdate(agentId)
            {
                ReportLocationFlag = locationFlag,
                LogoMediaId = mediaId,
                Description = desc,
                RedirectDomain = rdomain,
                IsReportUser = isReportUser,
                IsReportEnter = isReportEnter
            };
            return agentUpdate.Update();
        }

        public static IEnumerable<CorpAgentBrief> GetAgents()
        {
            string url = WeCorpUtil.GetCorpUrl(CorpAppConst.AGENT_LIST, WeixinSettings.Current.CorpUserManagerSecret);
            return WeUtil.GetFromUri(url, new CorpAppList()).AgentList;
        }
    }
}
