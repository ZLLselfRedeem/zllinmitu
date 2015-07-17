using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyAuthCorp
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string Corpid { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string CorpName { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public WeThirdPartyCorpType CorpType { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string CorpRoundLogoUrl { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public string CorpSquareLogoUrl { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public int CorpUserMax { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public int CorpAgentMax { get; private set; }
    }
}
