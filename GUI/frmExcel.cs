using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmExcel : Form
    {
        public frmExcel()
        {
            InitializeComponent();
        }
        DauSachBLL dauSach_bll = new DauSachBLL();
        SinhVienBLL sv_bll = new SinhVienBLL();
        private void btLuu_Excel_Click(object sender, EventArgs e)
        {
            bool a = dauSach_bll.Insert_excel_dauSach(txtDuongDan.Text);
            //bool a=sv_bll.Insert_excel(txtDuongDan.Text);
            if (a)
                MessageBox.Show("Thêm thành công !");
            else
                MessageBox.Show("Thêm thất bại !");
        }

        private void btChonDuongDan_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel|*.xls;*.xlsx;";
            DialogResult dr = of.ShowDialog();
            if (dr == DialogResult.Abort)
                return;
            if (dr == DialogResult.Cancel)
                return;
            txtDuongDan.Text = of.FileName.ToString();
        }
    }
}
