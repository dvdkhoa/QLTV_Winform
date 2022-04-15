using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }
        //Khởi tạo BLL
        LoaiSachBLL ls_bll = new LoaiSachBLL();
        DauSachBLL dauSach_bll = new DauSachBLL();
        TacGiaBLL tg_bll = new TacGiaBLL();
        NXBBLL nxb_bll = new NXBBLL();
        SachBLL sachBLL = new SachBLL();    

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            HienThiDS_Sach();
            HienThicb();
        }
        void HienThiDS_Sach()
        {
            //Hiển thị danh sách sách
            lvSach_SV.Items.Clear();
            try
            {
                List<DauSach> ds_dauSach = dauSach_bll.LayToanBoDauSach();
                foreach (DauSach dauSach in ds_dauSach)
                {
                    ListViewItem lv = new ListViewItem(dauSach.MaDauSach);
                    lv.SubItems.Add(dauSach.TenDauSach);
                    lv.SubItems.Add(ls_bll.GetLoaiSach(1, dauSach.MaLS, "").TenLoaiSach);
                    lv.SubItems.Add(sachBLL.Get_SoLuong_Sach(dauSach.MaDauSach).ToString());
                    TacGia tg = tg_bll.GetTacGia(1, dauSach.MaTG, "");
                    lv.SubItems.Add(tg.TenTG);

                    NXB nxb = nxb_bll.GetNXB(1, dauSach.MaNXB, "");
                    lv.SubItems.Add(nxb.TenNXB);
                    lv.SubItems.Add(string.IsNullOrEmpty(dauSach.NamXB.ToString()) ? "1" : dauSach.NamXB.ToString());
                    lv.SubItems.Add(dauSach.MaNganh);
                    lv.Tag = dauSach;

                    lvSach_SV.Items.Add(lv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HienThicb()
        {
            cbLoaiSach_SV.Items.Clear();
            List<LoaiSach> dsls = ls_bll.LayToanBoLoaiSach();
            foreach (LoaiSach ls in dsls)
            {
                cbLoaiSach_SV.Items.Add(ls);
            }

            //Tac gia
            cbTacGia_SV.Items.Clear();
            List<TacGia> dstg = tg_bll.LayToanBoTacGia();
            foreach (TacGia tg in dstg)
            {
                cbTacGia_SV.Items.Add(tg);
            }

            //NXB
            cbNXB_SV.Items.Clear();
            List<NXB> dsNXB = nxb_bll.LayToanBoNXB();
            foreach (NXB nxb in dsNXB)
            {
                cbNXB_SV.Items.Add(nxb);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = string.IsNullOrEmpty(txtNamXB_SV.Text) ? -1 : int.Parse(txtNamXB_SV.Text);
            List<DauSach> ds_dauSach = dauSach_bll.TimDauSach_ten_GanDung(txtTenSach_SV.Text, cbLoaiSach_SV.Text, "", cbTacGia_SV.Text, cbNXB_SV.Text, a, txtNganh_SV.Text, txtKhoa_SV.Text, txtTags_SV.Text);
            lvSach_SV.Items.Clear();
            foreach (DauSach dauSach in ds_dauSach)
            {
                ListViewItem lv = new ListViewItem(dauSach.MaDauSach);
                lv.SubItems.Add(dauSach.TenDauSach);
                lv.SubItems.Add(ls_bll.GetLoaiSach(1, dauSach.MaLS, "").TenLoaiSach);
                lv.SubItems.Add(sachBLL.Get_SoLuong_Sach(dauSach.MaDauSach).ToString());
                TacGia tg = tg_bll.GetTacGia(1, dauSach.MaTG, "");
                lv.SubItems.Add(tg.TenTG);

                NXB nxb = nxb_bll.GetNXB(1, dauSach.MaNXB, "");
                lv.SubItems.Add(nxb.TenNXB);
                lv.SubItems.Add(dauSach.NamXB.ToString());

                lv.SubItems.Add(dauSach.MaNganh);
                lv.Tag = dauSach;

                lvSach_SV.Items.Add(lv);
            }
        }

        private void frmSinhVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
