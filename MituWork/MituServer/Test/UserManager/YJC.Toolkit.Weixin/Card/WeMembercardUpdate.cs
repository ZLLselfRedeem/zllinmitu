using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeMembercardUpdate : WeCodeUnavailable
    {
        public WeMembercardUpdate(string code)
            : base(code)
        {
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string RecordBonus { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int AddBonus { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public int AddBalance { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string RecordBalance { get; set; }
    }
}
