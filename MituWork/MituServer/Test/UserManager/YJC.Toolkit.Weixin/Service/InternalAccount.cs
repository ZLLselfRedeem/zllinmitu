using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-05-22", Description = "微信客服信息")]
    [RegType(Author = "YJC", CreateDate = "2015-05-22", Description = "微信客服信息")]
    internal class InternalAccount
    {
        public InternalAccount()
        {
        }

        public InternalAccount(string account, string password)
        {
            Account = account;
            Password = password == null ? null : WeUtil.Md5(password);
        }

        public InternalAccount(ServiceAccount account, string password)
        {
            Account = account.Account;
            NickName = account.NickName;
            Password = password;
        }

        [FieldInfo(IsEmpty = false, Length = 255)]
        [FieldControl(ControlType.Text, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("客服账号")]
        [SimpleElement(Order = 10, LocalName = "kf_account")]
        [NameModel(WeConst.USER_MODE, NamingRule = NamingRule.Pascal)]
        public string Account { get; set; }

        [FieldInfo(IsEmpty = false, Length = 255)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("客服昵称")]
        [SimpleElement(NamingRule = NamingRule.Lower)]
        [NameModel(WeConst.USER_MODE, NamingRule = NamingRule.Pascal)]
        public string NickName { get; set; }

        [FieldInfo(IsEmpty = false, Length = 255)]
        [FieldControl(ControlType.Password, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("登录密码")]
        [SimpleElement(NamingRule = NamingRule.Lower)]
        [NameModel(WeConst.USER_MODE, NamingRule = NamingRule.Pascal)]
        public string Password { get; set; }

        [FieldInfo(IsEmpty = false, Length = 255)]
        [FieldControl(ControlType.Password, Order = 40)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("确认密码")]
        [SimpleElement(NamingRule = NamingRule.Pascal)]
        [NameModel(WeConst.USER_MODE, NamingRule = NamingRule.Pascal)]
        public string ConfirmPassword { get; set; }

        public string GetNewPassword(string tableName)
        {
            if (Password == ConfirmPassword)
            {
                if (Password == string.Empty)
                {
                    throw new WebPostException("密码不能为空", new FieldErrorInfo(tableName, "Password", "登录密码不能为空"));
                }
                else
                    return this.Password;
            }
            FieldErrorInfo info = new FieldErrorInfo(tableName, "Password", "登录密码与确认密码不匹配");
            throw new WebPostException("登录密码与确认密码不匹配", info);
        }

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
