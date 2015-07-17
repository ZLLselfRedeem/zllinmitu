using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Excel
{
    public static class ExcelImporter
    {
        #region 根据模板sheet和元数据，将Excel文件的内容导入到DataSet中

        public static DataSet ExcelImport(string strFileName, Tk5ListMetaData metaInfos, ImportError importError)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = DataSetUtil.CreateDataTable(metaInfos.Table.TableName, metaInfos.Table.TableList);
            dataTable.Columns.Add("OriginalRowNum", typeof(int));

            IWorkbook workbook ;
            ISheet sheet;

            ExcelUtil.ReadExcle(strFileName, metaInfos.Table.TableDesc, out workbook, out sheet);

            SheetImport(metaInfos, dataTable, sheet, importError);
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private static void SheetImport(Tk5ListMetaData metaInfos, DataTable dataTable, ISheet sheet,
            ImportError importError)
        {
            if (sheet != null)
            {
                Dictionary<string, Tk5FieldInfoEx> dicOfInfo = new Dictionary<string, Tk5FieldInfoEx>();
                foreach (Tk5FieldInfoEx info in metaInfos.Table.TableList)
                {
                    dicOfInfo.Add(info.DisplayName, info);
                }

                IRow headerRow = sheet.GetRow(0);
                IRow row = null;
                string columnName = string.Empty;
                string strValue = string.Empty;
                ICell cell = null;
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i);
                    DataRow dataRow = dataTable.NewRow();
                    bool rowError = false;
                    for (int j = headerRow.FirstCellNum; j < headerRow.LastCellNum; j++)
                    {
                        columnName = headerRow.GetCell(j).ToString();
                        cell = row.GetCell(j);
                        strValue = ((cell == null) ? null : cell.ToString());
                        var imResult = TablePadding(dataRow, columnName, dicOfInfo, strValue, i);
                        if (imResult != null)
                        {
                            importError.Add(imResult);
                            rowError = true;
                        }
                    }

                    if (!rowError)
                    {
                        dataRow["OriginalRowNum"] = i;
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
        }

        // 设置DataTable的值
        private static ImportWarningItem TablePadding(DataRow dataRow, string columnName, Dictionary<string,
            Tk5FieldInfoEx> dicOfInfo, string strValue, int indexOfRow)
        {
            ImportWarningItem imResult = null;
            Tk5FieldInfoEx fieldInfo = dicOfInfo[columnName];
            string asgValue = null;
            if (fieldInfo != null)
            {
                bool valueError = false;
                if (fieldInfo.Decoder != null && fieldInfo.Decoder.Type == DecoderType.CodeTable)
                {
                    IEnumerable<IDecoderItem> data = ExcelUtil.GetDecoderItem(fieldInfo);

                    if (string.IsNullOrEmpty(strValue))
                    {
                        valueError = true;
                    }
                    else
                    {
                        foreach (IDecoderItem item in data)
                        {
                            if (item.Name == strValue)
                            {
                                asgValue = item.Value;
                                valueError = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (fieldInfo.InternalControl != null && fieldInfo.InternalControl.SrcControl == ControlType.CheckBox)
                    {
                        if (strValue == "√")
                        {
                            asgValue = ((fieldInfo.Extension == null) ? "1" : fieldInfo.Extension.CheckValue);
                            valueError = true;
                        }
                        if (string.IsNullOrEmpty(strValue))
                        {
                            asgValue = ((fieldInfo.Extension == null) ? "0" : fieldInfo.Extension.UnCheckValue);
                            valueError = true;
                        }
                    }
                    else
                    {      
                        asgValue = strValue;
                        valueError = true;
                    }
                }

                try
                {
                    if (!valueError)
                    {
                        throw new Exception("value in the cell is invalid");
                    }
                    else
                        dataRow[fieldInfo.NickName] = asgValue;
                }
                catch (Exception ex)
                {
                    imResult = new ImportWarningItem(indexOfRow, columnName, asgValue, ex.Message);
                }
            }
            return imResult;
        }

        #endregion
    }
}
