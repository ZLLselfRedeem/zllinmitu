namespace YJC.Toolkit.Weixin.ThirdParty
{
    internal static class WeThirdPartyConst
    {
        internal const string SUITE_TOKEN
            = "https://qyapi.weixin.qq.com/cgi-bin/service/get_suite_token";

        internal const string PRE_AUTH_CODE
            = "https://qyapi.weixin.qq.com/cgi-bin/service/get_pre_auth_code?suite_access_token={0}";

        internal const string PERMANENT_CODE
            = "https://qyapi.weixin.qq.com/cgi-bin/service/get_permanent_code?suite_access_token={0}";

        internal const string AUTH_INFO
            = "https://qyapi.weixin.qq.com/cgi-bin/service/get_auth_info?suite_access_token={0}";

        internal const string GET_AGENT
            = "https://qyapi.weixin.qq.com/cgi-bin/service/get_agent?suite_access_token={0}";

        internal const string SET_AGENT
            = "https://qyapi.weixin.qq.com/cgi-bin/service/set_agent?suite_access_token={0}";

        internal const string CORP_TOKEN
            = "https://qyapi.weixin.qq.com/cgi-bin/service/get_corp_token?suite_access_token={0}";

    }
}
