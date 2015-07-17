using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Excel
{
    internal static class ExcelUtil
    {
        public const string ORIGINAL_ROWNUM = "在Excel表中的行数";
        #region 内容值填充

        public static void CellPadding(string value, ICell cell, Tk5FieldInfoEx fieldInfo)
        {
            Tk5ExtensionConfig exConfig = fieldInfo.Extension;
            if (exConfig != null && exConfig.Format != null)
            {
                string strformat = string.Format(ObjectUtil.SysCulture, "{{0:{0}}}", exConfig.Format);
                string result = string.Format(ObjectUtil.SysCulture, strformat, value);
                cell.SetCellValue(result);
            }
            else
            {
                switch (fieldInfo.DataType)
                {
                    case TkDataType.Long:
                    case TkDataType.Int:
                    case TkDataType.Short:
                    case TkDataType.Byte:
                    case TkDataType.Double:
                    case TkDataType.Decimal:
                    case TkDataType.Money:
                        double number = value.Value<double>();
                        cell.SetCellValue(number);
                        break;
                    case TkDataType.String:
                    case TkDataType.Text:
                    case TkDataType.Guid:
                    case TkDataType.Xml:
                        cell.SetCellValue(value);
                        break;
                    case TkDataType.DateTime:
                    case TkDataType.Date:
                        DateTime dt = value.Value<DateTime>();
                        cell.SetCellValue(dt);
                        break;
                }
            }
        }

        #endregion

        #region 列宽设置

        public static int GetColWidth(Tk5FieldInfoEx fieldInfo)
        {
            int columnWith = 0;

            // 汉字宽度与excel字符宽度的转换
            int titleLength = fieldInfo.DisplayName.Length * 2 + 4;

            if (fieldInfo.ListDetail != null && fieldInfo.ListDetail.ListWidth > 0)
                columnWith = fieldInfo.ListDetail.ListWidth / 7 + 4;
            else
            {
                if (fieldInfo.InternalControl != null && fieldInfo.InternalControl.SrcControl == ControlType.CheckBox)
                    columnWith = 6;
                else
                {
                    switch (fieldInfo.DataType)
                    {
                        case TkDataType.Date:
                            columnWith = 14;
                            break;
                        case TkDataType.DateTime:
                            columnWith = 20;
                            break;
                        case TkDataType.Long:
                        case TkDataType.Int:
                        case TkDataType.Double:
                        case TkDataType.Decimal:
                        case TkDataType.Text:
                        case TkDataType.Guid:
                        case TkDataType.Xml:
                            if (fieldInfo.Length > 0 && fieldInfo.Length < 12)
                                columnWith = fieldInfo.Length + 4;
                            else if (fieldInfo.Length >= 12)
                                columnWith = 16;
                            break;
                        case TkDataType.Short:
                        case TkDataType.Byte:
                            columnWith = 8;
                            break;
                        case TkDataType.String:
                            if (fieldInfo.Length > 0)
                                columnWith = ((fieldInfo.Length / 3) > 70) ? 70 : (fieldInfo.Length / 3);
                            else
                                columnWith = 16;
                            break;
                    }
                }
            }
            return ((columnWith > titleLength) ? columnWith : titleLength);
        }

        #endregion

        #region 边框、字体以及对齐设置

        // 字体设置
        public static IFont FontSetting(IWorkbook workbook, ExcelContentFormat excelFormat)
        {
            IFont fontContent = workbook.CreateFont();

            if (!string.IsNullOrEmpty(excelFormat.FontName))
                fontContent.FontName = excelFormat.FontName;

            if (excelFormat.FontBold)
                fontContent.Boldweight = (short)FontBoldWeight.Bold;

            if (excelFormat.FontSize > 0)
                fontContent.FontHeightInPoints = excelFormat.FontSize;
            return fontContent;
        }

        // 对齐设置
        public static void AlignSetting(Alignment align, ICellStyle cellStyle)
        {
            switch (align)
            {
                case Alignment.Center:
                    cellStyle.Alignment = HorizontalAlignment.Center;
                    break;
                case Alignment.Left:
                    cellStyle.Alignment = HorizontalAlignment.Left;
                    break;
                case Alignment.Right:
                    cellStyle.Alignment = HorizontalAlignment.Right;
                    break;
            }
        }

        #endregion

        private static HSSFDataValidation DisplayMsg(CellRangeAddressList region,
            DVConstraint constraint, string errorMsg)
        {
            HSSFDataValidation dataValidate = new HSSFDataValidation(region, constraint);
            dataValidate.CreateErrorBox("error", errorMsg);
            return dataValidate;
        }

        //数据有效性以及下拉框的设置
        public static HSSFDataValidation CreateDataValidation(int index, Tk5FieldInfoEx fieldInfo,
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

        // checkbox下拉菜单选项值
        public static IEnumerable<IDecoderItem> GetDecoderItem(Tk5FieldInfoEx fieldInfo)
        {
            CodeTableContainer ctContainer = new CodeTableContainer();
            string regName = fieldInfo.Decoder.RegName;
            CodeTable codeTable = PlugInFactoryManager.CreateInstance<CodeTable>(
                CodeTablePlugInFactory.REG_NAME, regName);
            codeTable.Fill(ctContainer);
            IEnumerable<IDecoderItem> data = ctContainer[regName];
            return data;
        }

        public static DataSet DataSetReport(string strFileName, Tk5ListMetaData metaInfos, ImportError importError)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = CreateDataTable(metaInfos.Table.TableName, metaInfos.Table.TableList);
            dataTable.Columns.Add(ORIGINAL_ROWNUM, typeof(int));
            IWorkbook workbook;
            ISheet sheet;
            string columnName = string.Empty;

            ReadExcle(strFileName, metaInfos.Table.TableDesc, out workbook, out sheet);

            var positions = (from index in importError
                       orderby index.IndexOfRow ascending
                       select index.IndexOfRow).Distinct();

            IRow headerRow = sheet.GetRow(0);

            foreach (var index in positions)
            {
                IRow row = sheet.GetRow(index);
                DataRow dataRow = dataTable.NewRow();
                for (int i = headerRow.FirstCellNum; i < headerRow.LastCellNum; i++)
                {
                    dataRow[headerRow.GetCell(i).ToString()] = row.GetCell(i);
                    dataRow[ORIGINAL_ROWNUM] = index;
                }

                dataTable.Rows.Add(dataRow);
            }

            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        public static byte[] ExcelReport(string strFileName, Tk5ListMetaData metaInfos, ImportError importError)
        {
            MemoryStream ms = new MemoryStream();
            ExcelExporter exporter = 
                new ExcelExporter(false, ExcelContentFormat.DefaultHeader, ExcelContentFormat.DefaultContent, metaInfos);

            using (ms)
            {
                IWorkbook workBook;
                ISheet sheet;

                ReadExcle(strFileName, metaInfos.Table.TableDesc, out workBook, out sheet);
                PostilAdd(metaInfos, importError, workBook, sheet);
                RowFilter(importError, sheet);
            
                workBook.Write(ms);
                byte[] filedata = ms.ToArray();
                ms.Flush();

                using (FileStream fs = new FileStream(@"C:\Users\zll\Downloads\ImportReport.xls", FileMode.Create))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(filedata);
                    bw.Close();
                    fs.Close();
                }

                return filedata;
            }

        }
        
        private static DataTable CreateDataTable(string tableName, List<Tk5FieldInfoEx> list)
        {
            DataTable table = new DataTable(tableName);
            foreach (IFieldInfo info in list)
            {
                table.Columns.Add(new DataColumn(info.DisplayName, MetaDataUtil.ConvertDataTypeToType(info.DataType)));
            }
            return table;
        }

        internal static void ReadExcle(string strFileName, string sheetName, out IWorkbook workbook, out ISheet sheet)
        {
            workbook = null;
            sheet = null;
            string fileExt = Path.GetExtension(strFileName);
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (fileExt == ".xls")
                    workbook = new HSSFWorkbook(file);
                else if (fileExt == ".xlsx")
                    workbook = new XSSFWorkbook(file);
            }

            if (workbook != null)
            {
                sheet = workbook.GetSheet(sheetName);
            }
        }

        private static void RowFilter(ImportError importError, ISheet sheet)
        {
            int counter = 0;
            var res = (from err in importError
                       select err.IndexOfRow).Distinct();

            foreach (var rowNum in res)
            {
                sheet.ShiftRows(rowNum, rowNum, 1 - rowNum + counter);
                counter++;
            }

            for (int rowNum = counter + 1; rowNum <= sheet.LastRowNum; rowNum++)
            {
                IRow row = sheet.GetRow(rowNum);
                sheet.RemoveRow(row);
            }
        }

        private static void PostilAdd(Tk5ListMetaData metaInfos, ImportError importError, IWorkbook workBook, ISheet sheet)
        {
            IDrawing part = sheet.CreateDrawingPatriarch();
            Dictionary<string, int> indexOfName = new Dictionary<string, int>();
            int i = 0;

            foreach (var info in metaInfos.Table.TableList)
            {
                indexOfName.Add(info.DisplayName, i);
                i++;
            }

            foreach (var err in importError)
            {
                IRow row = sheet.GetRow(err.IndexOfRow);
                IComment comment = null;
                ICell cell = row.GetCell(indexOfName[err.ColumnName]);
                ICreationHelper factory = workBook.GetCreationHelper();
                IClientAnchor anchor = null;
                anchor = factory.CreateClientAnchor();
                anchor.Col1 = cell.ColumnIndex + 2;
                anchor.Col2 = cell.ColumnIndex + 4;
                anchor.Row1 = row.RowNum;
                anchor.Row2 = row.RowNum + 3;
                comment = part.CreateCellComment(anchor);
                comment.Author = "mitu";
                comment.String = new HSSFRichTextString(err.ErrorMsg);
                cell.CellComment = comment;
            }
        }
    }
}
