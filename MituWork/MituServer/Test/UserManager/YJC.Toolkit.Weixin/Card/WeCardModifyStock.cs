using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardModifyStock
    {
        public WeCardModifyStock(string cardId)
        {
            CardId = cardId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int? IncreaseStockValue { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public int? ReduceStockValue { get; set; }
    }
}
