using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCard : WeixinResult
    {
        internal WeCard()
        {
        }

        public WeCard(WeCardInfo card)
        {
            Card = card;
        }

        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower)]
        public WeCardInfo Card { get; private set; }
    }
}
