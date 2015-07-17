using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardDelEvent : WeCardPassEvent
    {
        [SimpleElement(Order = 70)]
        public string UserCardCode { get; protected set; }
    }
}
