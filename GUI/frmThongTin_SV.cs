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
    public partial class frmThongTin_SV : Form
    {

        PhieuMuonBLL pm_bll = new PhieuMuonBLL();
        NganhBLL nganh_bll = new NganhBLL();
        KhoaBLL khoa_bll = new KhoaBLL();
        public frmThongTin_SV(SinhVien sv)
        {
            InitializeComponent();

            HienThi_TT_SV(sv);

            int ret = pm_bll.Check_SV_MuonSach(sv.MaSV);
            if(ret>0)
            {
                this.lblTrangThai.Text = "Đang mượn sách.";
                btOK.Enabled = false;
            }    
            else
            {
                this.lblTrangThai.Text = "Có thể mượn sách.";
                btOK.Enabled = true;
            }    
        }
       
        private void HienThi_TT_SV(SinhVien sv)
        {
            this.lbMaSV.Text = sv.MaSV;
            this.lbTenSV.Text = sv.TenSV;
            this.lbNgaySinhSV.Text = sv.NgaySinh.ToString("dd/MM/yyyy");
            this.lbGioiTinh.Text = sv.GioiTinh;
            this.lbLop.Text = sv.Lop;
            this.lbKhoa.Text = khoa_bll.GetKhoa(1, sv.Khoa, "").TenKhoa;
            this.lblNganh.Text = nganh_bll.GetNganh(1, sv.Nganh, "").TenNganh;
        }

        private void frmThongTin_SV_Load(object sender, EventArgs e)
        {

        }
    }
}
