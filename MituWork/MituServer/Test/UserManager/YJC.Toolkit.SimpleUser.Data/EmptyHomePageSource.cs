using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.SimpleRight
{
    [Source(Author = "YJC", CreateDate = "2014-07-10", Description = "空的首页")]
    class EmptyHomePageSource : ISource
    {
        #region ISource 成员

        public OutputData DoAction(IInputData input)
        {
            IUserInfo userInfo = WebGlobalVariable.Info;

            Dictionary<string, string> result = new Dictionary<string, string>();
            result["Title"] = WebAppSetting.WebCurrent.AppFullName;
            result["Description"] = WebAppSetting.WebCurrent.AppDescription;
            return OutputData.CreateObject(result);
        }

        #endregion
    }
}
