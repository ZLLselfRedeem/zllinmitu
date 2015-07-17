using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class WeCardUpdate
    {
        public WeCardUpdate(string cardId, object cardInfo)
        {
            CardId = cardId;

            if (cardInfo is WeMemberCard)
            {
                MemberCard = (WeMemberCard)cardInfo;
            }
            else if (cardInfo is WeBoardingPass)
            {
                BoardingPass = (WeBoardingPass)cardInfo;
            }
            else if (cardInfo is WeScenicTicket)
            {
                ScenicTicket = (WeScenicTicket)cardInfo;
            }
            else if (cardInfo is WeMovieTicket)
            {
                MovieTicket = (WeMovieTicket)cardInfo;
            }
            else if (cardInfo is WeMeetingTicket)
            {
                MeetingTicket = (WeMeetingTicket)cardInfo;
            }
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string CardId { get; private set; }

        [ObjectElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public WeMemberCard MemberCard { get; private set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public WeBoardingPass BoardingPass { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower)]
        public WeScenicTicket ScenicTicket { get; private set; }

        [ObjectElement(Order = 50, NamingRule = NamingRule.UnderLineLower)]
        public WeMovieTicket MovieTicket { get; private set; }

        [ObjectElement(Order = 60, NamingRule = NamingRule.UnderLineLower)]
        public WeMeetingTicket MeetingTicket { get; private set; }
    }
}
