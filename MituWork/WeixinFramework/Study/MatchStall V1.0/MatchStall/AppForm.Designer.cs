namespace MatchStall
{
    partial class AppForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.dgvInfo = new System.Windows.Forms.DataGridView();
			this.btnChooseExcelFile = new System.Windows.Forms.Button();
			this.btnExportToExcel = new System.Windows.Forms.Button();
			this.btnOpenSaveDirectory = new System.Windows.Forms.Button();
			this.btn_OpenFilePath = new System.Windows.Forms.Button();
			this.txt_SavePath = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.lblFileName = new System.Windows.Forms.Label();
			this.lblExcelFileName = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvInfo
			// 
			this.dgvInfo.AllowUserToAddRows = false;
			this.dgvInfo.AllowUserToDeleteRows = false;
			this.dgvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInfo.Location = new System.Drawing.Point(12, 54);
			this.dgvInfo.Name = "dgvInfo";
			this.dgvInfo.ReadOnly = true;
			this.dgvInfo.RowTemplate.Height = 23;
			this.dgvInfo.Size = new System.Drawing.Size(1249, 431);
			this.dgvInfo.TabIndex = 0;
			// 
			// btnChooseExcelFile
			// 
			this.btnChooseExcelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChooseExcelFile.Location = new System.Drawing.Point(1162, 16);
			this.btnChooseExcelFile.Name = "btnChooseExcelFile";
			this.btnChooseExcelFile.Size = new System.Drawing.Size(99, 23);
			this.btnChooseExcelFile.TabIndex = 1;
			this.btnChooseExcelFile.Text = "选择Excel文件";
			this.btnChooseExcelFile.UseVisualStyleBackColor = true;
			this.btnChooseExcelFile.Click += new System.EventHandler(this.btnChooseExcelFile_Click);
			// 
			// btnExportToExcel
			// 
			this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExportToExcel.Location = new System.Drawing.Point(1001, 16);
			this.btnExportToExcel.Name = "btnExportToExcel";
			this.btnExportToExcel.Size = new System.Drawing.Size(141, 23);
			this.btnExportToExcel.TabIndex = 2;
			this.btnExportToExcel.Text = "导出数据到Excel";
			this.btnExportToExcel.UseVisualStyleBackColor = true;
			this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
			// 
			// btnOpenSaveDirectory
			// 
			this.btnOpenSaveDirectory.Location = new System.Drawing.Point(409, 17);
			this.btnOpenSaveDirectory.Name = "btnOpenSaveDirectory";
			this.btnOpenSaveDirectory.Size = new System.Drawing.Size(91, 23);
			this.btnOpenSaveDirectory.TabIndex = 8;
			this.btnOpenSaveDirectory.Text = "打开保存文件夹";
			this.btnOpenSaveDirectory.UseVisualStyleBackColor = true;
			this.btnOpenSaveDirectory.Click += new System.EventHandler(this.btnOpenSaveDirectory_Click);
			// 
			// btn_OpenFilePath
			// 
			this.btn_OpenFilePath.Location = new System.Drawing.Point(343, 17);
			this.btn_OpenFilePath.Name = "btn_OpenFilePath";
			this.btn_OpenFilePath.Size = new System.Drawing.Size(59, 23);
			this.btn_OpenFilePath.TabIndex = 7;
			this.btn_OpenFilePath.Text = "浏览...";
			this.btn_OpenFilePath.UseVisualStyleBackColor = true;
			this.btn_OpenFilePath.Click += new System.EventHandler(this.btn_OpenFilePath_Click);
			// 
			// txt_SavePath
			// 
			this.txt_SavePath.Location = new System.Drawing.Point(72, 18);
			this.txt_SavePath.Name = "txt_SavePath";
			this.txt_SavePath.ReadOnly = true;
			this.txt_SavePath.Size = new System.Drawing.Size(264, 21);
			this.txt_SavePath.TabIndex = 6;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(10, 22);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(65, 12);
			this.label13.TabIndex = 5;
			this.label13.Text = "输出目录：";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(899, 21);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(96, 16);
			this.checkBox1.TabIndex = 9;
			this.checkBox1.Text = "导出自动打开";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// txtFileName
			// 
			this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFileName.Location = new System.Drawing.Point(717, 17);
			this.txtFileName.MaxLength = 20;
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(163, 21);
			this.txtFileName.TabIndex = 10;
			// 
			// lblFileName
			// 
			this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFileName.AutoSize = true;
			this.lblFileName.Location = new System.Drawing.Point(634, 22);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(77, 12);
			this.lblFileName.TabIndex = 11;
			this.lblFileName.Text = "保存文件名：";
			// 
			// lblExcelFileName
			// 
			this.lblExcelFileName.AutoSize = true;
			this.lblExcelFileName.ForeColor = System.Drawing.Color.Red;
			this.lblExcelFileName.Location = new System.Drawing.Point(503, 22);
			this.lblExcelFileName.Name = "lblExcelFileName";
			this.lblExcelFileName.Size = new System.Drawing.Size(0, 12);
			this.lblExcelFileName.TabIndex = 12;
			// 
			// AppForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1273, 497);
			this.Controls.Add(this.lblExcelFileName);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.btnOpenSaveDirectory);
			this.Controls.Add(this.btn_OpenFilePath);
			this.Controls.Add(this.txt_SavePath);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.btnExportToExcel);
			this.Controls.Add(this.btnChooseExcelFile);
			this.Controls.Add(this.dgvInfo);
			this.Name = "AppForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Excel操作";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Button btnChooseExcelFile;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnOpenSaveDirectory;
        private System.Windows.Forms.Button btn_OpenFilePath;
        private System.Windows.Forms.TextBox txt_SavePath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.Label lblExcelFileName;
    }
}

