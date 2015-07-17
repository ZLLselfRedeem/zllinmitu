using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeChooseCardResponse
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string ErrMsg { get; private set; }

        [ObjectElement(IsMultiple = true, Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public List<WeChooseCardInfo> ChooseCardInfo { get; private set; }
    }
}
