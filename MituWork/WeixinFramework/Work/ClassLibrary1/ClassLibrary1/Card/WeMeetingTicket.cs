using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeMeetingTicket
    {
        internal WeMeetingTicket()
        {
        }

        public WeMeetingTicket(WeCardBaseInfo baseInfo)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);

            BaseInfo = baseInfo;
        }
        public WeMeetingTicket(WeCardBaseInfo baseInfo, string meetingDetail)
        {
            TkDebug.AssertArgumentNull(baseInfo, "baseInfo", null);
            TkDebug.AssertArgumentNullOrEmpty(meetingDetail, "meetingDetail", null);

            BaseInfo = baseInfo;
            MeetingDetail = meetingDetail;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string MeetingDetail { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string MapUrl { get; set; }

        [ObjectElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public WeCardBaseInfo BaseInfo { get; private set; }
    }
}
