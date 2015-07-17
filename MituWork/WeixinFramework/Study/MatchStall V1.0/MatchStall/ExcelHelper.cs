//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2013 , DZD , Ltd .
//-------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace MatchStall
{
	/// <summary>
	/// Excel�����࣬�����NPOIʹ�õ���2.0.1 (beta1)�汾��
	///
	/// �޸ļ�¼
	///
	///		2013-10-25 �汾��1.0 yanghenglian ����������ע�������ռ������
	///		2013-11-01 �汾��1.0 yanghenglian �����֧��B/S�ĵ����͵����Լ�C/S�ĵ����͵��빦�ܣ�����о��������Ż������ġ�
	///		2014-01-16 �汾��1.0 yanghenglian �����֧��xlsxExcel�ļ���ȡ�ж�
	/// 
	/// �汾��1.0
	///
	/// <author>
	///		<name>yanghenglian</name>
	///		<date>2013-11-01</date>
	/// </author>
	/// </summary>
	public class ExcelHelper
	{
		private static HSSFWorkbook _hssfworkbook;

		/********************************************************�������������հ汾�ʺ�B/S��C/S*****************************************************/

		#region ExcelToDataTable(string strExcelFileName, string strSheetName) Excelת����DataTable--B/S��C/S������ʹ��

		/// <summary>
		/// Excelת����DataTable
		/// </summary>
		/// <param name="strExcelFileName">�ļ�·��</param>
		/// <param name="strSheetName">Excel�ж�Ӧ��sheet������,��:sheet1,sheet2</param>
		/// <returns>���ݼ�</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:��� SQL ��ѯ�Ƿ���ڰ�ȫ©��")]
		public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
		{
			string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" +
							 "Extended Properties=Excel 5.0;";
			string strExcel = string.Format("select * from [{0}$]", strSheetName);
			DataSet ds = new DataSet();
			using (OleDbConnection conn = new OleDbConnection(strConn))
			{
				conn.Open();
				OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
				adapter.Fill(ds, strSheetName);
				conn.Close();
				return ds.Tables[strSheetName];
			}
		}

		#endregion

		#region DataTable ExcelToDataTable(string strFileName, int sheetIndex = 0) ����������ȡSheet�����ݣ�Ĭ�϶�ȡ��һ��sheet--B/S��C/S������ʹ��

		/// <summary>��ȡexcel
		/// ����������ȡSheet�����ݣ�Ĭ�϶�ȡ��һ��sheet
		/// </summary>
		/// <param name="strFileName">excel�ĵ�·��</param>
		/// <param name="sheetIndex">sheet�����������0��ʼ</param>
		/// <returns>���ݼ�</returns>
		public static DataTable ExcelToDataTable(string strFileName, int sheetIndex = 0)
		{
			DataTable dt = new DataTable();
			HSSFWorkbook hssfworkbook = null;
			XSSFWorkbook xssfworkbook = null;
			string fileExt = Path.GetExtension(strFileName);//��ȡ�ļ��ĺ�׺��
			using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
			{
				if (fileExt == ".xls")
					hssfworkbook = new HSSFWorkbook(file);
				else if (fileExt == ".xlsx")
					xssfworkbook = new XSSFWorkbook(file);//��ʼ��̫���ˣ���֪������ʲôbug
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

		#endregion

		#region DataGridViewToExcel(DataGridView myDgv, string strHeaderText, string strFileName) DataGridView������Excel�ļ�--C/S

		/// <summary>
		/// C/S Winform��DataGridView�������ݵ�Excel
		/// </summary>
		/// <param name="myDgv">DataGridView�ؼ�����</param>
		/// <param name="saveFileName">������ļ����ƣ�Ĭ��û�У����õ�ʱ����ü��ϣ���Ӣ�Ķ�֧��</param>
		/// <param name="isOpen">�������Ƿ���ļ��������ļ���</param>
		/// <param name="saveFilePath">Ĭ�ϱ����ڡ��ҵ��ĵ����У����Զ��屣����ļ���·��</param>
		/// <param name="strHeaderText">Excel�е�һ�еı������֣�Ĭ��û�У������Զ���</param>
		/// <param name="titleNames">Excel�����������飬Ĭ�ϰ�GridView������</param>
		public static void DataGridViewToExcel(DataGridView myDgv, string saveFileName = null, bool isOpen = false,
			string saveFilePath = null, string strHeaderText = null, string[] titleNames = null)
		{
			using (MemoryStream ms = DataGridViewToExcel(myDgv, strHeaderText, titleNames))
			{
				if (string.IsNullOrEmpty(saveFileName)) //�ļ���Ϊ��
				{
					saveFileName = DateTime.Now.Ticks.ToString();
				}
				if (string.IsNullOrEmpty(saveFilePath) || !System.IO.Directory.Exists(saveFilePath)) //����·��Ϊ�ջ��߲�����
				{
					saveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //Ĭ�����ĵ��ļ�����
				}
				string saveFullPath = saveFilePath + "\\" + saveFileName + ".xls";
				if (System.IO.File.Exists(saveFullPath)) //��֤�ļ��ظ���
				{
					saveFullPath = saveFilePath + "\\" + saveFileName +
								   DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(":", "-").Replace(" ", "-") +
								   ".xls";
				}
				using (FileStream fs = new FileStream(saveFullPath, FileMode.Create, FileAccess.Write))
				{
					byte[] data = ms.ToArray();
					fs.Write(data, 0, data.Length);
					fs.Flush();
				}
				if (isOpen)
				{
					Process.Start(saveFullPath); //���ļ�
					Process.Start(saveFilePath); //���ļ���
				}
			}
		}

		#endregion

		/********************************************************�ָ������·��������뵼�뵼��*********************************************************/

		#region DataGridViewToExcel(DataGridView myDgv, string strHeaderText) DataTable������Excel��MemoryStream

		/// <summary>
		/// DataTable������Excel��MemoryStream
		/// </summary>
		/// <param name="myDgv">DataGridView�ؼ�����</param>
		/// <param name="strHeaderText">��һ�б���ͷ</param>
		/// <param name="titleNames">����������</param>
		/// <returns>�ڴ���</returns>
		private static MemoryStream DataGridViewToExcel(DataGridView myDgv, string strHeaderText = null,
			string[] titleNames = null)
		{
			HSSFWorkbook workbook = new HSSFWorkbook();
			HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

			#region �һ��ļ� ������Ϣ

			{
				DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
				dsi.Company = "NPOI";
				workbook.DocumentSummaryInformation = dsi;

				SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
				si.Author = "�ļ�������Ϣ"; //���xls�ļ�������Ϣ
				si.ApplicationName = "����������Ϣ"; //���xls�ļ�����������Ϣ
				si.LastAuthor = "��󱣴�����Ϣ"; //���xls�ļ���󱣴�����Ϣ
				si.Comments = "������Ϣ"; //���xls�ļ�������Ϣ
				si.Title = "������Ϣ"; //���xls�ļ�������Ϣ
				si.Subject = "������Ϣ"; //����ļ�������Ϣ
				si.CreateDateTime = System.DateTime.Now;
				workbook.SummaryInformation = si;
			}

			#endregion

			HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
			HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
			dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

			//ȡ���п�
			int[] arrColWidth = new int[myDgv.Columns.Count];
			foreach (DataGridViewColumn item in myDgv.Columns)
			{
				arrColWidth[item.Index] = Encoding.GetEncoding(936).GetBytes(item.HeaderText).Length;
			}
			for (int i = 0; i < myDgv.Rows.Count; i++)
			{
				for (int j = 0; j < myDgv.Columns.Count; j++)
				{
					int intTemp = Encoding.GetEncoding(936).GetBytes(myDgv.Rows[i].Cells[j].ToString()).Length;
					if (intTemp > arrColWidth[j])
					{
						arrColWidth[j] = intTemp;
					}
				}
			}
			int rowIndex = 0;
			foreach (DataGridViewRow row in myDgv.Rows)
			{
				#region �½�������ͷ�������ͷ����ʽ

				if (rowIndex == 65535 || rowIndex == 0)
				{
					if (rowIndex != 0)
					{
						sheet = (HSSFSheet)workbook.CreateSheet();
					}

					#region ��ͷ����ʽ

					{
						if (!string.IsNullOrEmpty(strHeaderText))
						{
							HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
							headerRow.HeightInPoints = 25;
							headerRow.CreateCell(0).SetCellValue(strHeaderText);

							HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
							//  headStyle.Alignment = CellHorizontalAlignment.CENTER;
							HSSFFont font = (HSSFFont)workbook.CreateFont();
							font.FontHeightInPoints = 20;
							font.Boldweight = 700;
							font.FontName = "����";
							headStyle.SetFont(font);
							headerRow.GetCell(0).CellStyle = headStyle;
							// sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
							//headerRow.Dispose();
							rowIndex++;
						}
					}

					#endregion


					#region ��ͷ����ʽ
					{
						HSSFRow headerRow = (HSSFRow)sheet.CreateRow(rowIndex);
						HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
						// headStyle.Alignment = CellHorizontalAlignment.CENTER;
						HSSFFont font = (HSSFFont)workbook.CreateFont();
						font.FontHeightInPoints = 14;
						font.Boldweight = 500;
						font.FontName = "����";
						headStyle.SetFont(font);
						if (titleNames != null)
						{
							if (titleNames.Length > 0)
							{
								for (int i = 0; i < titleNames.Length; i++)
								{
									headerRow.CreateCell(i).SetCellValue(titleNames[i]);
									headerRow.GetCell(i).CellStyle = headStyle;
									//�����п�
									sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 100);
								}
							}
						}
						else
						{
							foreach (DataGridViewColumn column in myDgv.Columns)
							{
								headerRow.CreateCell(column.Index).SetCellValue(column.HeaderText);
								headerRow.GetCell(column.Index).CellStyle = headStyle;
								//�����п�
								sheet.SetColumnWidth(column.Index, (arrColWidth[column.Index] + 1) * 100);
							}
						}
						rowIndex++;
						// headerRow.Dispose();
					}

					#endregion
				}

				#endregion

				#region �������

				HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
				if (row.Index > 0)
				{
					foreach (DataGridViewColumn column in myDgv.Columns)
					{
						HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Index);

						string drValue = myDgv[column.Index, row.Index - 1].Value.ToString();
						switch (column.ValueType.ToString())
						{
							case "System.String": //�ַ�������
								newCell.SetCellValue(drValue);
								break;
							case "System.DateTime": //��������
								System.DateTime dateV;
								System.DateTime.TryParse(drValue, out dateV);
								newCell.SetCellValue(dateV);

								newCell.CellStyle = dateStyle; //��ʽ����ʾ
								break;
							case "System.Boolean": //������
								bool boolV = false;
								bool.TryParse(drValue, out boolV);
								newCell.SetCellValue(boolV);
								break;
							case "System.Int16": //����
							case "System.Int32":
							case "System.Int64":
							case "System.Byte":
								int intV = 0;
								int.TryParse(drValue, out intV);
								newCell.SetCellValue(intV);
								break;
							case "System.Decimal": //������
							case "System.Double":
								double doubV = 0;
								double.TryParse(drValue, out doubV);
								newCell.SetCellValue(doubV);
								break;
							case "System.DBNull": //��ֵ����
								newCell.SetCellValue("");
								break;
							default:
								newCell.SetCellValue("");
								break;
						}
					}
				}
				else
				{
					rowIndex--;
				}

				#endregion

				rowIndex++;
			}
			using (MemoryStream ms = new MemoryStream())
			{
				workbook.Write(ms);
				ms.Flush();
				ms.Position = 0;
				//    sheet.Dispose();
				//workbook.Dispose();//һ��ֻ��д��һ����OK�ˣ�����������ͷ�������Դ������ǰ�汾����������ֻ�ͷ�sheet
				return ms;
			}
		}

		#endregion

		#region GetExcelStream() �������е�������д�뵽��Ŀ¼

		/// <summary>
		/// д�뵽�ڴ�����
		/// </summary>
		/// <returns></returns>
		private static MemoryStream GetExcelStream()
		{
			//Write the stream data of workbook to the root directory--�������е�������д�뵽��Ŀ¼
			MemoryStream file = new MemoryStream();
			_hssfworkbook.Write(file);
			return file;
		}

		#endregion

		#region GenerateData(DataTable sourceDt, string[] titleNames, string strHeadName, string sheetName = "Sheet1") �������ݼ���ÿһ��Sheet��

		/// <summary>
		/// �������ݼ���ÿһ��Sheet��
		/// </summary>
		/// <param name="sourceDt">����Դ</param>
		/// <param name="titleNames">����</param>
		/// <param name="strHeadName">��һ����ʾ����</param>
		/// <param name="sheetName">��Ҫ�����ı�����ƣ�Ĭ����Sheet1</param>
		/// <param name="isOpen">�Ƿ���ļ�</param>
		private static void GenerateData(DataTable sourceDt, string[] titleNames, string strHeadName,
			string sheetName = "Sheet1")
		{
			ISheet sheet1 = _hssfworkbook.CreateSheet(sheetName);
			int rowIndex = 0;
			if (!string.IsNullOrEmpty(strHeadName)) //ͷ�������
			{
				sheet1.CreateRow(rowIndex).CreateCell(0).SetCellValue(strHeadName);
				rowIndex++;
			}
			IRow rowSecond = sheet1.CreateRow(rowIndex);
			if (titleNames != null) //�����Զ����б���
			{
				if (titleNames.Length > 0)
				{
					for (int k = 0; k < titleNames.Length; k++)
					{
						var cell = rowSecond.CreateCell(k);
						cell.SetCellValue(titleNames[k]);
						cell.CellStyle = Getcellstyle(_hssfworkbook, stylexls.ͷ);
					}
					rowIndex++;
				}
			}
			else //����DataTable���б���
			{
				if (sourceDt.Columns.Count > 0)
				{
					for (int i = 0; i < sourceDt.Columns.Count; i++)
					{
						var cell = rowSecond.CreateCell(i);
						cell.SetCellValue(sourceDt.Columns[i].ColumnName);
						cell.CellStyle = Getcellstyle(_hssfworkbook, stylexls.ͷ);
					}
					rowIndex++;
				}
			}

			if (sourceDt != null && sourceDt.Rows.Count > 0)
			{
				for (int i = 0; i < sourceDt.Rows.Count; i++)
				{
					IRow row = sheet1.CreateRow(rowIndex++);
					for (int j = 0; j < sourceDt.Columns.Count; j++)
					{
						row.CreateCell(j).SetCellValue(sourceDt.Rows[i][j].ToString());
					}
				}
			}
		}

		#endregion

		#region InitializeWorkbook() �����ļ���������ϸ��Ϣ

		/// <summary>
		/// �����ļ���������ϸ��Ϣ
		/// </summary>
		private static void InitializeWorkbook()
		{
			_hssfworkbook = new HSSFWorkbook();

			#region �һ��ļ� ������Ϣ

			{
				DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
				dsi.Company = "DZD";
				_hssfworkbook.DocumentSummaryInformation = dsi;

				SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
				si.Author = "�ļ�������Ϣ"; //���xls�ļ�������Ϣ
				si.ApplicationName = "����������Ϣ"; //���xls�ļ�����������Ϣ
				si.LastAuthor = "��󱣴�����Ϣ"; //���xls�ļ���󱣴�����Ϣ
				si.Comments = "������Ϣ"; //���xls�ļ�������Ϣ
				si.Title = "������Ϣ"; //���xls�ļ�������Ϣ
				si.Subject = "������Ϣ"; //����ļ�������Ϣ
				si.CreateDateTime = DateTime.Now;
				_hssfworkbook.SummaryInformation = si;
			}

			#endregion
		}

		#endregion

		#region ���嵥Ԫ���õ���ʽ

		private static ICellStyle Getcellstyle(IWorkbook wb, stylexls str)
		{
			ICellStyle cellStyle = wb.CreateCellStyle();

			//���弸������  
			//Ҳ����һ�����壬дһЩ�������ԣ�Ȼ����������Ҫʱ�������  
			IFont font12 = wb.CreateFont();
			font12.FontHeightInPoints = 14;
			font12.FontName = "����";


			IFont font = wb.CreateFont();
			font.FontName = "����";
			//font.Underline = 1;�»���  


			IFont fontcolorblue = wb.CreateFont();
			fontcolorblue.Color = HSSFColor.OLIVE_GREEN.BLUE.index;
			fontcolorblue.IsItalic = true; //�»���  
			fontcolorblue.FontName = "����";


			//�߿�  
			cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.DOTTED;
			cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.HAIR;
			cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.HAIR;
			cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.DOTTED;
			//�߿���ɫ  
			cellStyle.BottomBorderColor = HSSFColor.OLIVE_GREEN.BLUE.index;
			cellStyle.TopBorderColor = HSSFColor.OLIVE_GREEN.BLUE.index;

			//����ͼ�Σ���û���õ������о��ܳ�  
			//   cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.GREEN.index;
			//cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
			// cellStyle.FillForegroundColor = HSSFColor.WHITE.index;
			// cellStyle.FillPattern = FillPatternType.NO_FILL;  
			cellStyle.FillBackgroundColor = HSSFColor.MAROON.index;

			//ˮƽ����  
			cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;

			//��ֱ����  
			cellStyle.VerticalAlignment = VerticalAlignment.CENTER;

			//�Զ�����  
			// cellStyle.WrapText = true;

			//����;������Ϊ1ʱ��ǰ�����Ŀհ�̫���ˡ�ϣ�������Ľ��������������õĲ���  
			cellStyle.Indention = 0;

			//������������蹲��������  
			//�����г��˳��õ��ֶ�����  
			switch (str)
			{
				case stylexls.ͷ:
					// cellStyle.FillPattern = FillPatternType.LEAST_DOTS;  
					cellStyle.SetFont(font12);
					break;
				case stylexls.ʱ��:
					IDataFormat datastyle = wb.CreateDataFormat();

					cellStyle.DataFormat = datastyle.GetFormat("yyyy/mm/dd");
					cellStyle.SetFont(font);
					break;
				case stylexls.����:
					cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
					cellStyle.SetFont(font);
					break;
				case stylexls.Ǯ:
					IDataFormat format = wb.CreateDataFormat();
					cellStyle.DataFormat = format.GetFormat("��#,##0");
					cellStyle.SetFont(font);
					break;
				case stylexls.url:
					fontcolorblue.Underline = 1;
					cellStyle.SetFont(fontcolorblue);
					break;
				case stylexls.�ٷֱ�:
					cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
					cellStyle.SetFont(font);
					break;
				case stylexls.���Ĵ�д:
					IDataFormat format1 = wb.CreateDataFormat();
					cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
					cellStyle.SetFont(font);
					break;
				case stylexls.��ѧ������:
					cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
					cellStyle.SetFont(font);
					break;
				case stylexls.Ĭ��:
					cellStyle.SetFont(font);
					break;
			}
			return cellStyle;
		}

		#endregion

		#region ���嵥Ԫ���õ���ʽ��ö��

		public enum stylexls
		{
			ͷ,
			url,
			ʱ��,
			����,
			Ǯ,
			�ٷֱ�,
			���Ĵ�д,
			��ѧ������,
			Ĭ��
		}

		#endregion
	}
}
