using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    internal class InternalAccount
    {
        public InternalAccount()
        {
        }

        public InternalAccount(ServiceAccount account, string password)
        {
            Account = account.Account;
            NickName = account.NickName;
            Password = password;
        }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("客服账号")]
        [SimpleElement(Order = 10, LocalName = "kf_account")]
        public string Account { get; set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("客服昵称")]
        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string NickName { get; set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Password, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("登录密码")]
        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Password { get; set; }

        public WeixinResult Add()
        {
            string url = WeUtil.GetUrl(WeConst.ADD_KF_ACCOUNT);
            WeixinResult result = WeUtil.PostDataToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeConst.UPDATE_KF_ACCOUNT);
            WeixinResult result = WeUtil.PostDataToUri(url, this.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
