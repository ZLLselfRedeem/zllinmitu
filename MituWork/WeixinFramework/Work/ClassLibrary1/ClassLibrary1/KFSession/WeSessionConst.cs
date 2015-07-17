namespace YJC.Toolkit.Weixin.KFSession
{
    public static class WeSessionConst
    {
        public const string SESSION_CREATE =
            "https://api.weixin.qq.com/customservice/kfsession/create?access_token={0}";
        public const string SESSION_CLOSE =
            "https://api.weixin.qq.com/customservice/kfsession/close?access_token={0}";
        public const string SESSION_GET =
            "https://api.weixin.qq.com/customservice/kfsession/getsession?access_token={0}&openid={1}";
        public const string SESSION_LIST_GET =
            "https://api.weixin.qq.com/customservice/kfsession/getsessionlist?access_token={0}&kf_account={1}";
        public const string WAIT_CAST_GET =
            "https://api.weixin.qq.com/customservice/kfsession/getwaitcase?access_token={0}";
        public const string RECORD_GET =
            "https://api.weixin.qq.com/customservice/msgrecord/getrecord?access_token={0}";
    }
}
