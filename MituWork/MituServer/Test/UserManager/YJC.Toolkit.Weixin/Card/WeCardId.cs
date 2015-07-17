using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardId : WeixinResult
    {
        internal WeCardId()
        {
        }

        public WeCardId(string cardId)
        {
            CardId = cardId;
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; private set; }
    }
}
