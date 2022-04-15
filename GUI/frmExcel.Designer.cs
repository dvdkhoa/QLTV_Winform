
namespace GUI
{
    partial class frmExcel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btChonDuongDan = new System.Windows.Forms.Button();
            this.txtDuongDan = new System.Windows.Forms.TextBox();
            this.btLuu_Excel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btChonDuongDan
            // 
            this.btChonDuongDan.Location = new System.Drawing.Point(333, 44);
            this.btChonDuongDan.Name = "btChonDuongDan";
            this.btChonDuongDan.Size = new System.Drawing.Size(90, 49);
            this.btChonDuongDan.TabIndex = 0;
            this.btChonDuongDan.Text = "Chọn đường dẫn";
            this.btChonDuongDan.UseVisualStyleBackColor = true;
            this.btChonDuongDan.Click += new System.EventHandler(this.btChonDuongDan_Click);
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(49, 58);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Size = new System.Drawing.Size(262, 22);
            this.txtDuongDan.TabIndex = 1;
            // 
            // btLuu_Excel
            // 
            this.btLuu_Excel.Location = new System.Drawing.Point(135, 98);
            this.btLuu_Excel.Name = "btLuu_Excel";
            this.btLuu_Excel.Size = new System.Drawing.Size(86, 36);
            this.btLuu_Excel.TabIndex = 0;
            this.btLuu_Excel.Text = "Lưu";
            this.btLuu_Excel.UseVisualStyleBackColor = true;
            this.btLuu_Excel.Click += new System.EventHandler(this.btLuu_Excel_Click);
            // 
            // frmExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 158);
            this.Controls.Add(this.txtDuongDan);
            this.Controls.Add(this.btLuu_Excel);
            this.Controls.Add(this.btChonDuongDan);
            this.Name = "frmExcel";
            this.Text = "frmExcel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btChonDuongDan;
        private System.Windows.Forms.TextBox txtDuongDan;
        private System.Windows.Forms.Button btLuu_Excel;
    }
}