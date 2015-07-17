using System;
using System.Collections.Generic;
using YJC.Toolkit.Collections;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Service
{
    [TypeScheme(Author = "YJC", CreateDate = "2015-05-20", Description = "微信客服信息")]
    [RegType(Author = "YJC", CreateDate = "2015-05-22", Description = "微信客服信息")]
    public class ServiceAccount : IRegName
    {

        #region IRegName 成员

        public string RegName
        {
            get
            {
                return Account;
            }
        }

        #endregion

        [FieldInfo(Length = 255, IsKey = true)]
        [FieldControl(ControlType.Text, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("客服账号")]
        [SimpleElement(Order = 10, LocalName = "kf_account")]
        [NameModel(WeConst.USER_MODE, NamingRule = NamingRule.Pascal)]
        public string Account { get; private set; }

        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("客服昵称")]
        [SimpleElement(Order = 20, LocalName = "kf_nick")]
        [NameModel(WeConst.USER_MODE, NamingRule = NamingRule.Pascal)]
        public string NickName { get; set; }

        [SimpleElement(Order = 30, LocalName = "kf_id")]
        public string Id { get; private set; }

        [SimpleElement(Order = 40, LocalName = "kf_headimgurl")]
        public string HeadImgUrl { get; private set; }

        public static WeixinResult Add(string account, string nickName, string password)
        {
            TkDebug.AssertArgumentNullOrEmpty(account, "account", null);
            TkDebug.AssertArgumentNullOrEmpty(nickName, "nickName", null);

            InternalAccount saccount = new InternalAccount
            {
                Account = account,
                NickName = nickName,
                Password = (password == null ? null : WeUtil.Md5(password))
            };
            return saccount.Add();
        }

        public WeixinResult Update()
        {
            InternalAccount account = new InternalAccount(this, null);
            return account.Update();
        }

        public WeixinResult ModifyPasswd(string password)
        {
            TkDebug.AssertArgumentNullOrEmpty(password, "password", null);

            InternalAccount account = new InternalAccount(this, WeUtil.Md5(password));
            return account.Update();
        }

        public static WeixinResult Delete(string account)
        {
            TkDebug.AssertArgumentNullOrEmpty(account, "account", null);

            string url = string.Format(ObjectUtil.SysCulture, WeConst.DELETE_KF_ACCOUNT,
                AccessToken.CurrentToken, account);
            WeixinResult result = NetUtil.HttpGetReadJson(new Uri(url), new WeixinResult());
            return result;
        }

        public static WeixinResult UploadHeadImg(string account, string fileName, byte[] fileData)
        {
            TkDebug.AssertArgumentNullOrEmpty(account, "account", null);
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);
            TkDebug.AssertArgumentNull(fileData, "fileData", null);

            string url = string.Format(ObjectUtil.SysCulture, WeConst.SET_KF_HEADING,
                AccessToken.CurrentToken, account);

            WeixinResult result = WeUtil.UploadFile(url, fileName, fileData, new WeixinResult());
            return result;
        }

        public static IEnumerable<ServiceAccount> GetAccountList()
        {
            string url = WeUtil.GetUrl(WeConst.GET_KF_LIST);
            ServiceAccountList result = NetUtil.HttpGetReadJson(new Uri(url), new ServiceAccountList());
            return result.KfList;
        }

        public static ServiceAccount GetAccount(string account)
        {
            TkDebug.AssertArgumentNullOrEmpty(account, "account", null);

            RegNameList<ServiceAccount> list = GetAccountList().Convert<RegNameList<ServiceAccount>>();
            return list[account];
        }

        public static IEnumerable<ServiceInfo> GetServiceInfo()
        {
            string url = WeUtil.GetUrl("https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token={0}");
            return WeUtil.GetFromUri(url, new ServiceInfoList()).ServiceInfos;
        }
    }
}
