using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeChooseCard
    {
        public WeChooseCard(string appId, DateTime timeStamp, CardType cardType)
        {
            string apiTicket = WeCardInfo.ApiTicketGet(cardType);
            AppId = appId;
            NonceStr = "";
            SignType = "SHA1";
            CardSign = "";
            TimeStamp = timeStamp;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string AppId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public int LocationId { get; set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string SignType { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public string CardSign { get; private set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime TimeStamp { get; private set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public string NonceStr { get; private set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; set; }

        [SimpleElement(Order = 80, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(WeCardTypeConverter))]
        public CardType? CardType { get; set; }
    }
}
