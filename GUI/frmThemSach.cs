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
    public partial class frmThemSach : Form
    {
        public frmThemSach()
        {
            InitializeComponent();
        }
        private DauSach dauSach_intent;
        private char kieu;
        public frmThemSach(DauSach dauSach, char kieu)
        {
            InitializeComponent();
            this.dauSach_intent = dauSach;
            this.kieu = kieu;
            if (kieu == 's')
            {
                lbTieuDe.Text = "Sửa thông tin sách";
                btExcel.Visible = false;
            }    
        }

        //-------------Khởi tạo các BLL--------------
        LoaiSachBLL ls_bll = new LoaiSachBLL();
        ChuDeBLL cd_bll = new ChuDeBLL();
        DauSachBLL dauSach_bll = new DauSachBLL();
        TacGiaBLL tg_bll = new TacGiaBLL();
        NXBBLL nxb_bll = new NXBBLL();
        SinhVienBLL sv_bll = new SinhVienBLL();
        NganhBLL nganh_bll = new NganhBLL();
        KhoaBLL khoa_bll = new KhoaBLL();
        KeSachBLL keSach_bll = new KeSachBLL();
        HocPhanBLL hocPhan_bll = new HocPhanBLL();
        //-------------------------------------------

        private void HienThiCB()
        {
            //Loại sách
            cbLoaiSach_ThemSach.Items.Clear();
            cbLoaiSach_ThemSach.Items.AddRange(ls_bll.LayToanBoLoaiSach().ToArray());

            //Chủ đề
            cbChuDe_ThemSach.Items.Clear();
            cbChuDe_ThemSach.Items.AddRange(cd_bll.GetAll_ChuDe().ToArray());

            //Tác giả
            cbTacGia_ThemSach.Items.Clear();
            cbTacGia_ThemSach.Items.AddRange(tg_bll.LayToanBoTacGia().ToArray());

            //NXB
            cbNXB_ThemSach.Items.Clear();
            cbNXB_ThemSach.Items.AddRange(nxb_bll.LayToanBoNXB().ToArray());

            //Nganh
            cbNganh_ThemSach.Items.Clear();
            cbNganh_ThemSach.Items.AddRange(nganh_bll.LayToanBoNganh().ToArray());

            //Kệ sách
            cbKeSach_ThemSach.Items.Clear();
            cbKeSach_ThemSach.Items.AddRange(keSach_bll.Get_ALL_KeSach().ToArray());

            //Học phần
            cbHocPhan.Items.Clear();
            cbHocPhan.Items.AddRange(hocPhan_bll.Get_ALL_HocPhan().ToArray());
        }

        private void frmThemSach_Load(object sender, EventArgs e)
        {
            rdRutGon.Checked = true;
            HienThiCB(); // Hiển thị tất cả các combobox

            if(this.dauSach_intent!=null) //Nếu có truyền vào đầu sách thì các Textbox hiển thị thông tin chi tiết
            {
                rdMoRong.Checked = true;
                txtMaDauSach_ThemSach.Text= this.dauSach_intent.MaDauSach;
                txtTenDauSach_ThemSach.Text = this.dauSach_intent.TenDauSach;
                cbLoaiSach_ThemSach.Text = ls_bll.GetLoaiSach(1,this.dauSach_intent.MaLS,"").ToString();
                cbChuDe_ThemSach.Text = cd_bll.GetChuDe(1,this.dauSach_intent.MaChuDe,"").ToString();
                txtSoLuong_ThemSach.Text = this.dauSach_intent.SL.ToString();
                cbTacGia_ThemSach.Text = tg_bll.GetTacGia(1,this.dauSach_intent.MaTG,"").ToString();
                cbNXB_ThemSach.Text = nxb_bll.GetNXB(1,this.dauSach_intent.MaNXB,"").ToString();
                txtNamXB_ThemSach.Text = this.dauSach_intent.NamXB.ToString();
                cbNganh_ThemSach.Text = nganh_bll.GetNganh(1,this.dauSach_intent.MaNganh,"").ToString();
                txtSoTrang_ThemSach.Text = this.dauSach_intent.SoTrang.ToString();
                txtKho_ThemSach.Text = this.dauSach_intent.KhoCo;
                txtMinhHoa_ThemSach.Text = this.dauSach_intent.MinhHoa;
                txtGiaBia_ThemSach.Text = this.dauSach_intent.GiaBia.ToString();
                txtNguon_ThemSach.Text = this.dauSach_intent.Nguon;
                cbHocPhan.Text = hocPhan_bll.Get_HocPhan(1, string.IsNullOrEmpty(this.dauSach_intent.MaHocPhan)? "": this.dauSach_intent.MaHocPhan, "").TenHocPhan;
                txtTags_ThemSach.Text = this.dauSach_intent.Tags;
                cbKeSach_ThemSach.Text = keSach_bll.Get_KeSach(1, string.IsNullOrEmpty(this.dauSach_intent.MaKeSach)?"": this.dauSach_intent.MaKeSach, "").TenKeSach;
                txtTenKhac_ThemSach.Text= this.dauSach_intent.TenKhac;
                txtTungThu_ThemSach.Text = this.dauSach_intent.TungThu;
                txtISBN_ThemSach.Text = this.dauSach_intent.ISBN;
                txtSoTap_ThemSach.Text = this.dauSach_intent.SoTap.ToString();
                txtTenTap_ThemSach.Text = this.dauSach_intent.TenKhac;
                txtDinhKem_ThemSach.Text = this.dauSach_intent.DinhKem;
                txtNgonNgu_ThemSach.Text = this.dauSach_intent.NgonNgu;
            }    
        }

        private void rdMoRong_CheckedChanged(object sender, EventArgs e)
        {
            grMoRong.Visible = true;
            this.Width = 1050;

            btLuu_ThemSach.Location = new Point(908, 13);
            btExcel.Location = new Point(778, 13);
        }
        private void rdRutGon_CheckedChanged(object sender, EventArgs e)
        {
            grMoRong.Visible = false;
            this.Width = 750;
            btLuu_ThemSach.Location = new Point(591, 20);
            btExcel.Location = new Point(451, 20);
        }

        private void btLuu_ThemSach_Click(object sender, EventArgs e)
        {
            //try
            //{
                DauSach dauSach= new DauSach(); // Khởi tạo object đầu sách và gán thông tin cho nó
                dauSach.MaDauSach = txtMaDauSach_ThemSach.Text;
                dauSach.TenDauSach = txtTenDauSach_ThemSach.Text;
                dauSach.MaLS = ls_bll.GetLoaiSach(2, "", cbLoaiSach_ThemSach.Text).MaLoaiSach;
                dauSach.MaChuDe = cd_bll.GetChuDe(2, "", cbChuDe_ThemSach.Text).MaChuDe;
                dauSach.SL = Convert.ToInt32(txtSoLuong_ThemSach.Text);
                dauSach.MaTG = tg_bll.GetTacGia(2, "", cbTacGia_ThemSach.Text).MaTG;
                dauSach.MaNXB = nxb_bll.GetNXB(2, "", cbNXB_ThemSach.Text).MaNXB;
                dauSach.NamXB = Convert.ToInt32(txtNamXB_ThemSach.Text);
                dauSach.MaNganh = nganh_bll.GetNganh(2, "", cbNganh_ThemSach.Text).MaNganh;
                dauSach.SoTrang = !string.IsNullOrEmpty(txtSoTrang_ThemSach.Text)?int.Parse(txtSoTrang_ThemSach.Text):0;
                dauSach.KhoCo = txtKho_ThemSach.Text;
                dauSach.MinhHoa = txtMinhHoa_ThemSach.Text;
                dauSach.GiaBia = !string.IsNullOrEmpty(txtGiaBia_ThemSach.Text)? long.Parse(txtGiaBia_ThemSach.Text):0;
                dauSach.Nguon = txtNguon_ThemSach.Text;
                dauSach.MaHocPhan = hocPhan_bll.Get_HocPhan(2, "", cbHocPhan.Text).MaHocPhan; 
                dauSach.Tags = txtTags_ThemSach.Text;
                dauSach.MaKeSach = keSach_bll.Get_KeSach(2, "", cbKeSach_ThemSach.Text).MaKeSach; 

                
                if(rdMoRong.Checked) // Nếu checkBox mở rộng được tích thì ta set thêm các thông tin mở rộng cho đầu sách
                {
                    dauSach.TenKhac = txtTenKhac_ThemSach.Text;
                    dauSach.TungThu = txtTungThu_ThemSach.Text;
                    dauSach.ISBN = txtISBN_ThemSach.Text;
                    dauSach.SoTap = int.Parse(txtSoTap_ThemSach.Text);
                    dauSach.TenTap = txtTenTap_ThemSach.Text;
                    dauSach.DinhKem = txtDinhKem_ThemSach.Text;
                    dauSach.NgonNgu = txtNgonNgu_ThemSach.Text;
                }
                else // Còn không thì gán tất cả các thông tin mở rộng đều là chuỗi rỗng !!!
                {
                    dauSach.TenKhac = "";
                    dauSach.TungThu = "";
                    dauSach.ISBN = "";
                    dauSach.SoTap = 0;
                    dauSach.TenTap = "";
                    dauSach.DinhKem = "";
                    dauSach.NgonNgu = "";
                }    
               

                if (this.kieu == 's') // Thực hiện Action sửa thông tin đầu sách
                {
                    bool ret = dauSach_bll.CRUD_DauSach('s', dauSach.MaDauSach, dauSach.TenDauSach, dauSach.MaLS,
                    dauSach.MaChuDe, dauSach.MaTG, dauSach.MaNXB, dauSach.NamXB, dauSach.MaNganh, dauSach.MaHocPhan, dauSach.MaKeSach,
                    dauSach.SoTrang, dauSach.KhoCo, dauSach.Tags, dauSach.MinhHoa,
                    dauSach.GiaBia, dauSach.Nguon, dauSach.TenKhac,
                    dauSach.TungThu, dauSach.ISBN, dauSach.SoTap, dauSach.TenTap, dauSach.DinhKem,
                    dauSach.NgonNgu, dauSach.SL);
                    if (ret)
                    {
                        MessageBox.Show("Sửa thành công !");
                    }
                }
                else if(this.kieu =='t') // Thực hiện Action thêm đầu sách 
                {
                    bool ret = dauSach_bll.CRUD_DauSach('t', dauSach.MaDauSach, dauSach.TenDauSach, dauSach.MaLS,
                    dauSach.MaChuDe, dauSach.MaTG, dauSach.MaNXB, dauSach.NamXB, dauSach.MaNganh, dauSach.MaHocPhan, dauSach.MaKeSach,
                    dauSach.SoTrang, dauSach.KhoCo, dauSach.Tags, dauSach.MinhHoa,
                    dauSach.GiaBia, dauSach.Nguon, dauSach.TenKhac,
                    dauSach.TungThu, dauSach.ISBN, dauSach.SoTap, dauSach.TenTap, dauSach.DinhKem,
                    dauSach.NgonNgu, dauSach.SL);
                    if (ret)
                    {
                        MessageBox.Show("Thêm thành công !");
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            frmExcel frm = new frmExcel(); //Khởi tạo form thêm nhiều sách bằng file Excel
            frm.Show();            
        }
    }
}
