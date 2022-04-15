
namespace GUI
{
    partial class frmSinhVien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvSach_SV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNamXB_SV = new System.Windows.Forms.TextBox();
            this.cbNXB_SV = new System.Windows.Forms.ComboBox();
            this.cbTacGia_SV = new System.Windows.Forms.ComboBox();
            this.cbLoaiSach_SV = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTags_SV = new System.Windows.Forms.TextBox();
            this.txtNganh_SV = new System.Windows.Forms.TextBox();
            this.txtKhoa_SV = new System.Windows.Forms.TextBox();
            this.txtTenSach_SV = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 78);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1182, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tra cứu sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 833);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvSach_SV);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(379, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(803, 833);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // lvSach_SV
            // 
            this.lvSach_SV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader24,
            this.columnHeader17,
            this.columnHeader8});
            this.lvSach_SV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSach_SV.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSach_SV.FullRowSelect = true;
            this.lvSach_SV.GridLines = true;
            this.lvSach_SV.HideSelection = false;
            this.lvSach_SV.Location = new System.Drawing.Point(4, 20);
            this.lvSach_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lvSach_SV.Name = "lvSach_SV";
            this.lvSach_SV.Size = new System.Drawing.Size(795, 809);
            this.lvSach_SV.TabIndex = 3;
            this.lvSach_SV.UseCompatibleStateImageBehavior = false;
            this.lvSach_SV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã sách";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sách";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Loại sách";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số lượng";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tác giả";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "NXB";
            this.columnHeader24.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Năm XB";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ngành";
            this.columnHeader8.Width = 130;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 833);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtNamXB_SV);
            this.groupBox1.Controls.Add(this.cbNXB_SV);
            this.groupBox1.Controls.Add(this.cbTacGia_SV);
            this.groupBox1.Controls.Add(this.cbLoaiSach_SV);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtTags_SV);
            this.groupBox1.Controls.Add(this.txtNganh_SV);
            this.groupBox1.Controls.Add(this.txtKhoa_SV);
            this.groupBox1.Controls.Add(this.txtTenSach_SV);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(379, 833);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "************";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 441);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 48);
            this.button1.TabIndex = 60;
            this.button1.Text = "Tìm sách";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNamXB_SV
            // 
            this.txtNamXB_SV.Location = new System.Drawing.Point(115, 247);
            this.txtNamXB_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNamXB_SV.Name = "txtNamXB_SV";
            this.txtNamXB_SV.Size = new System.Drawing.Size(237, 23);
            this.txtNamXB_SV.TabIndex = 46;
            // 
            // cbNXB_SV
            // 
            this.cbNXB_SV.FormattingEnabled = true;
            this.cbNXB_SV.Location = new System.Drawing.Point(115, 197);
            this.cbNXB_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbNXB_SV.Name = "cbNXB_SV";
            this.cbNXB_SV.Size = new System.Drawing.Size(237, 23);
            this.cbNXB_SV.TabIndex = 45;
            // 
            // cbTacGia_SV
            // 
            this.cbTacGia_SV.FormattingEnabled = true;
            this.cbTacGia_SV.Location = new System.Drawing.Point(115, 145);
            this.cbTacGia_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbTacGia_SV.Name = "cbTacGia_SV";
            this.cbTacGia_SV.Size = new System.Drawing.Size(237, 23);
            this.cbTacGia_SV.TabIndex = 44;
            // 
            // cbLoaiSach_SV
            // 
            this.cbLoaiSach_SV.FormattingEnabled = true;
            this.cbLoaiSach_SV.Location = new System.Drawing.Point(115, 95);
            this.cbLoaiSach_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbLoaiSach_SV.Name = "cbLoaiSach_SV";
            this.cbLoaiSach_SV.Size = new System.Drawing.Size(237, 23);
            this.cbLoaiSach_SV.TabIndex = 42;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(42, 393);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 16);
            this.label24.TabIndex = 56;
            this.label24.Text = "Tags:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(30, 342);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 16);
            this.label21.TabIndex = 55;
            this.label21.Text = "Ngành:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(44, 293);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 16);
            this.label13.TabIndex = 54;
            this.label13.Text = "Khoa:";
            // 
            // txtTags_SV
            // 
            this.txtTags_SV.Location = new System.Drawing.Point(115, 387);
            this.txtTags_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTags_SV.Name = "txtTags_SV";
            this.txtTags_SV.Size = new System.Drawing.Size(237, 23);
            this.txtTags_SV.TabIndex = 49;
            // 
            // txtNganh_SV
            // 
            this.txtNganh_SV.Location = new System.Drawing.Point(115, 342);
            this.txtNganh_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNganh_SV.Name = "txtNganh_SV";
            this.txtNganh_SV.Size = new System.Drawing.Size(237, 23);
            this.txtNganh_SV.TabIndex = 48;
            // 
            // txtKhoa_SV
            // 
            this.txtKhoa_SV.Location = new System.Drawing.Point(115, 293);
            this.txtKhoa_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtKhoa_SV.Name = "txtKhoa_SV";
            this.txtKhoa_SV.Size = new System.Drawing.Size(237, 23);
            this.txtKhoa_SV.TabIndex = 47;
            // 
            // txtTenSach_SV
            // 
            this.txtTenSach_SV.Location = new System.Drawing.Point(115, 44);
            this.txtTenSach_SV.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTenSach_SV.Name = "txtTenSach_SV";
            this.txtTenSach_SV.Size = new System.Drawing.Size(237, 23);
            this.txtTenSach_SV.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 251);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 57;
            this.label8.Text = "Năm XB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "NXB:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(18, 149);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 16);
            this.label19.TabIndex = 59;
            this.label19.Text = "Tác Giả:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 99);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 52;
            this.label16.Text = "Loại sách:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 48);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 16);
            this.label17.TabIndex = 51;
            this.label17.Text = "Tên sách:";
            // 
            // frmSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 911);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSinhVien";
            this.Text = "Tra cứu sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSinhVien_FormClosing);
            this.Load += new System.EventHandler(this.frmSinhVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNamXB_SV;
        private System.Windows.Forms.ComboBox cbNXB_SV;
        private System.Windows.Forms.ComboBox cbTacGia_SV;
        private System.Windows.Forms.ComboBox cbLoaiSach_SV;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTags_SV;
        private System.Windows.Forms.TextBox txtNganh_SV;
        private System.Windows.Forms.TextBox txtKhoa_SV;
        private System.Windows.Forms.TextBox txtTenSach_SV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListView lvSach_SV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}