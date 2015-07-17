using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace TestData
{
    /// <summary>
    /// 创建Excel模板录入数据,并导入到DataSet
    /// </summary>
    public class NPOIRead
    {
        #region 根据模板sheet和元数据导入Excel

        public static DataSet ExcelImport(string strFileName, Tk5ListMetaData metaInfos, ResultHolder resultHolder)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = DataSetUtil.CreateDataTable(metaInfos.Table.TableName, metaInfos.Table.TableList);
            string sheetName = metaInfos.Table.TableDesc;
            HSSFWorkbook hssfworkbook = null;
            XSSFWorkbook xssfworkbook = null;
            ISheet sheet = null;

            string fileExt = Path.GetExtension(strFileName);
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (fileExt == ".xls")
                    hssfworkbook = new HSSFWorkbook(file);
                else if (fileExt == ".xlsx")
                    xssfworkbook = new XSSFWorkbook(file);
            }

            if (hssfworkbook != null)
            {
                sheet = hssfworkbook.GetSheet(sheetName);
            }
            else if (xssfworkbook != null)
            {
                sheet = xssfworkbook.GetSheet(sheetName);
            }

            SheetImport(metaInfos, dataTable, sheet, resultHolder);
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        private static void SheetImport(Tk5ListMetaData metaInfos, DataTable dataTable, ISheet sheet,
            ResultHolder resultHolder)
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
                    for (int j = headerRow.FirstCellNum; j < headerRow.LastCellNum; j++)
                    {
                        columnName = headerRow.GetCell(j).ToString();
                        cell = row.GetCell(j);
                        strValue = ((cell == null) ? string.Empty : cell.ToString());
                        ImportResult imResult = TablePadding(dataRow, columnName, dicOfInfo, strValue, i);
                        if (imResult != null)
                        {
                            resultHolder.Add(imResult);
                        }
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }
        }

        // 设置DataTable的值
        private static ImportResult TablePadding(DataRow dataRow, string columnName, Dictionary<string,
            Tk5FieldInfoEx> dicOfInfo, string strValue, int indexOfRow)
        {
            ImportResult imResult = null;
            Tk5FieldInfoEx fieldInfo = dicOfInfo[columnName];
            string asgValue = null;
            if (fieldInfo != null)
            {
                if (fieldInfo.Decoder != null && fieldInfo.Decoder.Type == DecoderType.CodeTable)
                {
                    IEnumerable<IDecoderItem> data = GetDecoderItem(fieldInfo);
                    foreach (IDecoderItem item in data)
                    {
                        if (item.Name == strValue)
                        {
                            asgValue = item.Value;
                            break;
                        }
                    }
                }
                else
                {
                    if (fieldInfo.InternalControl != null && fieldInfo.InternalControl.SrcControl == ControlType.CheckBox)
                    {
                        if (strValue == "√")
                            asgValue = ((fieldInfo.Extension == null) ? "1" : fieldInfo.Extension.CheckValue);
                        else
                            asgValue = ((fieldInfo.Extension == null) ? "0" : fieldInfo.Extension.UnCheckValue);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(strValue))
                        {
                            asgValue = strValue;
                        }
                    }
                }

                try
                {
                    dataRow[fieldInfo.NickName] = asgValue;
                }
                catch (Exception ex)
                {
                    imResult = new ImportResult(indexOfRow, columnName, asgValue, ex.Message);
                }
            }
            return imResult;
        }

        #endregion

        #region 创建导入模板

        // 模板
        public static byte[] CreateExcelTemplate(Tk5ListMetaData metaData)
        {
            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(metaData.Table.TableDesc);
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
                int index = 0;
                ExportExcelPageMaker headerConfigData =
                    new ExportExcelPageMaker(ContentFormat.DefaultHead, ContentFormat.DefaultContent) { UserBorder = true };
                ExportExcelPageMaker contentConfigData =
                    new ExportExcelPageMaker(ContentFormat.DefaultHead, ContentFormat.DefaultContent) { UserBorder = false };

                foreach (Tk5FieldInfoEx fieldInfo in metaData.Table.TableList)
                {
                    int colWith = NPOIWrite.GetColWidth(fieldInfo);
                    sheet.SetColumnWidth(index, colWith << 8);                  
                    ICellStyle styleContent = NPOIWrite.BorderAndFontSetting(workbook, 
                        contentConfigData, fieldInfo, NPOIWrite.Model.Content);
                    HSSFDataValidation dataValidate = CreateDataValidation(index, fieldInfo, styleContent, workbook);
                    sheet.SetDefaultColumnStyle(index, styleContent);
                    if (dataValidate != null)
                    {
                        ((HSSFSheet)sheet).AddValidationData(dataValidate);
                    }

                    ICell cell = dataRow.CreateCell(index);
                    ICellStyle styleHeader = NPOIWrite.BorderAndFontSetting(workbook, 
                        headerConfigData, fieldInfo, NPOIWrite.Model.Header);
                    cell.SetCellValue(fieldInfo.DisplayName);
                    cell.CellStyle = styleHeader;
                    index++;
                }
                //string strFileName = @"D:\EmportTemplateTest.xls";
                //using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                //{
                //    workbook.Write(fs);
                //}

                workbook.Write(ms);
                ms.Flush();
                return ms.ToArray();
            }
        }

        //数据有效性以及下拉框的设置
        private static HSSFDataValidation CreateDataValidation(int index, Tk5FieldInfoEx fieldInfo, 
            ICellStyle styleContent, HSSFWorkbook workbook)
        {
            IDataFormat format = workbook.CreateDataFormat();
            CellRangeAddressList region = new CellRangeAddressList(1, 65535, index, index);
            DVConstraint constraint = null;
            HSSFDataValidation dataValidation = null;
            if (fieldInfo.Decoder != null && fieldInfo.Decoder.Type == DecoderType.CodeTable)
            {
                IEnumerable<IDecoderItem> data = GetDecoderItem(fieldInfo);
                if (data != null)
                {
                    List<string> optionList = new List<string>();
                    foreach (IDecoderItem item in data)
                    {
                        if (item != null)
                        {
                            TkDebug.AssertArgumentNullOrEmpty(item.Name, "item.Name", null);
                            optionList.Add(item.Name);
                        }
                    }
                    constraint = DVConstraint.CreateExplicitListConstraint(optionList.ToArray());
                    dataValidation = DisplayMsg(region, constraint, "请从下拉框选项中选择");
                }
            }
            else
            {
                if (fieldInfo.InternalControl != null && fieldInfo.InternalControl.SrcControl == ControlType.CheckBox)
                {
                    constraint = DVConstraint.CreateExplicitListConstraint(new string[] { "√" });
                    dataValidation = DisplayMsg(region, constraint, "请在下拉框选项中进行选择");
                }
                else
                {
                    switch (fieldInfo.DataType)
                    {
                        case TkDataType.DateTime:
                        case TkDataType.Date:
                            if (fieldInfo.DataType == TkDataType.DateTime)
                                styleContent.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm");
                            else
                                styleContent.DataFormat = format.GetFormat("yyyy-MM-dd");
                            constraint = DVConstraint.CreateDateConstraint(6, "1900-01-01", null, "yyyy-MM-dd");
                            dataValidation = DisplayMsg(region, constraint, "请输入一个日期类型的值");
                            break;
                        case TkDataType.Double:
                        case TkDataType.Decimal:
                        case TkDataType.Money:
                            constraint = DVConstraint.CreateNumericConstraint(2, 1, "1", "0");
                            dataValidation = DisplayMsg(region, constraint, "请输入数值类型的值");
                            styleContent.DataFormat = format.GetFormat("0");
                            break;
                        case TkDataType.Long:
                        case TkDataType.Int:
                        case TkDataType.Short:
                        case TkDataType.Byte:
                        case TkDataType.Bit:
                            constraint = DVConstraint.CreateNumericConstraint(1, 1, "1", "0");
                            dataValidation = DisplayMsg(region, constraint, "请输入一个整数");
                            styleContent.DataFormat = format.GetFormat("0");
                            break;
                        default:
                            styleContent.DataFormat = format.GetFormat("@");
                            break;
                    }
                }
            }
            return dataValidation;
        }

        private static HSSFDataValidation DisplayMsg(CellRangeAddressList region, DVConstraint constraint, string errorMsg)
        {
            HSSFDataValidation dataValidate = new HSSFDataValidation(region, constraint);
            dataValidate.CreateErrorBox("error", errorMsg);
            return dataValidate;
        }

        #endregion

        // checkbox下拉菜单选项值
        private static IEnumerable<IDecoderItem> GetDecoderItem(Tk5FieldInfoEx fieldInfo)
        {
            CodeTableContainer ctContainer = new CodeTableContainer();
            string regName = fieldInfo.Decoder.RegName;
            CodeTable codeTable = PlugInFactoryManager.CreateInstance<CodeTable>(
                CodeTablePlugInFactory.REG_NAME, regName);
            codeTable.Fill(ctContainer);
            IEnumerable<IDecoderItem> data = ctContainer[regName];
            return data;
        }
    }
}
