using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.Format;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace NpoiStudy
{
    public class NPOIWrite
    {
        //#region 相关方法1

        //void CreateSheet()
        //{
        //    IWorkbook workbook = new HSSFWorkbook();
        //    ISheet sheet = workbook.CreateSheet("Sheet1");
        //    IRow row = sheet.CreateRow(0);
        //    ICell cell = row.CreateCell(0);
        //    cell.SetCellValue("test");
        //}

        //void GetSheet(Stream stream)
        //{
        //    IWorkbook workbook = new HSSFWorkbook(stream);
        //    ISheet sheet = workbook.GetSheetAt(0);
        //    IRow row = sheet.GetRow(0);
        //    ICell cell = row.GetCell(0);
        //    string value = cell.ToString();
        //}

        //public static void GetAndEditSheet()
        //{
        //    string tempPath = "d:\\excel.xls";
        //    HSSFWorkbook wk = null;
        //    using (FileStream fs = File.Open(tempPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        //    {
        //        wk = new HSSFWorkbook(fs);
        //        fs.Close();
        //    }

        //    var sheet = wk.GetSheetAt(0);
        //    ICell cell = sheet.CreateRow(1).CreateCell(0);
        //    cell.SetCellValue("nihao");
        //    sheet.GetRow(0).GetCell(0).SetCellValue("编辑的值");

        //    using (FileStream fileStream = File.Open(tempPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
        //        wk.Write(fileStream);
        //        fileStream.Close();
        //    }
        //}

        //public static MemoryStream RenderDataTableToExcel(DataTable SourceTable)
        //{
        //    MemoryStream ms = new MemoryStream();

        //    HSSFWorkbook workbook = new HSSFWorkbook();
        //    ISheet sheet = workbook.CreateSheet();

        //    IRow headerRow = sheet.CreateRow(0);

        //    foreach (DataColumn column in SourceTable.Columns)
        //    {
        //        headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
        //    }

        //    int rowIndex = 1;

        //    foreach (DataRow row in SourceTable.Rows)
        //    {
        //        IRow dataRow = sheet.CreateRow(rowIndex);
        //        foreach (DataColumn column in SourceTable.Columns)
        //        {
        //            dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
        //        }

        //        rowIndex++;
        //    }

        //    //using (FileStream fs = File.OpenWrite("d:\\excel1.xls"))
        //    //{
        //    //    workbook.Write(fs);
        //    //}

        //    workbook.Write(ms);
        //    ms.Flush();
        //    ms.Position = 0;

        //    return ms;
        //}

        //#endregion


        #region 根据模板导入Excel

        public static DataTable ImportExcel(string strFileName, Tk5ListMetaData metaInfos, int sheetIndex = 0)
        {
            DataTable dataTable = DataSetUtil.CreateDataTable(metaInfos.Table.TableName, metaInfos.Table.TableList);

            HSSFWorkbook hssfworkbook = null;
            XSSFWorkbook xssfworkbook = null;
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
                HSSFSheet hSheet = (HSSFSheet)hssfworkbook.GetSheetAt(sheetIndex);
                if (hSheet != null)
                {
                    HSSFRow headerRow = (HSSFRow)hSheet.GetRow(0);
                    for (int i = (hSheet.FirstRowNum + 1); i <= hSheet.LastRowNum; i++)
                    {
                        HSSFRow row = (HSSFRow)hSheet.GetRow(i);
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                        {
                            string columnName = headerRow.GetCell(j).ToString();
                            string strValue = row.GetCell(j).ToString();
                            TablePadding(dataRow, columnName, metaInfos, strValue);
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            else if (xssfworkbook != null)
            {
                XSSFSheet xSheet = (XSSFSheet)xssfworkbook.GetSheetAt(sheetIndex);
                if (xSheet != null)
                {
                    XSSFRow headerRow = (XSSFRow)xSheet.GetRow(0);
                    for (int i = (xSheet.FirstRowNum + 1); i <= xSheet.LastRowNum; i++)
                    {
                        XSSFRow row = (XSSFRow)xSheet.GetRow(i);
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                        {
                            string columnName = headerRow.GetCell(j).ToString();
                            string strValue = row.GetCell(j).ToString();
                            TablePadding(dataRow, columnName, metaInfos, strValue);
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            return dataTable;
        }

        internal static DataTable ExcelToDataTable(string strFileName, int sheetIndex = 0)
        {
            DataTable dt = new DataTable();
            HSSFWorkbook hssfworkbook = null;
            XSSFWorkbook xssfworkbook = null;
            string fileExt = Path.GetExtension(strFileName);//获取文件的后缀名
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                if (fileExt == ".xls")
                    hssfworkbook = new HSSFWorkbook(file);
                else if (fileExt == ".xlsx")
                    xssfworkbook = new XSSFWorkbook(file);//初始化太慢了，不知道这是什么bug
            }
            if (hssfworkbook != null)
            {
                HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(sheetIndex);
                if (sheet != null)
                {
                    System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                    HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                        dt.Columns.Add(cell.ToString());
                    }
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        HSSFRow row = (HSSFRow)sheet.GetRow(i);
                        DataRow dataRow = dt.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
            }
            else if (xssfworkbook != null)
            {
                XSSFSheet xSheet = (XSSFSheet)xssfworkbook.GetSheetAt(sheetIndex);
                if (xSheet != null)
                {
                    System.Collections.IEnumerator rows = xSheet.GetRowEnumerator();
                    XSSFRow headerRow = (XSSFRow)xSheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        XSSFCell cell = (XSSFCell)headerRow.GetCell(j);
                        dt.Columns.Add(cell.ToString());
                    }
                    for (int i = (xSheet.FirstRowNum + 1); i <= xSheet.LastRowNum; i++)
                    {
                        XSSFRow row = (XSSFRow)xSheet.GetRow(i);
                        DataRow dataRow = dt.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
            }
            return dt;
        }

        private static void TablePadding(DataRow dataRow, string columnName, Tk5ListMetaData metaInfos, string strValue)
        {
            Tk5FieldInfoEx fieldInfo = metaInfos.Table.TableList.Find(ex => ex.NickName == columnName);
            if (fieldInfo != null)
            {
                if (fieldInfo.InternalControl != null && fieldInfo.InternalControl.SrcControl == ControlType.CheckBox)
                {
                    if (strValue == "√")
                        dataRow[columnName] = ((fieldInfo.Extension == null) ? "1" : fieldInfo.Extension.CheckValue);
                    else
                        dataRow[columnName] = ((fieldInfo.Extension == null) ? "0" : fieldInfo.Extension.UnCheckValue);
                }
                else
                {
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        try
                        {
                            dataRow[columnName] = strValue;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("the Exception: {0}", e.Message);
                            Console.WriteLine("Excel导入时：单元格的值与数据类型不匹配");
                        }
                    }
                }
            }
        }

        #endregion

        //#region 设计Excel模板

        //public static byte[] GetTemplate(Tk5ListMetaData metaInfos)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    using (ms)
        //    {
        //        HSSFWorkbook workbook = new HSSFWorkbook();
        //        HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet(metaInfos.Table.TableDesc);
        //        HSSFRow row = (HSSFRow)sheet.CreateRow(0);

        //        int index = 0;
        //        foreach(Tk5FieldInfoEx meta)
        //    }
        //}

        //#endregion

        #region 相关的方法2

        //public static void InitializeWorkbook(HSSFWorkbook workbook)
        //{
        //    ////create a entry of DocumentSummaryInformation
        //    if (workbook == null)
        //        workbook = new HSSFWorkbook();
        //    //HSSFFont font1 = workbook.CreateFont();
        //    //HSSFCellStyle Style = workbook.CreateCellStyle();
        //    //font1.FontHeightInPoints = 10;
        //    //font1.FontName = "新細明體";
        //    //Style.SetFont(font1);
        //    //for (int i = 0; i < workbook.NumberOfSheets; i++)
        //    //{
        //    //    HSSFSheet Sheets = workbook.GetSheetAt(0);
        //    //    for (int k = Sheets.FirstRowNum; k <= Sheets.LastRowNum; k++)
        //    //    {
        //    //        HSSFRow row = Sheets.GetRow(k);
        //    //        for (int l = row.FirstCellNum; l < row.LastCellNum; l++)
        //    //        {
        //    //            HSSFCell Cell = row.GetCell(l);
        //    //            Cell.CellStyle = Style;
        //    //        }
        //    //    }
        //    //}
        //    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        //    dsi.Company = "測試公司";
        //    workbook.DocumentSummaryInformation = dsi;
        //    ////create a entry of SummaryInformation
        //    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        //    si.Subject = "測試公司Excel檔案";
        //    si.Title = "測試公司Excel檔案";
        //    si.Author = "killysss";
        //    si.Comments = "謝謝您的使用！";
        //    workbook.SummaryInformation = si;
        //}


        ////对象保存在流中，可以通过以下方法输出到浏览器，或是保存到硬盘中:
        //public void SaveToFile(MemoryStream ms, string fileName)
        //{
        //    using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        //    {
        //        byte[] data = ms.ToArray();
        //        fs.Write(data, 0, data.Length);
        //        fs.Flush();
        //        data = null;
        //    }
        //}

        ////public void RenderToBrowser(MemoryStream ms, HttpContext context, string fileName) 
        ////{
        ////    if (context.Request.Browser.Browser == "IE")
        ////        fileName = HttpUtility.UrlEncode(fileName);
        ////    context.Response.AddHeader("Content-Disposition", "attachment;fileName=" + fileName);
        ////    context.Response.BinaryWrite(ms.ToArray());
        ////}

        #endregion

        #region 导出Excel

        public static void ExportEasy(string strFileName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            //ISheet sheet2 = workbook.CreateSheet("ShtDirectionary");
            //sheet2.CreateRow(0).CreateCell(0).SetCellValue("Red");
            //sheet2.CreateRow(1).CreateCell(0).SetCellValue("Yellow");
            //sheet2.CreateRow(2).CreateCell(0).SetCellValue("Black");
            //sheet2.CreateRow(3).CreateCell(0).SetCellValue("White");
            //sheet2.CreateRow(4).CreateCell(0).SetCellValue("Green");
            //IName range = workbook.CreateName();
            //range.RefersToFormula = "ShtDirectionary!$A1:A4";
            //range.NameName = "dicRange";

            ISheet sheet = workbook.CreateSheet("Test");
            IRow row = sheet.CreateRow(0);
            ICell cell1 = row.CreateCell(0);
            ICell cell2 = row.CreateCell(1);
            ICell cell3 = row.CreateCell(2);
            IDataFormat format = workbook.CreateDataFormat();
            ICellStyle cellStyle1 = workbook.CreateCellStyle();
            cellStyle1.DataFormat = format.GetFormat("yyyy-MM-dd HH:mm");
            sheet.SetDefaultColumnStyle(1, cellStyle1);

            cell1.SetCellValue("日期列");
            cell2.SetCellValue("数值列");
            cell3.SetCellValue("总公司");

            //CellRangeAddressList regions = new CellRangeAddressList(1, 65535, 0, 0);
            ////DVConstraint constraint = DVConstraint.CreateFormulaListConstraint("dicRange");
            //DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(new string[] { "Red", "Yellow", "Black" });
            //HSSFDataValidation dataValidate1 = new HSSFDataValidation(regions, constraint);
            //((HSSFSheet)sheet).AddValidationData(dataValidate1);

            CellRangeAddressList regions1 = new CellRangeAddressList(1, 65535, 0, 0);
            CellRangeAddressList regions2 = new CellRangeAddressList(1, 65535, 1, 1);
            CellRangeAddressList regions3 = new CellRangeAddressList(1, 65535, 2, 2);
 

            // string formulation = "left(right(A1,3),1)=\".\"";
            // string formula = "LEFT(RIGHT(A6,3),1)=\".\"";
            // DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(new string[] { "√", "   " });

            DVConstraint constraint1 = DVConstraint.CreateDateConstraint(6, "1900-01-01", null, "yyyy-MM-dd");
            DVConstraint constraint2 = DVConstraint.CreateNumericConstraint(6, 6, "0", null);
            DVConstraint constraint3 = DVConstraint.CreateExplicitListConstraint(new string[] { "√"});

            HSSFDataValidation dataValidate1 = new HSSFDataValidation(regions1, constraint1);
            dataValidate1.CreateErrorBox("error", "You must input a date");
            // dataValidate1.EmptyCellAllowed = false;

            HSSFDataValidation dataValidate2 = new HSSFDataValidation(regions2, constraint2);
            dataValidate2.CreateErrorBox("error", "You must input a valid value!");

            HSSFDataValidation dataValidate3 = new HSSFDataValidation(regions3, constraint3);
            dataValidate3.CreateErrorBox("error", "You must input a valid value!");

            ((HSSFSheet)sheet).AddValidationData(dataValidate2);
            ((HSSFSheet)sheet).AddValidationData(dataValidate1);
            ((HSSFSheet)sheet).AddValidationData(dataValidate3);

            #region 已注释内容（作为参考）

            //cellStyle1.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyle1.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyle1.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyle1.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            //cellStyle1.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //cellStyle1.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //cellStyle1.ShrinkToFit = true;

            //ICellStyle cellStyle2 = workbook.CreateCellStyle();

            //cellStyle2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            //cellStyle2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;

            //cellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            //cellStyle2.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //cellStyle2.ShrinkToFit = true;

            //ICellStyle cellStyle3 = workbook.CreateCellStyle();

            //cellStyle3.CloneStyleFrom(cellStyle2);
            //cellStyle3.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

            //ICellStyle cellStyle4 = workbook.CreateCellStyle();
            //cellStyle4.CloneStyleFrom(cellStyle2);
            //cellStyle4.DataFormat = format.GetFormat("@");

            //ICellStyle cellStyle5 = workbook.CreateCellStyle();
            //cellStyle5.CloneStyleFrom(cellStyle4);
            //cellStyle5.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            //// InitializeWorkbook(workbook);



            //sheet.SetColumnWidth(0, 15 * 256);
            //sheet.SetColumnWidth(1, 10 * 256);
            //sheet.SetColumnWidth(2, 19 * 256);

            //sheet.Header.Center = "zll NPOI Test";
            //sheet.Footer.Left = "Copyright mitu Team";
            //sheet.Footer.Right = "created by 2015";

            //ICellStyle style1 = workbook.CreateCellStyle();

            //// 设置字体
            //IFont font1 = workbook.CreateFont();
            //font1.FontName = "黑体";
            //font1.FontHeightInPoints = 12;
            //font1.Color = NPOI.HSSF.Util.HSSFColor.Green.Index;
            //style1.SetFont(font1);

            ////设置对其方式
            //style1.Alignment = HorizontalAlignment.Center;
            //style1.VerticalAlignment = VerticalAlignment.Center;
            //style1.WrapText = true;

            //ICellStyle cellStyle = workbook.CreateCellStyle();

            //cellStyle.DataFormat = format.GetFormat("yyyy-MM-dd");

            ////设置页眉页脚，打印预览
            //sheet.Header.Center = "This is a test sheet";
            //sheet.Footer.Left = "Copyright NPOI Team";
            //sheet.Footer.Right = "created by 2015-01-20";
            ////填充表头


            //IRow dataRow = sheet.CreateRow(0);
            //dataRow.HeightInPoints = 30;
            //foreach (DataColumn column in dtSource.Columns)
            //{
            //    sheet.SetColumnWidth(0, 10 * 256);
            //    ICell cell = dataRow.CreateCell(column.Ordinal);
            //    cell.CellStyle = style1;
            //    cell.SetCellValue(column.ColumnName);
            //}

            ////填充内容
            //for (int i = 0; i < dtSource.Rows.Count; i++)
            //{
            //    dataRow = sheet.CreateRow(i + 1);
            //    for (int j = 0; j < dtSource.Columns.Count; j++)
            //    {
            //        ICell cell = dataRow.CreateCell(j);
            //        cell.SetCellValue(Convert.ToDateTime(dtSource.Rows[i][j]));
            //        cell.CellStyle = cellStyle;
            //    }
            //}

            #endregion

            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }
        }

        #endregion

        //public static void StudyTest()
        //{
        //    IWorkbook workbook = new HSSFWorkbook();
        //    ISheet sheet = workbook.CreateSheet("StudyTest");
        //    IRow row = sheet.CreateRow(0);
        //    ICell cell1 = row.CreateCell(0);
        //    cell1.SetCellValue(123);
        //    ICell cell2 = sheet.CreateRow(1).CreateCell(0);
        //    ICellStyle style = workbook.CreateCellStyle();
        //    style.BorderDiagonalLineStyle = BorderStyle.Medium;
        //    style.BorderDiagonal = BorderDiagonal.Backward;
        //    // style.BorderDiagonalColor = IndexedColor.Red.Index;
        //}
    }
}
