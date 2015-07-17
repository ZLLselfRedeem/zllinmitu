using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace Cxcs.Data
{
    [Source(Author = "YJC", CreateDate = "2014-08-07",
        Description = "审核绑定的数据源")]
    class CheckBindingSource : BaseDbSource
    {
        public override OutputData DoAction(IInputData input)
        {
            using (BindingResolver resolver = new BindingResolver(this))
            {
                int checkFlag = input.QueryString["Flag"].Value<int>();
                if (checkFlag != 0)
                    checkFlag = 1;
                DataRow row = resolver.Query(input.QueryString);
                row.BeginEdit();
                row["CheckFlag"] = checkFlag;
                row["CheckDate"] = DateTime.Now;
                row["CheckId"] = BaseGlobalVariable.UserId;
                row.EndEdit();
                resolver.SetCommands(AdapterCommand.Update);
                resolver.UpdateDatabase();

                return OutputData.CreateToolkitObject(resolver.CreateKeyData());
            }
        }
    }
}
