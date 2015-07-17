using System;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace Cxcs.Data
{
    [Source(Author = "YJC", CreateDate = "2014-10-31",
        Description = "查询本月群发次数的数据源")]
    class CheckMassSource : BaseDbSource
    {
        public override OutputData DoAction(IInputData input)
        {
            DateTime current = DateTime.Today;
            DateTime firstMonth = new DateTime(current.Year, current.Month, 1);
            DateTime endMonth = firstMonth.AddMonths(1);
            TkDbContext context = Context;
            FieldItem field = new FieldItem("WM_SEND_DATE", TkDataType.DateTime);
            IParamBuilder builder = ParamBuilder.CreateParamBuilder(
                SqlParamBuilder.CreateSingleSql(context, field, ">=", firstMonth),
                SqlParamBuilder.CreateSingleSql(context, field, "<", "WM_SEND_DATE1", endMonth));
            int count = DbUtil.ExecuteScalar("SELECT COUNT(*) FROM CS_WEIXIN_MASS", context, builder)
                .Value<int>();

            return OutputData.Create(count.ToString());
        }
    }
}
