using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCodeUpdate : WeCodeUnavailable
    {
        public WeCodeUpdate(string code, string cardId, string newCode)
            : base(code)
        {
            NewCode = newCode;
            CardId = cardId;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string NewCode { get; private set; }
    }
}
