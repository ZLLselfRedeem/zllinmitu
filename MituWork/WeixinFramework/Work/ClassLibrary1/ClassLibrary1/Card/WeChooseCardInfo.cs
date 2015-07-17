using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeChooseCardInfo
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string EncryptCode { get; private set; }
    }
}
