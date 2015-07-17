using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpInviteRequest
    {
        public CorpInviteRequest()
        {
        }

        public CorpInviteRequest(string userId)
        {
            TkDebug.AssertArgumentNullOrEmpty(userId, "userId", null);
            UserId = userId;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public string UserId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string InviteTips { get; set; }

        //public CorpInviteResult Invite()
        //{
        //    const string INVITE_SEND =
        //        "https://qyapi.weixin.qq.com/cgi-bin/invite/send?access_token={0}";

        //    string url = WeCorpUtil.GetCorpUrl(INVITE_SEND, WeixinSettings.Current.CorpUserManagerSecret);
        //    var result = WeUtil.PostToUri(url, this.WriteJson(), new CorpInviteResult());
        //    return result;
        //}

    }
}
