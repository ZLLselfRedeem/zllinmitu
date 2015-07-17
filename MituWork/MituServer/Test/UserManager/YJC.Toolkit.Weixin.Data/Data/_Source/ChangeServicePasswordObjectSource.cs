using YJC.Toolkit.Data;
using YJC.Toolkit.LogOn;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Service;

namespace YJC.Toolkit.SimpleRight
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-12-03", Description = "修改用户的密码")]
    class ChangeServicePasswordObjectSource : IUpdateObjectSource, IDetailObjectSource
    {
        #region IUpdateObjectSource 成员

        public OutputData Update(IInputData input, object instance)
        {
            BasePasswordData passwd = instance.Convert<BasePasswordData>();

            InternalAccount account = new InternalAccount(passwd.UserId, passwd.Password);
            account.Update();

            return OutputData.CreateToolkitObject(KeyData.Empty);
        }

        #endregion

        #region IDetailObjectSource 成员

        public object Query(IInputData input, string id)
        {
            return new BasePasswordData(input.QueryString["UserId"], input.QueryString["UserName"]);
        }

        #endregion
    }
}
