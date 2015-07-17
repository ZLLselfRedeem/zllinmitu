using System;
using System.Data;
using YJC.Toolkit.Accounting;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.MetaData;

namespace Mitu.Accounting
{
    /// <summary>
    ///  报表数据(AR_REPORT_DATA)的数据访问层类
    /// </summary>
    [Resolver(Author = "YJC", CreateDate = "2015-07-09",
        Description = "报表数据(AR_REPORT_DATA)的数据访问层类")]
    public class ReportDataResolver : Tk5TableResolver
    {
        private static readonly WriteSettings WriteSettings = new WriteSettings { DateTimeFormat = "yyyyMM" };

        internal const string DATAXML = "Accounting/ReportData.xml";

        /// <summary>
        /// 建构函数，设置附着的Xml文件。
        /// </summary>
        /// <param name="context">数据库连接上下文</param>
        /// <param name="source">附着的数据源</param>
        public ReportDataResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
            AutoUpdateKey = true;
            AutoTrackField = true;
            if (ListSource != null)
                ListSource.FilledListTables += ListSource_FilledListTables;
        }

        private void ListSource_FilledListTables(object sender, FilledListEventArgs e)
        {
            string companyId = WebGlobalVariable.Request.QueryString["Company"];
            if (!string.IsNullOrEmpty(companyId))
            {
                SqlSelector.Select(Context, HostDataSet, "CompanyName", 
                    "SELECT COM_FULL_NAME FROM AR_COMPANY", SqlParamBuilder.CreateEqualSql(
                    Context, "COM_COMPANY_ID", TkDataType.Int, companyId));
            }
        }

        /// <summary>
        /// 在表发生新建、修改和删除的时候触动。注意，千万不要删除base.OnUpdatingRow(e);
        /// UpdatingRow事件附着在基类该函数中。
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            switch (e.Status)
            {
                case UpdateKind.Insert:
                    break;
                case UpdateKind.Update:
                    break;
                case UpdateKind.Delete:
                    break;
            }
        }

        public DataRow UpdateRow(BasePostObject input, UpdateKind updateKind)
        {
            DataRow row;
            if (updateKind == UpdateKind.Insert)
            {
                SetCommands(AdapterCommand.Insert);
                row = NewRow();
            }
            else
            {
                SetCommands(AdapterCommand.Update);
                row = SelectRowWithKeys(input.Info.ReportId);
            }
            
            row.BeginEdit();
            input.Info.AddToDataRow(row, WriteSettings);
            if (updateKind == UpdateKind.Insert)
                row["ReportId"] = CreateUniId();
            //row["Company"] = input.Info.Company;
            //row["ReportName"] = input.Info.ReportName;
            //row["ReportType"] = input.Info.ReportType;
            //row["ReportDate"] = input.Info.ReportDate.ToString("yyyyMM");
            row["ReportData"] = input.WriteXml();
            UpdateTrackField(updateKind, row);
            row.EndEdit();
            UpdateDatabase();

            return row;
        }

        public ReportObjectData ReadRow(IInputData input)
        {
            DataRow row = Query(input.QueryString);
            string type = row["ReportName"].ToString();
            Object obj = null;
            switch (type)
            {
                case "BalanceSheet":
                    obj = new BalanceSheet();
                    break;
                case "CashFlowStatement":
                    obj = new CashFlowStatement();
                    break;
                //case "ProfitAppropriation":
                //    obj = new IncomeStatement();
                //    break;
                case "IncomeStatement":
                    obj = new IncomeStatement();
                    break;
            }
            ReportObjectData result = new ReportObjectData(row, obj);

            return result;
        }
    }
}