using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardGetEvent : WeCardDelEvent
    {
        [SimpleElement(Order = 80)]
        public string FriendUserName { get; private set; }

        [SimpleElement(Order = 90)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool IsGiveByFriend { get; private set; }

        [SimpleElement(Order = 100)]
        public int OuterId { get; private set; }
    }
}
