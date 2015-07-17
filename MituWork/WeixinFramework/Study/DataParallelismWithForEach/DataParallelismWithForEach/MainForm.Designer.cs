using System.Windows.Forms;

namespace DataParallelismWithForEach
{
    partial class MainForm
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
            this.label1 = new Label();
            this.txtInputArea = new TextBox();
            this.btnProcessImages = new Button();
            this.SuspendLayout();
            this.btnCancelTask = new Button();
            //
            // btnCancleTask
            //
            this.btnCancelTask.Location = new System.Drawing.Point(16, 191);
            this.btnCancelTask.Name = "btnProcessImages";
            this.btnCancelTask.Size = new System.Drawing.Size(120, 20);
            this.btnCancelTask.Text = "Cancel";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // label
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 
                9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Feel free to type here while the images are processed...";
            //
            // txtInputArea
            //
            this.txtInputArea.Location = new System.Drawing.Point(16, 44);
            this.txtInputArea.Multiline = true;
            this.txtInputArea.Name = "txtInputArea";
            this.txtInputArea.Size = new System.Drawing.Size(389, 130);
            this.txtInputArea.TabIndex = 1;
            //
            // btnProcessImages
            //
            this.btnProcessImages.Location = new System.Drawing.Point(199, 191);
            this.btnProcessImages.Name = "btnProcessImages";
            this.btnProcessImages.Size = new System.Drawing.Size(206, 20);
            this.btnProcessImages.TabIndex = 2;
            this.btnProcessImages.Text = "Click to Flip";
            this.btnProcessImages.UseVisualStyleBackColor = true;
            this.btnProcessImages.Click += new System.EventHandler(this.btnProcessImages_Click);
            //
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 223);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputArea);
            this.Controls.Add(this.btnProcessImages);
            this.Controls.Add(this.btnCancelTask);
            this.Name = "MainForm";
            this.Text = "Fun with the TPL";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Button btnCancelTask;
        private Label label1;
        private TextBox txtInputArea;
        private Button btnProcessImages;
        //private Button btnCancelTask;
    }
}

