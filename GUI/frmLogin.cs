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
using DTO;

namespace GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        UserBLL u_bll = new UserBLL();

        private void btNhap_Click(object sender, EventArgs e)
        {
            int kq = u_bll.Check_Users(txtTenDN.Text, txtPass.Text);
            if(kq==-1)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu !");
                return;
            }
            else
            {
                MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (kq == 1)
                {
                    frmMain frm_main = new frmMain();
                    this.Hide();
                    frm_main.Show();
                }
                else if (kq == 0)
                {
                    frmSinhVien frm_SV = new frmSinhVien();
                    this.Hide();
                    frm_SV.Show();
                }
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            txtTenDN.ResetText();
            txtPass.ResetText();
            txtTenDN.Focus();
        }
    }
}
