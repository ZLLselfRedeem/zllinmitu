using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.ThirdParty;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpApp : CorpAppSimpleInfo
    {
        internal CorpApp()
        {
        }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public WeThirdPartyLocationFlag ReportLocationFlag { get; set; }

        [SimpleElement(Order = 50, LocalName = "logo_mediaid")]
        public string LogoMediaId { get; set; }

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

        [TagElement(Order = 130, LocalName = "allow_userinfos")]
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Lower)]
        public List<CorpUser> User { get; private set; }

        [TagElement(Order = 140, LocalName = "allow_partys")]
        [SimpleElement(IsMultiple = true, LocalName = "partyid")]
        public List<int> PartyIds { get; private set; }

        [TagElement(Order = 150, LocalName = "allow_tags")]
        [SimpleElement(IsMultiple = true, LocalName = "tagid")]
        public List<int> TagIds { get; private set; }

        [SimpleElement(Order = 160, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Close { get; private set; }

        public static CorpApp Query(int agentId)
        {
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.AGENT_GET,
                CorpAccessToken.GetTokenWithSecret(WeixinSettings.Current.CorpUserManagerSecret), agentId);
            CorpApp result = WeUtil.GetFromUri(url, new CorpApp());
            return result;
        }

        public WeixinResult Update()
        {
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.AGENT_SET,
                WeixinSettings.Current.CorpUserManagerSecret);
            CorpAppUpdateInfo updateInfo = new CorpAppUpdateInfo(this);
            WeixinResult result = WeUtil.PostToUri(url, updateInfo.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
