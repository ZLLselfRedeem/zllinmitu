using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public static class WeConst
    {
        public static readonly QName ROOT = QName.Get("xml");
        internal readonly static WriteSettings WRITE_SETTINGS = new WriteSettings
        {
            OmitHead = true,
            Encoding = new UTF8Encoding(false)
        };

        public const string USER_MODE = "WeUser";

        public const string JSON_MODE = "WeJson";

        internal const string JS_MODE = "JS_SDK";

        public const int MAX_IMAGE_SIZE = 1 * 1024 * 1024;

        public const int MAX_VOICE_SIZE = 2 * 1024 * 1024;

        public const int MAX_VIDEO_SIZE = 10 * 1024 * 1024;

        public const int MAX_THUMB_SIZE = 64 * 1024;

        public const string TOKEN_URL =
            "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        public const string FAN_URL =
            "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}";

        public const string USER_URL =
            "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";

        public const string REMARK_URL =
            "https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}";

        public const string GROUP_MESSAGE_URL =
            "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}";

        public const string UPLOAD_URL =
            "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";

        public const string DOWNLOAD_URL =
            "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";

        public const string CREATE_MENU =
            " https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";

        public const string SELF_MENU =
            "https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}";

        public const string QUERY_MENU =
            "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";

        public const string DELETE_MENU =
            "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";

        public const string CREATE_GROUP =
            "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}";

        public const string QUERY_GROUP =
            "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}";

        public const string QUERY_USER_GROUP =
            "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}";

        public const string UPDATE_GROUP =
            "https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}";

        public const string ADD_GROUP_USER =
            "https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}";

        public const string SERVICE_URL =
            "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";

        public const string QR_CREATE_URL =
            "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}";

        public const string QR_TICKET =
            "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}";

        public const string AUTH_ACCESS_TOKEN =
            "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        public const string REFRESH_ACCESS_TOKEN =
            "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}";

        public const string AUTH_USER_INFO =
            "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";

        public const string AUTH_URL =
            "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect";

        public const string TEMPLATE_MESSAGE_URL =
            "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";

        public const string GROUP_MASS_MESSAGE_URL =
            "https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}";

        public const string USER_MASS_MESSAGE_URL =
            "https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}";

        public const string DELETE_MASS_MESSAGE_URL =
            "https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}";

        public const string VIDEO_MASS_URL =
            "https://file.api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token={0}";

        public const string NEWS_MASS_URL =
            "https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}";

        public const string SHORT_URL =
            "https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}";

        public const string IP_LIST =
            "https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}";

        public const string JS_TICKET =
            "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi";

        public const string ADD_KF_ACCOUNT =
            "https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}";

        public const string UPDATE_KF_ACCOUNT =
            "https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}";

        public const string DELETE_KF_ACCOUNT =
            "https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}&kf_account={1}";

        public const string SET_KF_HEADING =
            "http://api.weixin.qq.com/customservice/kfaccount/uploadheadimg?access_token={0}&kf_account={1}";

        public const string GET_KF_LIST =
            "https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}";
    }
}
