using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeMembercardActivate : WeCodeUnavailable
    {
        public WeMembercardActivate(string code, string membershipNumber)
            : base(code)
        {
            MembershipNumber = membershipNumber;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int InitBonus { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int InitBalance { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Bonus { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public string Balance { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string MembershipNumber { get; private set; }
    }
}
