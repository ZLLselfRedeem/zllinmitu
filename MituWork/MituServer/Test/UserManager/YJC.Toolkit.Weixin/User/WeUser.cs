using System;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    public class WeUser : WeixinResult
    {
        internal WeUser()
        {
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        [NameModel(WeConst.USER_MODE)]
        public bool Subscribe { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 20)]
        [NameModel(WeConst.USER_MODE)]
        public string OpenId { get; private set; }

        [SimpleElement(LocalName = "nickname", Order = 30)]
        [NameModel(WeConst.USER_MODE)]
        public string NickName { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 40)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        [NameModel(WeConst.USER_MODE)]
        public SexType Sex { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 50)]
        [NameModel(WeConst.USER_MODE)]
        public string Language { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 60)]
        [NameModel(WeConst.USER_MODE)]
        public string City { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 70)]
        [NameModel(WeConst.USER_MODE)]
        public string Province { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 80)]
        [NameModel(WeConst.USER_MODE)]
        public string Country { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 90)]
        [NameModel(WeConst.USER_MODE)]
        public string HeadImgUrl { get; private set; }

        [SimpleElement(NamingRule = NamingRule.UnderLineLower, Order = 100)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        [NameModel(WeConst.USER_MODE)]
        public DateTime SubscribeTime { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 110)]
        [NameModel(WeConst.USER_MODE)]
        public string UnionId { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 120)]
        [NameModel(WeConst.USER_MODE)]
        public string Remark { get; private set; }

        public override string ToString()
        {
            return NickName ?? base.ToString();
        }

        public byte[] DownloadHeadImg()
        {
            if (string.IsNullOrEmpty(HeadImgUrl))
                return null;
            var response = NetUtil.HttpGet(new Uri(HeadImgUrl));
            if (response == null)
                return null;

            return NetUtil.GetResponseData(response);
        }

        public WeixinResult SetUserRemark(string remark)
        {
            return SetUserRemark(OpenId, remark);
        }

        public static WeUser GetUser(string openId)
        {
            TkDebug.AssertArgumentNullOrEmpty(openId, "openId", null);

            string url = string.Format(ObjectUtil.SysCulture, WeConst.USER_URL,
                AccessToken.CurrentToken, openId);
            return WeUtil.GetFromUri(url, new WeUser());
        }

        public static WeixinResult SetUserRemark(string openId, string remark)
        {
            TkDebug.AssertArgumentNullOrEmpty(openId, "openId", null);
            TkDebug.AssertArgumentNullOrEmpty(remark, "remark", null);

            WeUserRemark rem = new WeUserRemark
            {
                OpenId = openId,
                Remark = remark
            };
            return rem.Update();
        }
    }
}
