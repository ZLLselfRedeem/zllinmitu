//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2014 , DZD , Ltd .
//-------------------------------------------------------------------------------------

using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System;

namespace MatchStall
{
	/// <summary>
	/// 主窗体
	///
	/// 修改纪录
	///
	///		2014-01-12 版本：1.0 yanghenglian 创建主键，注意命名空间的排序。
	///		
	/// 版本：1.0
	///
	/// <author>
	///		<name>yanghenglian</name>
	///		<date>2014-01-12</date>
	/// </author>
	/// </summary>
	public partial class AppForm : Form
	{
		private static readonly string SaveFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);//默认在文档文件夹中
		public AppForm()
		{
			InitializeComponent();
			this.txt_SavePath.Text = SaveFilePath;
			this.txtFileName.Text = DateTime.Now.ToString("yyyy-MM-dd") + @"统计打票";
		}

		/// <summary>
		/// 选择Excel文件导入DataGridView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnChooseExcelFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog() { Filter = @"Excel文件|*.xls;*.xlsx" })//;*.xlsx
			{
				if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						System.Data.DataTable chooseDt = ExcelHelper.ExcelToDataTable(ofd.FileName);//选中文件DataTable
						this.lblExcelFileName.Text = ofd.FileName;
						////dgvInfo.DataSource = chooseDt;//绑定完选中Excel中的数据
						//string sourceFilePath = System.Windows.Forms.Application.StartupPath + "\\" +
						//						ConfigurationManager.AppSettings["ExcelFilePath"];
						//System.Data.DataTable stallDt = ExcelHelper.ExcelToDataTable(sourceFilePath); //源摊位Excel文件转换成DataTable
						//foreach (DataRow chooseDataRow in chooseDt.Rows) //选中的Excel文件DataTable
						//{
						//	foreach (DataRow dataRow in stallDt.Rows) //源文件当中的Excel转换后的DataTable
						//	{
						//		string chooseColumnValue = dataRow[0].ToString(); //第一列的值
						//		if (chooseColumnValue.Substring(0, 1).Equals("0")) //这里的DataRow[0]头第一个字符如果包含0需要去除0
						//			chooseColumnValue = chooseColumnValue.Substring(1, chooseColumnValue.Length - 1);
						//		if (chooseColumnValue != chooseDataRow[0].ToString()) continue;
						//		chooseDataRow[1] = chooseDataRow[1] + "（" + dataRow[1] + "）";
						//		break;
						//	}
						//}
						dgvInfo.DataSource = chooseDt;
					}
					catch (Exception ex)
					{
						XiaoHan.LogWriter.WriteToDefaultDirectory(ex);
						MessageBox.Show(@"导入失败！");
					}
				}
			}
		}

		private void btnExportToExcel_Click(object sender, EventArgs e)
		{
			try
			{
				if (dgvInfo.Rows.Count == 0)
				{
					MessageBox.Show(@"请先选择Excel文件导入");
					return;
				}
				ExcelHelper.DataGridViewToExcel(dgvInfo, this.txtFileName.Text.Trim(), this.checkBox1.Checked, this.txt_SavePath.Text);
			}
			catch (Exception ex)
			{
				XiaoHan.LogWriter.WriteToDefaultDirectory(ex);
				MessageBox.Show(@"导出失败");
			}
		}
		/// <summary>
		/// 选择保存文件路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_OpenFilePath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = SaveFilePath;//设置此次默认目录为默认文件夹路径
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				string path = fbd.SelectedPath;
				txt_SavePath.Text = path;
			}
		}
		/// <summary>
		/// 打开保存文件路径
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenSaveDirectory_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_SavePath.Text))
				if (Directory.Exists(txt_SavePath.Text))
					Process.Start(txt_SavePath.Text);
				else
					MessageBox.Show(@"无效路径！");
			else
				MessageBox.Show(@"请选择保存位置！");
		}
	}
}

