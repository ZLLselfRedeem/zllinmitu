using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    class WeUserRemark
    {
        [SimpleElement(LocalName = "openid", Order = 10)]
        public string OpenId { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        public string Remark { get; set; }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeConst.REMARK_URL);

            return WeUtil.PostToUri(url, this.WriteJson(WeConst.WRITE_SETTINGS),
                new WeixinResult());
        }
    }
}
