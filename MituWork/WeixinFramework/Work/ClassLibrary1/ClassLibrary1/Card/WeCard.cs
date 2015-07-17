using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCard : WeixinResult
    {
        internal WeCard()
        {
        }

        internal WeCard(WeCardInfo card)
        {
            Card = card;
        }

        [ObjectElement(Order = 30, NamingRule = NamingRule.Lower, UseConstructor = true)]
        public WeCardInfo Card { get; private set; }
    }
}
