using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeCardId : WeixinResult
    {
        public WeCardId()
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
