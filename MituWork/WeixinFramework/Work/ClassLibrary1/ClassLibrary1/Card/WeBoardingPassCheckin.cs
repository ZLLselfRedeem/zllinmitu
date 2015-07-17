using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeBoardingPassCheckin : WeCodeUnavailable
    {
        public WeBoardingPassCheckin(string code, string passageName, string classType, string etktBnr)
            : base(code)
        {
            PassengerName = passageName;
            CabinClass = classType;
            EtktBnr = etktBnr;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PassengerName { get; private set; }

        [SimpleElement(Order = 40, LocalName = "class")]
        public string CabinClass { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.Lower)]
        public string Seat { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string EtktBnr { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string QrcodeData { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        public bool IsCancel { get; set; }
    }
}
