using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Service;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2015-05-19",
        Description = "微信公众号客服的编辑数据源")]
    [InstancePlugIn, AlwaysCache]
    internal class WeServiceAccountEditObjectSource : IInsertObjectSource,
        IUpdateObjectSource, IDeleteObjectSource
    {
        public static object Instance = new WeServiceAccountEditObjectSource();

        #region IInsertObjectSource 成员

        public object CreateNew(IInputData input)
        {
            return new InternalAccount();
        }

        public OutputData Insert(IInputData input, object instance)
        {
            InternalAccount account = instance as InternalAccount;
            TkDebug.AssertNotNull(account, "account", this);
            string password = account.GetNewPassword("InternalAccount");
            ServiceAccount.Add(account.Account + "@" +
                WeixinSettings.Current.WeixinAccount, account.NickName, password);

            return OutputData.CreateToolkitObject(new KeyData(account.Account, account.NickName));
        }

        #endregion

        #region IUpdateObjectSource 成员

        public OutputData Update(IInputData input, object instance)
        {
            ServiceAccount account = instance.Convert<ServiceAccount>();
            account.Update();

            return OutputData.CreateToolkitObject(KeyData.Empty);
        }

        #endregion

        #region IDetailObjectSource 成员

        public object Query(IInputData input, string id)
        {
            return ServiceAccount.GetAccount(id);
        }

        #endregion

        #region IDeleteObjectSource 成员

        public OutputData Delete(IInputData input, string id)
        {
            ServiceAccount.Delete(id);

            return OutputData.CreateToolkitObject(KeyData.Empty);
        }

        #endregion
    }
}
