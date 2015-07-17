using System.Collections.Generic;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Data.Constraint;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [Source(Author = "YJC", CreateDate = "2014-12-09",
        Description = "设置企业用户的所在的组织机构")]
    class CorpUserDepartmentSource : BaseWebDbSource
    {
        private const string SQL = "SELECT CU_DEPARTMENT FROM WE_CORP_USER";

        public CorpUserDepartmentSource()
        {
            Context = DbContextUtil.CreateDbContext("Weixin");
        }


        protected override OutputData DoGet(IInputData input)
        {
            Tk5TableResolver getResovler = new Tk5TableResolver(@"Weixin\CorpTagDept.xml", this);
            using (getResovler)
            {
                DataTable table = getResovler.CreateVirtualTable();
                IParamBuilder builder = SqlParamBuilder.CreateEqualSql(Context, "CU_USER_ID",
                    TkDataType.Int, input.QueryString["UserId"]);
                string dept = DbUtil.ExecuteScalar(SQL, Context, builder).ToString();
                QuoteStringList list = dept.Value<QuoteStringList>();
                if (list != null)
                {
                    List<int> deptList = list.ConvertToList<int>();
                    if (deptList != null)
                    {
                        foreach (var item in deptList)
                        {
                            DataRow userRow = table.NewRow();
                            userRow["DeparmentId"] = item;
                            table.Rows.Add(userRow);
                        }
                        getResovler.Decode(input.Style);
                    }
                }

                input.CallerInfo.AddInfo(DataSet);
            }
            return OutputData.Create(DataSet);
        }

        protected override OutputData DoPost(IInputData input)
        {
            Tk5TableResolver getResovler = new Tk5TableResolver(@"Weixin\CorpTagDept.xml", this);
            using (getResovler)
            {
                DataSet postDataSet = input.PostObject.Convert<DataSet>();
                getResovler.PrepareDataSet(postDataSet);

                FieldErrorInfoCollection errors = new FieldErrorInfoCollection();
                getResovler.CheckFirstConstraints(input, errors);
                getResovler.CheckLaterConstraints(input, errors);
                errors.CheckError();

                QuoteStringList postList = new QuoteStringList();
                DataTable postTable = postDataSet.Tables[getResovler.TableName];
                if (postTable != null)
                {
                    foreach (DataRow postRow in postTable.Rows)
                        postList.Add(postRow["DeparmentId"].ToString());
                }
                string tagId = input.QueryString["TagId"];

                InternalCorpUserResolver userResolver = new InternalCorpUserResolver(this);
                using (userResolver)
                {
                    DataRow row = userResolver.SelectRowWithKeys(input.QueryString["UserId"]);
                    CorpUser user = new CorpUser();
                    user.ReadFromDataRow(row, WeCorpConst.USER_MODE);
                    user.DepartmentList = postList;
                    row["Department"] = postList;
                    userResolver.SetCommands(AdapterCommand.Update);
                    user.Update();

                    userResolver.UpdateDatabase();
                    return OutputData.CreateToolkitObject(userResolver.CreateKeyData());
                }
            }
        }
    }
}
