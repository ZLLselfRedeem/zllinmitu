using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeQrcodeCreate
    {
        public WeQrcodeCreate(string actionName, WeQrcodeInfo card)
        {
            ActionName = actionName;
            Card = card;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string ActionName { get; private set; }

        [TagElement(Order = 20, LocalName = "action_info")]
        [ObjectElement(NamingRule = NamingRule.Lower)]
        public WeQrcodeInfo Card { get; private set; }
    }
}
