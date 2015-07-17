using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeBatchCardInfo : WeBatchAddCard
    {
        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsSucc { get; private set; }
    }
}
