using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Data;

namespace Cxcs.Data
{
    [Source(Author = "YJC", CreateDate = "2014-12-14",
        Description = "从云助手数据库中复制记录到文档数据库数据源")]
    internal class CopyDocumentSource : BaseDbSource
    {
        public CopyDocumentSource()
        {
        }

        public override OutputData DoAction(IInputData input)
        {
            try
            {
                string docId = input.QueryString["DocId"];
                using (TaxDocumentResolver destResolver = new TaxDocumentResolver(this))
                {
                    DataRow row = destResolver.TrySelectRowWithParam("SourceId", docId);
                    if (row != null)
                        throw new WebPostException("已经复制过该文档！");

                    var toolSource = new EmptyDbDataSource()
                    {
                        Context = DbContextUtil.CreateDbContext("Tools")
                    };
                    using (toolSource)
                    using (var srcResolver = new TaxDocumentResolver(toolSource))
                    using (var srcAttachResolver = new DocAttachmentResolver(toolSource))
                    using (var destAttachResolver = new DocAttachmentResolver(this))
                    {
                        srcResolver.SelectWithKeys(docId);
                        srcAttachResolver.SelectWithParam("DocId", docId);

                        DataSetUtil.CopyDataTable(srcResolver.HostTable, destResolver.HostTable);
                        destResolver.SetCommands(AdapterCommand.Insert);
                        string id = null;
                        string keyField = destResolver.KeyField;
                        foreach (DataRow destRow in destResolver.HostTable.Rows)
                        {
                            id = destResolver.CreateUniId();
                            destRow.BeginEdit();
                            destRow["SourceId"] = destRow[keyField];
                            destRow[keyField] = id;
                            destRow.EndEdit();
                        }

                        DataTable attachTable = srcAttachResolver.HostTable;
                        if (attachTable == null)
                        {
                            UpdateUtil.UpdateTableResolvers(null, destResolver);
                        }
                        else
                        {
                            DataTable destAttachTable = destAttachResolver.SelectTableStructure();
                            DataSetUtil.CopyDataTable(attachTable, destAttachTable);
                            foreach (DataRow attachRow in destAttachTable.Rows)
                            {
                                attachRow.BeginEdit();
                                attachRow["AttId"] = destAttachResolver.CreateUniId();
                                attachRow["DocId"] = id;
                                attachRow.EndEdit();
                            }
                            destAttachResolver.SetCommands(AdapterCommand.Insert);
                            UpdateUtil.UpdateTableResolvers(null, destResolver, destAttachResolver);
                        }
                        return OutputData.CreateToolkitObject(destResolver.CreateKeyData());
                    }
                }
            }
            catch (WebPostException ex)
            {
                return OutputData.CreateToolkitObject(ex.CreateErrorResult());
            }
        }

    }
}
