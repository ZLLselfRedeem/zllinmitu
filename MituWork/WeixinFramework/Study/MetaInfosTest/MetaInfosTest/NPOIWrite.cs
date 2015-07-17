using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
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
    /// 由数据源导出Excel
    /// </summary>
    internal class NPOIWrite
    {
        internal enum Model
        {
            Content,
            Header
        }

        public static byte[] ExportExcel(OutputData dataSource, ExportExcelPageMaker configData)
        {
            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                IWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet(configData.fMetaData.Table.TableDesc);

                HeaderSetting(configData, workbook, sheet);

                Dictionary<string, ICellStyle> ContentStyles = GetContentStyles(workbook, configData);

                if (dataSource.Data is DataSet)
                {
                    DataSet ds = (DataSet)dataSource.Data;
                    TkDebug.AssertArgumentNull(ds, "ds", null);
                    DataTable dt = ds.Tables[configData.fMetaData.Table.TableName];
                    if (dt != null)
                    {
                        DataTableExport(configData, ContentStyles, sheet, dt);
                    }
                }

                if (dataSource.Data is ObjectListModel)
                {
                    ObjectListModel objectLM = (ObjectListModel)dataSource.Data;
                    if (objectLM.List != null)
                    {
                        ObjectExport(configData, ContentStyles, sheet, objectLM);
                    }
                }

                workbook.Write(ms);
                ms.Flush();
                return ms.ToArray();
            }
        }

        // 表格头部设置
        private static void HeaderSetting(ExportExcelPageMaker configData, IWorkbook workbook, ISheet sheet)
        {
            IRow dataRow = sheet.CreateRow(0);

            int index = 0;
            foreach (Tk5FieldInfoEx fieldInfo in configData.fMetaData.Table.TableList)
            {
                ICell cell = dataRow.CreateCell(index);
                ICellStyle styleHeader = BorderAndFontSetting(workbook, configData, fieldInfo, Model.Header);
                cell.SetCellValue(fieldInfo.DisplayName);
                cell.CellStyle = styleHeader;
                int colWith = GetColWidth(fieldInfo);
                sheet.SetColumnWidth(index, colWith << 8);
                index++;
            }
        }

        // 由微信类生成Excel
        private static void ObjectExport(ExportExcelPageMaker configData,
            Dictionary<string, ICellStyle> contentStyles, ISheet sheet, ObjectListModel objectLM)
        {
            int rowIndex = 1;
            foreach (ObjectContainer container in objectLM.List)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                int columnIndex = 0;
                object receiver = container.MainObject;
                string strValue = string.Empty;
                foreach (Tk5FieldInfoEx fieldInfo in configData.fMetaData.Table.TableList)
                {
                    ICell cell = dataRow.CreateCell(columnIndex);

                    if (fieldInfo != null)
                    {
                        if (fieldInfo.Decoder == null || fieldInfo.Decoder.Type == DecoderType.None)
                        {
                            strValue = receiver.MemberValue(fieldInfo.NickName).ConvertToString();
                            CellPadding(strValue, cell, fieldInfo);
                        }
                        else
                            strValue = container.Decoder.GetNameString(fieldInfo.NickName);

                        cell.CellStyle = contentStyles[fieldInfo.NickName];
                    }
                    columnIndex++;
                }
                rowIndex++;
            }
        }

        // 有DataTable生成Excel
        private static void DataTableExport(ExportExcelPageMaker configData,
            Dictionary<string, ICellStyle> contentStyles, ISheet sheet, DataTable dataTable)
        {
            int rowIndex = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                int columnIndex = 0;
                foreach (Tk5FieldInfoEx fieldInfo in configData.fMetaData.Table.TableList)
                {
                    ICell cell = dataRow.CreateCell(columnIndex);

                    if (fieldInfo != null)
                    {
                        string strValue = string.Empty;
                        Tk5ExtensionConfig ex = fieldInfo.Extension;
                        SimpleFieldControl sfctrl = fieldInfo.InternalControl;
                        if (fieldInfo.Decoder == null || fieldInfo.Decoder.Type == DecoderType.None)
                        {
                            strValue = (row[fieldInfo.NickName]).ToString();

                            if (!string.IsNullOrEmpty(strValue))
                            {
                                if (sfctrl != null && sfctrl.SrcControl == ControlType.CheckBox)
                                {
                                    if ((ex != null && strValue == ex.CheckValue) ||
                                        (ex == null && strValue == "1"))
                                        cell.SetCellValue("√");
                                }
                                else
                                    CellPadding(strValue, cell, fieldInfo);
                            }
                        }
                        else
                        {
                            strValue = row[fieldInfo.NickName + "_Name"].ToString();

                            if (!string.IsNullOrEmpty(strValue))
                            {
                                if (sfctrl != null &&
                                    (sfctrl.SrcControl == ControlType.CheckBoxList ||
                                    sfctrl.SrcControl == ControlType.MultipleEasySearch))
                                {
                                    MultipleDecoderData data = MultipleDecoderData.ReadFromString(strValue);
                                    cell.SetCellValue(string.Join(", ", data));
                                }
                                else
                                    cell.SetCellValue(strValue);
                            }
                        }
                        cell.CellStyle = contentStyles[fieldInfo.NickName];
                    }
                    columnIndex++;
                }
                rowIndex++;
            }
        }

        #region 列宽设置

        internal static int GetColWidth(Tk5FieldInfoEx fieldInfo)
        {
            int columnWith = 0;

            // 汉字宽度与excel字符个数转换
            int length = fieldInfo.DisplayName.Length * 2 + 1;

            if (fieldInfo.ListDetail != null && fieldInfo.ListDetail.ListWidth > 0)
                columnWith = fieldInfo.ListDetail.ListWidth / 7 + 1;
            else
            {
                if (fieldInfo.InternalControl != null && fieldInfo.InternalControl.SrcControl == ControlType.CheckBox)
                    columnWith = 2;
                else
                {
                    switch (fieldInfo.DataType)
                    {
                        case TkDataType.Date:
                            columnWith = 12;
                            break;
                        case TkDataType.DateTime:
                            columnWith = 18;
                            break;
                        case TkDataType.Long:
                        case TkDataType.Int:
                        case TkDataType.Double:
                        case TkDataType.Decimal:
                        case TkDataType.String:
                        case TkDataType.Text:
                        case TkDataType.Guid:
                        case TkDataType.Xml:
                            if (fieldInfo.Length > 0 && fieldInfo.Length < 10)
                            {
                                columnWith = fieldInfo.Length;
                            }
                            else
                                columnWith = 10;
                            break;
                        case TkDataType.Short:
                        case TkDataType.Byte:
                            columnWith = 6;
                            break;
                    }
                }
            }
            return ((columnWith > length) ? columnWith : length);
        }

        #endregion

        #region 边框、字体以及对齐设置

        internal static ICellStyle BorderAndFontSetting(IWorkbook workbook, ExportExcelPageMaker configData,
            Tk5FieldInfoEx metaInfo, Model model)
        {
            ICellStyle cellStyle = workbook.CreateCellStyle();

            if (configData.UserBorder)
            {
                cellStyle.BorderTop = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
            }

            if (model == Model.Content)
            {
                IFont fontContent = FontSetting(workbook, configData.Content);

                cellStyle.SetFont(fontContent);

                if (metaInfo.Extension != null)
                {
                    AlignSetting(metaInfo.Extension.Align, cellStyle);
                }
                else
                {
                    AlignSetting(configData.Content.Align, cellStyle);
                }
            }
            else
            {
                AlignSetting(configData.Header.Align, cellStyle);
                IFont fontHeader = FontSetting(workbook, configData.Header);
                cellStyle.SetFont(fontHeader);
            }
            return cellStyle;
        }

        // 字体设置
        private static IFont FontSetting(IWorkbook workbook, ExcelContentFormat excelFormat)
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
        private static void AlignSetting(Alignment align, ICellStyle cellStyle)
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

        #region 内容格式创建

        //生成Dictionary<NickName, ICellStyle>， 每一列对应每一个ICellStyle，通过NickName来获取ICellStyle
        private static Dictionary<string, ICellStyle> GetContentStyles(IWorkbook workbook, ExportExcelPageMaker configData)
        {
            Dictionary<string, ICellStyle> NameToStyle = new Dictionary<string, ICellStyle>();
            IDataFormat format = workbook.CreateDataFormat();

            foreach (Tk5FieldInfoEx fieldInfo in configData.fMetaData.Table.TableList)
            {
                ICellStyle cellStyle = BorderAndFontSetting(workbook, configData, fieldInfo, Model.Content);
                if (fieldInfo.Extension != null && !string.IsNullOrEmpty(fieldInfo.Extension.Format))
                    cellStyle.DataFormat = format.GetFormat("@");
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
                            if (fieldInfo.DataType == TkDataType.Money)
                                cellStyle.DataFormat = format.GetFormat("￥#,##0");
                            else
                                cellStyle.DataFormat = format.GetFormat("0");
                            break;
                        case TkDataType.String:
                        case TkDataType.Text:
                        case TkDataType.Guid:
                        case TkDataType.Xml:
                            cellStyle.DataFormat = format.GetFormat("@");
                            break;
                        case TkDataType.DateTime:
                        case TkDataType.Date:
                            if (fieldInfo.DataType == TkDataType.DateTime)
                                cellStyle.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm");
                            else
                                cellStyle.DataFormat = format.GetFormat("yyyy-MM-dd");
                            break;
                    }
                }
                NameToStyle.Add(fieldInfo.NickName, cellStyle);
            }
            return NameToStyle;
        }

        #endregion

        #region 内容值填充

        private static void CellPadding(string value, ICell cell, Tk5FieldInfoEx fieldInfo)
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
    }
}
