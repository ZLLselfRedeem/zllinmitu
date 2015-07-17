using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Data;
using System.IO;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Data.Constraint;

namespace YJC.Toolkit.Excel
{
    [Source(Author = "YJC", CreateDate = "2015/06/23",
        Description = "数据源")]
    internal class ImportDataSource : BaseDbSource
    {
        public ImportDataSource()
        {
        }

        public override OutputData DoAction(IInputData input)
        {
            string source = input.QueryString["Source"];
            string path = Path.Combine(BaseAppSetting.Current.XmlPath, @"Import", source + ".xml");
            ImportConfigXml config = new ImportConfigXml();
            config.ReadXmlFromFile(path);
            string filePath = @"C:\Users\zll\Downloads\角色.xls";

            var meta = config.Import.MetaData.CreateObject(input);
            Tk5ListMetaData data = meta as Tk5ListMetaData;

            var resolver = config.Import.Resolver.CreateObject(this);
            MetaDataTableResolver metaResolver = resolver as MetaDataTableResolver;
            TkDebug.AssertNotNull(metaResolver, "metaResolver", this);

            ImportError errResult = new ImportError();
            var dataSet = ExcelImporter.ExcelImport(filePath, data, errResult);
            FieldErrorInfoCollection importResult = metaResolver.Import(dataSet, input);
            if (importResult.Count > 0)
            { 
                var positions = (from item in importResult
                                 orderby item.Position descending
                                 select item.Position).Distinct();

                foreach (var errorInfo in importResult)
                {
                    DataRow errorRow = dataSet.Tables[errorInfo.TableName].Rows[errorInfo.Position];

                    ImportWarningItem errorItem = new ImportWarningItem(errorRow["OriginalRowNum"].Value<int>(),
                        resolver.GetFieldInfo(errorInfo.NickName).DisplayName, (string)errorRow[errorInfo.NickName], errorInfo.Message);
                    errResult.Add(errorItem);
                }

                foreach (var index in positions)
                {
                    resolver.HostTable.Rows.RemoveAt(index);
                }
            }

            DataSet webReport = null;
            if (errResult.Count > 0)
            {
                byte[] dataFile = ExcelUtil.ExcelReport(filePath, data, errResult);
                webReport = ExcelUtil.DataSetReport(filePath, data, errResult);
            }

            return OutputData.CreateObject(new ImportResultData(DataSet, webReport, errResult));
        }
    }
}
