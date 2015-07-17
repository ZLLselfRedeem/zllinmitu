using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeLuckyMoneyUpdate : WeCodeUnavailable
    {
        public WeLuckyMoneyUpdate(string code, int balance)
            : base(code)
        {
            Balance = balance;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int Balance { get; private set; }
    }
}
