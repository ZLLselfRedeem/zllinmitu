namespace YJC.Toolkit.Weixin
{
    public static class WeCorpConst
    {
        public const int MAX_IMAGE_SIZE = 1 * 1024 * 1024;

        public const int MAX_VOICE_SIZE = 2 * 1024 * 1024;

        public const int MAX_VIDEO_SIZE = 10 * 1024 * 1024;

        public const int MAX_FILE_SIZE = 10 * 1024 * 1024;

        public const string TOKEN_URL =
            "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";

        public const string CREATE_DEPARTMENT =
            "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token={0}";

        public const string UPDATE_DEPARTMENT =
            "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token={0}";

        public const string DELETE_DEPARTMENT =
            "https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token={0}&id={1}";

        public const string QUERY_DEPARTMENT =
            "https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}";

        public const string QUERY_DEPARTMENT_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/simplelist?access_token={0}&department_id={1}&fetch_child={2}&status={3}";

        public const string QUERY_DEPARTMENT_DETAIL_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/list?access_token={0}&department_id={1}&fetch_child={2}&status={3}";

        public const string CREATE_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token={0}";

        public const string UPDATE_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token={0}";

        public const string DELETE_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token={0}&userid={1}";

        public const string BATCH_DELETE_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token={0}";

        public const string GET_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token={0}&userid={1}";

        public const string CREATE_TAG =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/create?access_token={0}";

        public const string UPDATE_TAG =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/update?access_token={0}";

        public const string DELETE_TAG =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/delete?access_token={0}&tagid={1}";

        public const string QUERY_TAG =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token={0}";

        public const string QUERY_TAG_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token={0}&tagid={1}";

        public const string ADD_TAG_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/addtagusers?access_token={0}";

        public const string REMOVE_TAG_USER =
            "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token={0}";

        public const string UPLOAD_URL =
            "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        public const string DOWNLOAD_URL =
            "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";

        public const string CREATE_MENU =
            "https://qyapi.weixin.qq.com/cgi-bin/menu/create?access_token={0}&agentid={1}";

        public const string QUERY_MENU =
            "https://qyapi.weixin.qq.com/cgi-bin/menu/get?access_token={0}&agentid={1}";

        public const string DELETE_MENU =
            "https://qyapi.weixin.qq.com/cgi-bin/menu/delete?access_token={0}&agentid={1}";

        public const string MESSAGE_URL =
            "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}";

        public const string AUTH_ACCESS_TOKEN =
            "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}&agentid={2}";

        public const string IP_LIST =
            "https://qyapi.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}";

        public const string INVITE_SEND =
            "https://qyapi.weixin.qq.com/cgi-bin/invite/send?access_token={0}";

        public const string AGENT_SET =
            "https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token={0}";

        public const string AGENT_GET =
            "https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token={0}&agentid={1}";

        public const string AGENT_LIST =
            "https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token={0}";

        internal const string CORP_DEPT_NAME = "CorpDept";

        internal const string DEPT_TREE_MODE = "Tree";

        internal const string USER_MODE = "CorpUser";

        public const string JS_TICKET =
            "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}";
    }
}
