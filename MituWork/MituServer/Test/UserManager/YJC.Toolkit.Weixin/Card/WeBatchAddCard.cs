using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeBatchAddCard
    {
        internal WeBatchAddCard()
        {
        }
        public WeBatchAddCard(string cardId, WeCardExt cardExt)
        {
            CardId = cardId;
            CardExt = cardExt.WriteJson();
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; protected set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string CardExt { get; protected set; }
    }
}
