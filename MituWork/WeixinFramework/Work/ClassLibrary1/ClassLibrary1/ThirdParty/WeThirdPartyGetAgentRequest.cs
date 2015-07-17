using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyGetAgentRequest
    {
        public WeThirdPartyGetAgentRequest()
        {
            SuiteId = "suite_id_value";
        }

        public WeThirdPartyGetAgentRequest(string authCorpid, string permanentCode)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(authCorpid, "authCorpid", null);
            TkDebug.AssertArgumentNullOrEmpty(permanentCode, "permanentCode", null);

            AuthCorpid = authCorpid;
            PermanentCode = permanentCode;
        }

        [SimpleElement(Order = 10, NamingRule = NamingRule.UnderLineLower)]
        public string SuiteId { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string AuthCorpid { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        public string PermanentCode { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        public int Agentid { get; set; }

        public WeThirdPartyAuthInfosResponse get_auth_info()
        {
            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.AUTH_INFO, WeixinSettings.Current.CorpUserManagerSecret);
            var result = WeUtil.PostDataToUri(url, this.WriteJson(), new WeThirdPartyAuthInfosResponse());
            return result;
        }

        public WeThirdPartyGetAgentResponse get_agent()
        {
            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.GET_AGENT, WeixinSettings.Current.CorpUserManagerSecret);
            var result = WeUtil.PostToUri(url, this.WriteJson(), new WeThirdPartyGetAgentResponse());
            return result;
        }

        public WeThirdPartyCorpTokenResponse get_corp_token()
        {
            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.CORP_TOKEN, WeixinSettings.Current.CorpUserManagerSecret);
            var result = WeUtil.PostDataToUri(url, this.WriteJson(), new WeThirdPartyCorpTokenResponse());
            return result;
        }

        public static string get_suite_token(string suiteTicket)
        {
            TkDebug.AssertArgumentNullOrEmpty(suiteTicket, "suiteTicket", null);

            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.SUITE_TOKEN, WeixinSettings.Current.CorpUserManagerSecret);
            WeThirdPartySuiteTokenRequest request = new WeThirdPartySuiteTokenRequest(suiteTicket);
            var result = WeUtil.PostDataToUri(url, request.WriteJson(), new WeThirdPartySuiteTokenResponse());
            return result.SuiteAccessToken;
        }

        public static string get_pre_auth_code(params string[] ids)
        {
            TkDebug.AssertArgumentNull(ids, "ids", null);

            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.PRE_AUTH_CODE, WeixinSettings.Current.CorpUserManagerSecret);
            WeThirdPartyPreAuthCodeRequest request = new WeThirdPartyPreAuthCodeRequest(ids);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeThirdPartyPreAuthCodeResponse());
            return result.PreAuthCode;
        }

        public static WeThirdPartyPermanentCodeResponse get_permanent_code(string authCode)
        {
            TkDebug.AssertArgumentNullOrEmpty(authCode, "authCode", null);

            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.PERMANENT_CODE, WeixinSettings.Current.CorpUserManagerSecret);
            WeThirdPartyPermanentCodeRequest request = new WeThirdPartyPermanentCodeRequest(authCode);
            var result = WeUtil.PostDataToUri(url, request.WriteJson(), new WeThirdPartyPermanentCodeResponse());
            return result;
        }

        public static WeixinResult set_agent(string authCorpid, string permanentCode, WeThirdPartyAgentSet agent)
        {
            TkDebug.AssertArgumentNullOrEmpty(authCorpid, "authCorpid", null);
            TkDebug.AssertArgumentNullOrEmpty(permanentCode, "permanentCode", null);
            TkDebug.AssertArgumentNull(agent, "agent", null);

            string url = WeCorpUtil.GetCorpUrl(WeThirdPartyConst.SET_AGENT, WeixinSettings.Current.CorpUserManagerSecret);
            WeThirdPartySetAgentRequest request = new WeThirdPartySetAgentRequest(authCorpid, permanentCode, agent);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
