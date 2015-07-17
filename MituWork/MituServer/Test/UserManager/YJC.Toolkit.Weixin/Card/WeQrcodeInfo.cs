using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeQrcodeInfo
    {
        public WeQrcodeInfo(string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(cardId, "cardId", null);

            CardId = cardId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Code { get; set; }

        [SimpleElement(Order = 30, LocalName = "openid")]
        public string OpenId { get; set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public int? ExpireSeconds { get; set; }

        [SimpleElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public bool IsUniqueCode { get; set; }

        [SimpleElement(Order = 60, NamingRule = NamingRule.Lower)]
        public int Balance { get; set; }

        [SimpleElement(Order = 70, NamingRule = NamingRule.UnderLineLower)]
        public int OuterId { get; set; }
    }
}
