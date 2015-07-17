using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardList
    {
        public WeCardList(params WeBatchAddCard[] cardList)
        {
            TkDebug.AssertArgumentNull(cardList, "cardList", null);
            CardList = new List<WeBatchAddCard>(cardList);
        }

        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public List<WeBatchAddCard> CardList { get; private set; }
    }
}
