using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    internal class WeColors : WeixinResult
    {
        [ObjectElement(IsMultiple = true, Order = 30, NamingRule = NamingRule.Lower, 
            UseConstructor = true)]
        public List<WeCardColor> Colors { get; private set; }
    }
}
