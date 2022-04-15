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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        //-------------Khởi tạo các BLL--------------
        LoaiSachBLL ls_bll = new LoaiSachBLL();
        ChuDeBLL cd_bll = new ChuDeBLL();
        DauSachBLL dauSach_bll = new DauSachBLL();
        SachBLL sach_bll = new SachBLL();
        TacGiaBLL tg_bll = new TacGiaBLL();
        NXBBLL nxb_bll = new NXBBLL();
        SinhVienBLL sv_bll = new SinhVienBLL();
        NganhBLL nganh_bll = new NganhBLL();
        KhoaBLL khoa_bll = new KhoaBLL();
        PhieuMuonBLL pm_bll = new PhieuMuonBLL();
        ChiTietMuonBLL ct_bll = new ChiTietMuonBLL();
        //----------------------------------------

        void HienThiDS_Sach()
        {
            //Hiển thị danh sách sách
            lvSach.Items.Clear();
            try
            {
                List<DauSach> dssach = dauSach_bll.LayToanBoDauSach();
                foreach (DauSach dauSach in dssach)
                {
                    ListViewItem lv = new ListViewItem(dauSach.MaDauSach);
                    lv.SubItems.Add(dauSach.TenDauSach);
                    lv.SubItems.Add(ls_bll.GetLoaiSach(1, dauSach.MaLS, "").TenLoaiSach);
                    lv.SubItems.Add(dauSach.MaChuDe);
                    lv.SubItems.Add(sach_bll.Get_SoLuong_Sach(dauSach.MaDauSach).ToString());
                    TacGia tg = tg_bll.GetTacGia(1, dauSach.MaTG, "");
                    lv.SubItems.Add(tg.TenTG);

                    NXB nxb = nxb_bll.GetNXB(1, dauSach.MaNXB, "");
                    lv.SubItems.Add(nxb.TenNXB);
                    lv.SubItems.Add(string.IsNullOrEmpty(dauSach.NamXB.ToString()) ? "1" : dauSach.NamXB.ToString());
                    lv.SubItems.Add(dauSach.MaNganh);

                    lv.Tag = dauSach;

                    lvSach.Items.Add(lv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            void HienThiDS_LoaiSach()
        {
            //Hiển thị danh sách loại sách
            lvLoaiSach.Items.Clear();
            List<LoaiSach> dsLS = new List<LoaiSach>();
            dsLS = ls_bll.LayToanBoLoaiSach();
            foreach (LoaiSach ls in dsLS)
            {
                ListViewItem lv = new ListViewItem(ls.MaLoaiSach);
                lv.SubItems.Add(ls.TenLoaiSach);
                lv.Tag = ls;

                lvLoaiSach.Items.Add(lv);
            }
        }
        
        private void HienThi_CB_ChiTietMuon()
        {
            cbSach_1.Items.Clear();
            cbSach_2.Items.Clear();
            cbSach_3.Items.Clear();
            cbSach_4.Items.Clear();
            cbSach_5.Items.Clear();

            List<DauSach> dsSach = dauSach_bll.LayToanBoDauSach();
            foreach(DauSach dauSach in dsSach)
            {
                cbSach_1.Items.Add(dauSach);
                cbSach_2.Items.Add(dauSach);
                cbSach_3.Items.Add(dauSach);
                cbSach_4.Items.Add(dauSach);
                cbSach_5.Items.Add(dauSach);
            }    
        }
        void HienThiDS_TacGia()
        {
            lvTG.Items.Clear();
            List<TacGia> dstg = tg_bll.LayToanBoTacGia();
            foreach (TacGia tg in dstg)
            {
                ListViewItem lv = new ListViewItem(tg.MaTG);
                lv.SubItems.Add(tg.TenTG);
                lv.SubItems.Add(tg.DiaChi);
                lv.SubItems.Add(tg.phone);
                lv.Tag = tg;

                lvTG.Items.Add(lv);
            }
        }
        void HienThiDS_NXB()
        {
            lvNXB.Items.Clear();
            List<NXB> ds_nxb = nxb_bll.LayToanBoNXB();
            foreach (NXB nxb in ds_nxb)
            {
                ListViewItem lv = new ListViewItem(nxb.MaNXB);
                lv.SubItems.Add(nxb.TenNXB);
                lv.SubItems.Add(nxb.DiaChi);
                lv.SubItems.Add(nxb.Phone);
                lv.Tag = nxb;

                lvNXB.Items.Add(lv);
            }
        }
       
        private void HienThiALL_DS_PM() 
        {
            
            btTraSach.Enabled = false;
            List<PhieuMuon> dsPM = pm_bll.LayToanBoPhieuMuon();

            HienThiDS_PM(dsPM);
        }
        private void HienThiDS_PM(List<PhieuMuon> dsPM)
        {
            lvPhieu_Muon.Items.Clear();

            foreach (PhieuMuon pm in dsPM)
            {
                List<ChiTietMuon> dsCTM = ct_bll.GetChiTietMuon(pm.MaPM);//dùng mã Phiếu mượn để tìm thông tin chi tiết mượn

                ListViewItem lv = new ListViewItem(pm.MaPM.ToString());
                lv.SubItems.Add(pm.MaSV);
                lv.SubItems.Add(pm.NgayMuon.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(pm.NgayTra == DateTime.Parse("1/1/0001") ? "" : pm.NgayTra.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(pm.NgayTra == DateTime.Parse("1/1/0001") ? "Đang mượn" : "Đã trả sách");
                lv.Tag = pm;

                foreach (ChiTietMuon ctm in dsCTM)
                {
                    lv.SubItems.Add(ctm.MaSach.ToString());
                }
                
                lvPhieu_Muon.Items.Add(lv);
            }
        }

        void HienThiDS_SV()
        {
            lvSinhVien.Items.Clear();
            List<SinhVien> dsSV = sv_bll.LayToanBoSinhVien();

            foreach (SinhVien sv in dsSV)
            {
                ListViewItem lv = new ListViewItem(sv.MaSV);
                lv.SubItems.Add(sv.TenSV);
                lv.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(sv.GioiTinh);
                lv.SubItems.Add(sv.Phone);
                lv.SubItems.Add(sv.Lop);
                lv.SubItems.Add(sv.Nganh);
                lv.SubItems.Add(sv.Khoa);
                lv.Tag = sv;

                lvSinhVien.Items.Add(lv);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDS_Sach();
            HienThiCB();
            dateTimeNgaySinh_SV.Value = DateTime.Now;
            dtTu.Value = dtDen.Value = DateTime.Now;

        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSach.SelectedItems.Count == 0)
            {
                return;
            }
            DauSach dauSach = lvSach.SelectedItems[0].Tag as DauSach;
            txtMaSach.Text = dauSach.MaDauSach;
            txtTenSach.Text = dauSach.TenDauSach;
            cbLoaiSach.Text = ls_bll.GetLoaiSach(1, dauSach.MaLS, "").ToString();

            txtSoLuong.Text = dauSach.SL.ToString();
            cbTacGia.Text = tg_bll.GetTacGia(1, dauSach.MaTG, "").ToString();
            cbNganh.Text = dauSach.MaNganh;
            cbNXB.Text = dauSach.MaNXB;
            cbNXB.Text = nxb_bll.GetNXB(1, dauSach.MaNXB, "").ToString();
            txtTags.Text = dauSach.Tags;
        }

        private void lvLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLoaiSach.SelectedItems.Count == 0)
                return;
            LoaiSach ls = lvLoaiSach.SelectedItems[0].Tag as LoaiSach;
            txtMaLoaiSach.Text = ls.MaLoaiSach;
            txtTenLoaiSach.Text = ls.TenLoaiSach;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            txtMaSach.ResetText();
            txtTenSach.ResetText();
            cbLoaiSach.ResetText();
            txtSoLuong.ResetText();
            cbTacGia.ResetText();
            cbNXB.ResetText();
            cbLoaiSach.ResetText();
            cbNganh.ResetText();
            
            cbNXB.ResetText();
            txtTags.ResetText();
            cbLoaiSach.SelectedItem = null;
            cbTacGia.SelectedItem = null;
            cbNXB.SelectedItem = null;
            txtMaSach.Focus();
        }

        private void txtNganh_TextChanged(object sender, EventArgs e)
        {

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
           
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DauSach dauSach = lvSach.SelectedItems[0].Tag as DauSach;

                bool ret = dauSach_bll.CRUD_DauSach('x',dauSach.MaDauSach, "", "", "", "", "", 
                    0, "", "", "", 0, "", "", "", 0, "", "", "", "", 0, "", "", "", 0);
                if (ret)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDS_Sach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btXoaLoaiSach_Click(object sender, EventArgs e)
        {
            try
            {
                if(lvLoaiSach.SelectedItems.Count==0)
                {
                    MessageBox.Show("Bạn chưa chọn loại sách");
                    return;
                }    
                LoaiSach ls = lvLoaiSach.SelectedItems[0].Tag as LoaiSach;
                bool ret = ls_bll.CRUD_LoaiSach('x', ls.MaLoaiSach, ls.TenLoaiSach);
                if (ret)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDS_LoaiSach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btThem_LS_Click(object sender, EventArgs e)
        {
            txtMaLoaiSach.ResetText();
            txtTenLoaiSach.ResetText();
            txtMaLoaiSach.Focus();
        }

        private void btLuu_LS_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSach ls = new LoaiSach();
                ls.MaLoaiSach = txtMaLoaiSach.Text;
                ls.TenLoaiSach = txtTenLoaiSach.Text;

                bool ret = ls_bll.CRUD_LoaiSach('t', ls.MaLoaiSach, ls.TenLoaiSach);
                if (ret)
                {
                    MessageBox.Show("Thêm thành công !");
                    HienThiDS_LoaiSach();
                    btThem_LS.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btXoaTG_Click(object sender, EventArgs e)
        {
            try
            {
                if(lvTG.SelectedItems.Count==0)
                {
                    MessageBox.Show("Bạn chưa chọn tác giả cần xóa !");
                    return;
                }    
                TacGia tg = lvTG.SelectedItems[0].Tag as TacGia;

                bool ret = tg_bll.CRUD_TacGia('x', tg.MaTG, "", "", "");
                if (ret)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDS_TacGia();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "547")
                    MessageBox.Show("Bạn cần xóa hết tác phẩm của tác giả này trước khi xóa tác giả !!!");
                else
                    MessageBox.Show(ex.Message);
            }
        }

        private void btLuu_TG_Click(object sender, EventArgs e)
        {
            try
            {
                TacGia tg = new TacGia();
                tg.MaTG = txtMaTG.Text;
                tg.TenTG = txtTenTG.Text;
                tg.DiaChi = txtDiaChi_TG.Text;
                tg.phone = txtPhone_TG.Text;

                bool ret = tg_bll.CRUD_TacGia('t', tg.MaTG, tg.TenTG, tg.DiaChi, tg.phone);

                if (ret)
                {
                    MessageBox.Show("Thêm thành công !");
                    HienThiDS_TacGia();
                    btThem_TG.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTG.SelectedItems.Count == 0)
                return;
            TacGia tg = lvTG.SelectedItems[0].Tag as TacGia;
            txtMaTG.Text = tg.MaTG;
            txtTenTG.Text = tg.TenTG;
            txtDiaChi_TG.Text = tg.DiaChi;
            txtPhone_TG.Text = tg.phone;
        }

        
        
        private void tabct1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(tabct1.SelectedTab==tabSach)
            {
                HienThiCB();
            }    
           if(tabct1.SelectedTab==tabLoaiSach)
            {
                HienThiDS_LoaiSach();
            }    
           if(tabct1.SelectedTab==tabTacGia)
            {
                HienThiDS_TacGia();
            }    
           if(tabct1.SelectedTab==tabNXB)
            {
                HienThiDS_NXB();
            }    
           if(tabct1.SelectedTab==tabSinhVien)
            {
                var dsNganh = nganh_bll.LayToanBoNganh();

                //Load Combobox Ngành
                cbNganh_SV.Items.Clear();
                cbNganh_SV.Items.AddRange(dsNganh.ToArray());

                // Load Combobox Khoa
                cbKhoa_SV.Items.Clear();
                cbKhoa_SV.Items.AddRange(khoa_bll.GetAllKhoa().ToArray());
                HienThiDS_SV();
            }
            if (tabct1.SelectedTab==tabMuonSach)
           { 
                HienThi_CB_ChiTietMuon();
                HienThiALL_DS_PM();
                btTraSach.Enabled = false;
                btLuu_PM.Enabled = false;
                lbTu.Enabled = false;
                lbDen.Enabled = false;
                datetime_NgayMuon.Value = DateTime.Now;
            }    
        }

        private void btSua_LS_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSach ls = new LoaiSach();
                ls.MaLoaiSach = txtMaLoaiSach.Text;
                ls.TenLoaiSach = txtTenLoaiSach.Text;

                bool ret = ls_bll.CRUD_LoaiSach('s', ls.MaLoaiSach, ls.TenLoaiSach);
                if (ret)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDS_LoaiSach();
                    btThem_LS.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btLuu_NXB_Click(object sender, EventArgs e)
        {
            NXB nxb = new NXB();
            nxb.MaNXB = txtMa_NXB.Text;
            nxb.TenNXB = txtTen_NXB.Text;
            nxb.DiaChi = txtDiaChi_NXB.Text;
            nxb.Phone = txtPhone_NXB.Text;

            try
            {
                bool ret = nxb_bll.CRUD_NXB('t', nxb.MaNXB, nxb.TenNXB, nxb.DiaChi, nxb.Phone);
                if (ret)
                {
                    MessageBox.Show("Thêm thành công !");
                    HienThiDS_NXB();
                    btThem_NXB.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btThem_NXB_Click(object sender, EventArgs e)
        {
            txtMa_NXB.ResetText();
            txtTen_NXB.ResetText();
            txtDiaChi_NXB.ResetText();
            txtPhone_NXB.ResetText();
            txtMa_NXB.Focus();
        }

        private void btSua_NXB_Click(object sender, EventArgs e)
        {
            NXB nxb = new NXB();
            nxb.MaNXB = txtMa_NXB.Text;
            nxb.TenNXB = txtTen_NXB.Text;
            nxb.DiaChi = txtDiaChi_NXB.Text;
            nxb.Phone = txtPhone_NXB.Text;

            try
            {
                bool ret = nxb_bll.CRUD_NXB('s', nxb.MaNXB, nxb.TenNXB, nxb.DiaChi, nxb.Phone);
                if (ret)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDS_NXB();
                    btThem_NXB.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_NXB_Click(object sender, EventArgs e)
        {
            if (lvNXB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn NXB cần xóa !");
                return;
            }    
            NXB nxb = lvNXB.SelectedItems[0].Tag as NXB;

            try
            {
                bool ret = nxb_bll.CRUD_NXB('x', nxb.MaNXB, "", "", "");
                if (ret)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDS_NXB();
                    btThem_NXB.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvNXB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvNXB.SelectedItems.Count == 0)
                return;
            NXB nxb = lvNXB.SelectedItems[0].Tag as NXB;
            txtMa_NXB.Text = nxb.MaNXB;
            txtTen_NXB.Text = nxb.TenNXB;
            txtDiaChi_NXB.Text = nxb.DiaChi;
            txtPhone_NXB.Text = nxb.Phone;
        }

        private void HienThiCB()
        {
            //Loại sách
            cbLoaiSach.Items.Clear();
            cbLoaiSach.Items.AddRange(ls_bll.LayToanBoLoaiSach().ToArray());

            //Chủ đề
            cbChuDe.Items.Clear();
            cbChuDe.Items.AddRange(cd_bll.GetAll_ChuDe().ToArray());

            //Tác giả
            cbTacGia.Items.Clear();
            cbTacGia.Items.AddRange(tg_bll.LayToanBoTacGia().ToArray());

            //NXB
            cbNXB.Items.Clear();
            cbNXB.Items.AddRange(nxb_bll.LayToanBoNXB().ToArray());

            //Nganh
            cbNganh.Items.Clear();
            cbNganh.Items.AddRange(nganh_bll.LayToanBoNganh().ToArray());

            
        }

        private void lvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSach.SelectedItems.Count == 0)
                return;
            txtMaSach.Enabled = false;
            DauSach dauSach = lvSach.SelectedItems[0].Tag as DauSach;
            txtMaSach.Text = dauSach.MaDauSach;
            txtTenSach.Text = dauSach.TenDauSach;
            cbLoaiSach.Text = ls_bll.GetLoaiSach(1, dauSach.MaLS, "").ToString();
            cbChuDe.Text = cd_bll.GetChuDe(1, dauSach.MaChuDe, "").TenChuDe;
            txtSoLuong.Text = dauSach.SL.ToString();
            cbTacGia.Text = tg_bll.GetTacGia(1, dauSach.MaTG, "").ToString();
            cbNXB.Text = nxb_bll.GetNXB(1, dauSach.MaNXB,"").ToString();
            txtNamXB.Text = dauSach.NamXB.ToString();
            cbNganh.Text = nganh_bll.GetNganh(1, dauSach.MaNganh, "").TenNganh;
            txtTags.Text = dauSach.Tags;
        }

      

        private void btThem_Sach_Click(object sender, EventArgs e)
        {
            frmThemSach frm = new frmThemSach(null,'t');
            frm.Show();
        }

        private void btSua_Sach_Click(object sender, EventArgs e)
        {
            if(lvSach.SelectedItems.Count==0)
            {
                MessageBox.Show("Chưa chọn Sách cần sửa !");
                return;
            }
            DauSach dauSach = lvSach.SelectedItems[0].Tag as DauSach;
            frmThemSach frm = new frmThemSach(dauSach,'s'); // Mở form frmThemSach với Action s( Nghĩa là sửa thông tin sách)
            frm.Show();
        }

        private void btXoa_Sach_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSach.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn sách !");
                    return;
                }
                bool ret=false;
                foreach(ListViewItem lv in lvSach.SelectedItems)
                {
                    DauSach dauSach = lv.Tag as DauSach;
                    // Thực hiện Action xóa đầu sách, chỉ quan tâm mã đầu sách, còn các thông tin còn lại không quan trọng 
                    ret = dauSach_bll.CRUD_DauSach('x', dauSach.MaDauSach, "", "", "", "", "", 0, "", "",
                    "", 0, "", "", "", 0, "", "", "", "", 0, "", "", "", 0);
                }

                if (ret)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDS_Sach();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btTim_Sach_Click(object sender, EventArgs e)
        {
            //try
            //{
                int a = string.IsNullOrEmpty(txtNamXB.Text) ? -1 : int.Parse(txtNamXB.Text);
                List<DauSach> ds_Sach = dauSach_bll.TimDauSach_ten_GanDung(txtTenSach.Text, cbLoaiSach.Text, cbChuDe.Text, cbTacGia.Text, cbNXB.Text, a, cbNganh.Text,"", txtTags.Text);
                lvSach.Items.Clear();
                foreach (DauSach dauSach in ds_Sach)
                {
                    ListViewItem lv = new ListViewItem(dauSach.MaDauSach);
                    lv.SubItems.Add(dauSach.TenDauSach);
                    lv.SubItems.Add(ls_bll.GetLoaiSach(1, dauSach.MaLS, "").TenLoaiSach);
                    lv.SubItems.Add(cd_bll.GetChuDe(1, dauSach.MaChuDe, "").TenChuDe);
                    lv.SubItems.Add(dauSach.SL.ToString());
                    TacGia tg = tg_bll.GetTacGia(1, dauSach.MaTG, "");
                    lv.SubItems.Add(tg.TenTG);

                    NXB nxb = nxb_bll.GetNXB(1, dauSach.MaNXB, "");
                    lv.SubItems.Add(nxb.TenNXB);
                    lv.SubItems.Add(dauSach.NamXB.ToString());

                    lv.SubItems.Add(dauSach.MaNganh);
                    lv.Tag = dauSach;

                    lvSach.Items.Add(lv);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            }
        }

        private void btThem_TG_Click(object sender, EventArgs e)
        {
            txtMaTG.ResetText();
            txtTenTG.ResetText();
            txtDiaChi_TG.ResetText();
            txtPhone_TG.ResetText();
            txtMaTG.Focus();
        }

        private void btSua_TG_Click(object sender, EventArgs e)
        {
            try
            {
                TacGia tg = new TacGia();
                tg.MaTG = txtMaTG.Text;
                tg.TenTG = txtTenTG.Text;
                tg.DiaChi = txtDiaChi_TG.Text;
                tg.phone = txtPhone_TG.Text;

                bool ret = tg_bll.CRUD_TacGia('s', tg.MaTG, tg.TenTG, tg.DiaChi, tg.phone);

                if (ret)
                {
                    MessageBox.Show("Sửa thông tin tác giả thành công !");
                    HienThiDS_TacGia();
                    btThem_TG.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count == 0)
                return;
            SinhVien sv = lvSinhVien.SelectedItems[0].Tag as SinhVien;

            txtMaSV.Text = sv.MaSV;
            txtTenSV.Text = sv.TenSV;
            dateTimeNgaySinh_SV.Text = sv.NgaySinh.ToString();
            if (sv.GioiTinh == "Nam")
                rdNam.Checked = true;
            else
                rdNu.Checked = true;
            txtPhone_SV.Text = sv.Phone;
            txtLop_SV.Text = sv.Lop;
            cbNganh_SV.Text = nganh_bll.GetNganh(1, sv.Nganh, "").TenNganh;
            cbKhoa_SV.Text = khoa_bll.GetKhoa(1, sv.Khoa, "").TenKhoa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaSV.ResetText();
            txtTenSV.ResetText();
            dateTimeNgaySinh_SV.ResetText();
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtPhone_SV.ResetText();
            txtLop_SV.ResetText();
            cbNganh_SV.ResetText();
            cbKhoa_SV.ResetText();
            txtMaSV.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btThem_SV_Click(object sender, EventArgs e)
        {
            txtMaSV.ResetText();
            txtTenSV.ResetText();
            dateTimeNgaySinh_SV.ResetText();
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtPhone_SV.ResetText();
            txtLop_SV.ResetText();
            cbNganh_SV.ResetText();
            cbKhoa_SV.ResetText();
            txtMaSV.Focus();
        }

        private void btLuu_SV_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.NgaySinh = dateTimeNgaySinh_SV.Value;
                sv.GioiTinh = rdNam.Checked == true ? "Nam" : "Nữ";
                sv.Phone = txtPhone_SV.Text;
                sv.Lop = txtLop_SV.Text;
                sv.Nganh = nganh_bll.GetNganh(2,"",cbNganh_SV.Text).MaNganh;
                sv.Khoa = khoa_bll.GetKhoa(2,"",cbKhoa_SV.Text).MaKhoa;

                bool ret = sv_bll.CRUD_SinhVien('t', sv.MaSV, sv.TenSV, sv.NgaySinh, sv.GioiTinh, sv.Phone,
                    sv.Lop, sv.Nganh, sv.Khoa);

                if (ret)
                {
                    MessageBox.Show("Thêm thành công !");
                    HienThiDS_SV();
                    btThem_SV.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btXoa_SV_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSinhVien.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn sinh viên !");
                    return;
                }
                SinhVien sv = lvSinhVien.SelectedItems[0].Tag as SinhVien;

                bool ret = sv_bll.CRUD_SinhVien('x', sv.MaSV, sv.TenSV, sv.NgaySinh, sv.GioiTinh, sv.Phone,
                    sv.Lop, sv.Nganh, sv.Khoa);

                if (ret)
                {
                    MessageBox.Show("Xóa thành công !");
                    HienThiDS_SV();
                    btThem_SV.PerformClick();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSua_SV_Click(object sender, EventArgs e)
        {
            //try
            //{
                SinhVien sv = lvSinhVien.SelectedItems[0].Tag as SinhVien;
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.NgaySinh = dateTimeNgaySinh_SV.Value;
                sv.GioiTinh = rdNam.Checked == true ? "Nam" : "Nữ";
                sv.Phone = txtPhone_SV.Text;
                sv.Lop = txtLop_SV.Text;
                sv.Nganh = nganh_bll.GetNganh(2, "", cbNganh_SV.Text).MaNganh;
                sv.Khoa = khoa_bll.GetKhoa(2, "", cbKhoa_SV.Text).MaKhoa;

                bool ret = sv_bll.CRUD_SinhVien('s', sv.MaSV, sv.TenSV, sv.NgaySinh, sv.GioiTinh, sv.Phone,
                    sv.Lop, sv.Nganh, sv.Khoa);

                if (ret)
                {
                    MessageBox.Show("Sửa thành công !");
                    HienThiDS_SV();
                    btThem_SV.PerformClick();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private bool Trung_Sach()
        {
            List<string> dsSach = new List<string>();
            if (!string.IsNullOrEmpty(cbSach_1.Text))
                dsSach.Add(cbSach_1.Text);
            if (!string.IsNullOrEmpty(cbSach_2.Text))
                dsSach.Add(cbSach_2.Text);
            if (!string.IsNullOrEmpty(cbSach_3.Text))
                dsSach.Add(cbSach_3.Text);
            if (!string.IsNullOrEmpty(cbSach_4.Text))
                dsSach.Add(cbSach_4.Text);
            if (!string.IsNullOrEmpty(cbSach_5.Text))
                dsSach.Add(cbSach_5.Text);

            for(int i=1;i<dsSach.Count;i++)
            {
                if (dsSach[0] == dsSach[i])
                    return true;
            }
            return false;
        }
        private bool EmptySach()
        {
            if (string.IsNullOrEmpty(cbSach_1.Text) &&
                string.IsNullOrEmpty(cbSach_2.Text) &&
                string.IsNullOrEmpty(cbSach_3.Text) &&
                string.IsNullOrEmpty(cbSach_4.Text) &&
                string.IsNullOrEmpty(cbSach_5.Text)
                )
                return true;
            return false;

        }
        private void btLuu_PM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSV_PM.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
                return;
            }
            SinhVien sv = sv_bll.GetSinhVien(txtMaSV_PM.Text);
            if (sv.MaSV == null)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên này !");
                return;
            }
            if (EmptySach())
            {
                MessageBox.Show("Sách mượn không thể để rỗng !");
                return;
            }
            if (Trung_Sach())
            {
                MessageBox.Show("Không được mượn cùng sách !");
                return;
            }
            try
            {
                PhieuMuon pm = new PhieuMuon();
                pm.MaSV = txtMaSV_PM.Text;
                pm.NgayMuon = datetime_NgayMuon.Value;

                List<ChiTietMuon> dsCTM = new List<ChiTietMuon>();

                if (!string.IsNullOrEmpty(cbSach_1.Text))
                {
                    ChiTietMuon ctm_1 = new ChiTietMuon();
                    ctm_1.MaSach = int.Parse(cbSach_1.Text);
                    dsCTM.Add(ctm_1);
                }

                if (!string.IsNullOrEmpty(cbSach_2.Text))
                {
                    ChiTietMuon ctm_2 = new ChiTietMuon();
                    ctm_2.MaSach = int.Parse(cbSach_2.Text);
                    dsCTM.Add(ctm_2);
                }

                if (!string.IsNullOrEmpty(cbSach_3.Text))
                {
                    ChiTietMuon ctm_3 = new ChiTietMuon();
                    ctm_3.MaSach = int.Parse(cbSach_3.Text);
                    dsCTM.Add(ctm_3);
                }

                if (!string.IsNullOrEmpty(cbSach_4.Text))
                {
                    ChiTietMuon ctm_4 = new ChiTietMuon();
                    ctm_4.MaSach = int.Parse(cbSach_4.Text);
                    dsCTM.Add(ctm_4);
                }

                if (!string.IsNullOrEmpty(cbSach_5.Text))
                {
                    ChiTietMuon ctm_5 = new ChiTietMuon();
                    ctm_5.MaSach = int.Parse(cbSach_5.Text);
                    dsCTM.Add(ctm_5);
                }

                bool exists;
                foreach(var ctm in dsCTM)
                {
                    exists = sach_bll.SachDangDuocMuon(ctm.MaSach);
                    if(exists)
                    {
                        MessageBox.Show($"Sách có mã \"{ctm.MaSach}\" đã có người mượn");
                        return;
                    }
                }

                var kq = pm_bll.MuonSach(pm, dsCTM);
                if (kq)
                {
                    MessageBox.Show("Thêm thông tin phiếu mượn thành công !");
                    btLuu_PM.Enabled = false;
                    HienThiALL_DS_PM();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            /////////////////////////////////////////////////////////////////
            //PhieuMuon pm = new PhieuMuon();
            //    pm.MaSV = txtMaSV_PM.Text;
            //    pm.NgayMuon = datetime_NgayMuon.Value;


            //    bool ret = pm_bll.CRUD_PhieuMuon('t', 0, pm.MaSV, pm.NgayMuon);

            //    if (ret)
            //    {
            //        int maPM = pm_bll.Get_MaPM_VuaThem(pm.MaSV);
            //        //Lấy mã phiếu mượn mới vừa add vào database ra để sử dụng

            //        List<ChiTietMuon> dsCTM = new List<ChiTietMuon>();

            //        if (!string.IsNullOrEmpty(cbSach_1.Text))
            //        {
            //            ChiTietMuon ctm_1 = new ChiTietMuon();
            //            ctm_1.MaPM = maPM;
            //            ctm_1.MaSach = int.Parse(cbSach_1.Text);
            //            dsCTM.Add(ctm_1);
            //        }

            //        if (!string.IsNullOrEmpty(cbSach_2.Text))
            //        {
            //            ChiTietMuon ctm_2 = new ChiTietMuon();
            //            ctm_2.MaPM = maPM;
            //            ctm_2.MaSach = int.Parse(cbSach_2.Text);
            //            dsCTM.Add(ctm_2);
            //        }

            //        if (!string.IsNullOrEmpty(cbSach_3.Text))
            //        {
            //            ChiTietMuon ctm_3 = new ChiTietMuon();
            //            ctm_3.MaPM = maPM;
            //            ctm_3.MaSach = int.Parse(cbSach_3.Text);
            //            dsCTM.Add(ctm_3);
            //        }

            //        if (!string.IsNullOrEmpty(cbSach_4.Text))
            //        {
            //            ChiTietMuon ctm_4 = new ChiTietMuon();
            //            ctm_4.MaPM = maPM;
            //            ctm_4.MaSach = int.Parse(cbSach_4.Text);
            //            dsCTM.Add(ctm_4);
            //        }

            //        if (!string.IsNullOrEmpty(cbSach_5.Text))
            //        {
            //            ChiTietMuon ctm_5 = new ChiTietMuon();
            //            ctm_5.MaPM = maPM;
            //            ctm_5.MaSach = int.Parse(cbSach_5.Text);
            //            dsCTM.Add(ctm_5);
            //        }

            //        foreach (ChiTietMuon ct in dsCTM)
            //        {
            //            bool kq = ct_bll.CRUD_ChiTietMuon('t', ct.MaPM, ct.MaSach);
            //            if (kq == false)
            //            {
            //                MessageBox.Show("Thêm chi tiết mượn thất bại");
            //                return;
            //            }

            //        }
            //        MessageBox.Show("Thêm thông tin phiếu mượn thành công !");
            //        btLuu_PM.Enabled = false;
            //        HienThiALL_DS_PM();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btXoa_PM_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvPhieu_Muon.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bạn chưa chọn phiếu mượn cần xóa !");
                    return;
                }    
                PhieuMuon pm = lvPhieu_Muon.SelectedItems[0].Tag as PhieuMuon;

                List<ChiTietMuon> dsCTM = ct_bll.GetChiTietMuon(pm.MaPM);
                foreach (ChiTietMuon ctm in dsCTM)
                {
                    bool kq = ct_bll.CRUD_ChiTietMuon('x', ctm.MaPM, ctm.MaSach);
                    if (kq == false)
                    {
                        MessageBox.Show("Xóa chi tiết mượn thất bại !");
                        return;
                    }
                }
                bool ret = pm_bll.CRUD_PhieuMuon('x', pm.MaPM, pm.MaSV, pm.NgayMuon);
                
                if (ret)
                {
                    MessageBox.Show("Xóa phiếu mượn thành công !");
                    HienThiALL_DS_PM();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSua_PM_Click(object sender, EventArgs e)
        {
            if (lvPhieu_Muon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần sửa thông tin !");
                return;
            }
            if(EmptySach())
            {
                MessageBox.Show("Sách mượn không thể để rỗng !");
                return;
            }    
            if(Trung_Sach())
            {
                MessageBox.Show("Không thể mượn trùng sách !");
                return;
            }    
            //try
            //{
                PhieuMuon pm = lvPhieu_Muon.SelectedItems[0].Tag as PhieuMuon;
                bool ret = pm_bll.CRUD_PhieuMuon('s', pm.MaPM, txtMaSV_PM.Text, datetime_NgayMuon.Value);
               
                List<ChiTietMuon> dsCTM = ct_bll.GetChiTietMuon(pm.MaPM);
                foreach(ChiTietMuon ct in dsCTM)
                {
                    bool kq = ct_bll.CRUD_ChiTietMuon('x', ct.MaPM, ct.MaSach);
                    if(kq==false)
                    {
                        MessageBox.Show("Sửa chi tiết mượn thất bại !");
                        return;
                    }    
                }
                dsCTM.Clear();
                
                if (ret)
                {
                    //List<ChiTietMuon> dsCTM = new List<ChiTietMuon>();

                    if (!string.IsNullOrEmpty(cbSach_1.Text))
                    {
                        ChiTietMuon ctm_1 = new ChiTietMuon();
                        ctm_1.MaPM = pm.MaPM;
                        ctm_1.MaSach = int.Parse(cbSach_1.Text);
                        dsCTM.Add(ctm_1);
                    }

                    if (!string.IsNullOrEmpty(cbSach_2.Text))
                    {
                        ChiTietMuon ctm_2 = new ChiTietMuon();
                        ctm_2.MaPM = pm.MaPM;
                        ctm_2.MaSach = int.Parse(cbSach_2.Text);
                        dsCTM.Add(ctm_2);
                    }

                    if (!string.IsNullOrEmpty(cbSach_3.Text))
                    {
                        ChiTietMuon ctm_3 = new ChiTietMuon();
                        ctm_3.MaPM = pm.MaPM;
                        ctm_3.MaSach = int.Parse(cbSach_3.Text);
                        dsCTM.Add(ctm_3);
                    }

                    if (!string.IsNullOrEmpty(cbSach_4.Text))
                    {
                        ChiTietMuon ctm_4 = new ChiTietMuon();
                        ctm_4.MaPM = pm.MaPM;
                        ctm_4.MaSach = int.Parse(cbSach_4.Text);
                        dsCTM.Add(ctm_4);
                    }

                    if (!string.IsNullOrEmpty(cbSach_5.Text))
                    {
                        ChiTietMuon ctm_5 = new ChiTietMuon();
                        ctm_5.MaPM = pm.MaPM;
                        ctm_5.MaSach = int.Parse(cbSach_5.Text);
                        dsCTM.Add(ctm_5);
                    }
                    foreach (ChiTietMuon ct in dsCTM)
                    {
                        bool kq = ct_bll.CRUD_ChiTietMuon('t', ct.MaPM, ct.MaSach);
                        if (kq == false)
                        {
                            MessageBox.Show("Sửa chi tiết mượn thất bại");
                            return;
                        }
                        //sach_bll.MuonSach(ct.MaSach);
                    }
                    MessageBox.Show("Sửa thông tin phiếu mượn thành công !");
                    HienThiALL_DS_PM();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void lvPhieu_Muon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhieu_Muon.SelectedItems.Count == 0)
            {
                btTraSach.Enabled = false;
                btSua_PM.Enabled = false;
                btXoa_PM.Enabled = false;
                btTraSach.Enabled = false;
                return;
            }
            txtMaSV_PM.Enabled = false;
            PhieuMuon pm = lvPhieu_Muon.SelectedItems[0].Tag as PhieuMuon;
            if(pm.NgayTra==DateTime.Parse("1/1/0001"))
            {
                btSua_PM.Enabled = true;
                btTraSach.Enabled = true;
            }
            btXoa_PM.Enabled = true;
            
            txtMaPhieu.Text = pm.MaPM.ToString();
            txtMaSV_PM.Text = pm.MaSV;

            List<ChiTietMuon> dsCTM = ct_bll.GetChiTietMuon(pm.MaPM);
            // lấy thông tin chi tiết phiếu mượn để hiển thị

            int[] arr = new int[5];// tạo 1 mảng để hứng tạm các mã sách trong ds ChiTietMuon

            if (dsCTM.Count != 0)
            {
                for (int i = 0; i < dsCTM.Count; i++)
                {
                    arr[i] = dsCTM[i].MaSach;
                }
            }
            cbSach_1.Text = arr[0] == 0 ? "" : arr[0].ToString();
            cbSach_2.Text = arr[1] == 0 ? "" : arr[1].ToString();
            cbSach_3.Text = arr[2] == 0 ? "" : arr[2].ToString();
            cbSach_4.Text = arr[3] == 0 ? "" : arr[3].ToString();
            cbSach_5.Text = arr[4] == 0 ? "" : arr[4].ToString();

            datetime_NgayMuon.Value = pm.NgayMuon;
        }

        private void btThem_PM_Click(object sender, EventArgs e)
        {
            txtMaSV_PM.Enabled=true;
            txtMaPhieu.ResetText();
            txtMaSV_PM.ResetText();
            cbSach_1.ResetText();
            cbSach_2.ResetText();
            cbSach_3.ResetText();
            cbSach_4.ResetText();
            cbSach_5.ResetText();
            datetime_NgayMuon.Value = DateTime.Now;
            btTraSach.Enabled = false;
        }

        private void btTraSach_Click(object sender, EventArgs e)
        {
            if(lvPhieu_Muon.SelectedItems.Count==0)
            {
                btTraSach.Enabled = false;
                return;
            }
            //try
            //{
                btTraSach.Enabled = true;
                PhieuMuon pm = lvPhieu_Muon.SelectedItems[0].Tag as PhieuMuon;

                bool ret=pm_bll.TraSach(pm.MaPM);
                if(ret)
                {
                    HienThiALL_DS_PM();
                    MessageBox.Show("Trả thành công !");
                }    
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btXemTTSV_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien sv = sv_bll.GetSinhVien(txtMaSV_PM.Text);
                if(sv.MaSV==null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sinh viên này !");
                    return;
                }    
                frmThongTin_SV frm = new frmThongTin_SV(sv);
                DialogResult result = frm.ShowDialog();
                if(result==DialogResult.OK)
                {
                    btLuu_PM.Enabled = true;
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void txtMaSV_PM_TextChanged(object sender, EventArgs e)
        {
            btLuu_PM.Enabled = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btTimPhieuMuon_Click(object sender, EventArgs e)
        {
            if(rdToanBo.Checked)
            {
                if (rdTatCa.Checked)
                {
                    HienThiALL_DS_PM();
                }
                else
                {
                    Select_Checked_time(100);
                }
            }
            else if(rdTheoMasv.Checked)
            {
                if (rdTatCa.Checked)
                {
                    List<PhieuMuon> dsPM = new List<PhieuMuon>();
                    dsPM=pm_bll.Get_DS_PM_1_SV_TheoMa(txtTheoMasv.Text, 1, 'a', null, null);
                    HienThiDS_PM(dsPM);
                }
                else
                    Select_Checked_time(1);
            }
        }
        private void Select_Checked_time(byte sl)
        {
            List<PhieuMuon> dsPM = new List<PhieuMuon>();
            if (rdNgay.Checked)
            {
                dsPM=pm_bll.Get_DS_PM_1_SV_TheoMa(txtTheoMasv.Text, sl,'d',null,null);
            }
            else if (rdTuan.Checked)
            {
                dsPM = pm_bll.Get_DS_PM_1_SV_TheoMa(txtTheoMasv.Text, sl, 'w', null, null);
            }
            else if (rdThang.Checked)
            {
                dsPM = pm_bll.Get_DS_PM_1_SV_TheoMa(txtTheoMasv.Text, sl, 'm', null, null);
            }
            else if (rdQuy.Checked)
            {
                dsPM = pm_bll.Get_DS_PM_1_SV_TheoMa(txtTheoMasv.Text, sl, 'q', null, null);
            }
            else
            {
                dsPM = pm_bll.Get_DS_PM_1_SV_TheoMa(txtTheoMasv.Text, sl, 'n', dtTu.Value.ToShortDateString(), dtDen.Value.ToShortDateString());
            }
            HienThiDS_PM(dsPM);
        }

        private void rdTuDen_CheckedChanged(object sender, EventArgs e)
        {
            if(rdTuDen.Checked)
            {
                dtTu.Enabled = true;
                dtDen.Enabled = true;
                lbTu.Enabled = true;
                lbDen.Enabled = true;
            }
            else
            {
                dtTu.Enabled = false;
                dtDen.Enabled = false;
                lbTu.Enabled = false;
                lbDen.Enabled = false;
            }
        }

        private void lvPhieu_Muon_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = lvPhieu_Muon.ListViewItemSorter as ItemComparer;
            try
            {
                if (sorter == null)
                {
                    sorter = new ItemComparer(e.Column);
                    sorter.Order = SortOrder.Ascending;
                    lvPhieu_Muon.ListViewItemSorter = sorter;
                }
                // if clicked column is already the column that is being sorted
                if (e.Column == sorter.Column)
                {
                    // Reverse the current sort direction
                    if (sorter.Order == SortOrder.Ascending)
                        sorter.Order = SortOrder.Descending;
                    else
                        sorter.Order = SortOrder.Ascending;
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    sorter.Column = e.Column;
                    sorter.Order = SortOrder.Ascending;
                }
                lvPhieu_Muon.Sort();
            }catch(Exception)
            {
                MessageBox.Show("Không thể sắp xếp theo cột này được !");
            }
        }

        private void lvSach_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemComparer sorter = lvSach.ListViewItemSorter as ItemComparer;

            if (sorter == null)
            {
                sorter = new ItemComparer(e.Column);
                sorter.Order = SortOrder.Ascending;
                lvSach.ListViewItemSorter = sorter;
            }
            // if clicked column is already the column that is being sorted
            if (e.Column == sorter.Column)
            {
                // Reverse the current sort direction
                if (sorter.Order == SortOrder.Ascending)
                    sorter.Order = SortOrder.Descending;
                else
                    sorter.Order = SortOrder.Ascending;
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                sorter.Column = e.Column;
                sorter.Order = SortOrder.Ascending;
            }
            lvSach.Sort();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txtMaSach.Enabled = true;
            txtMaSach.ResetText();
            txtTenSach.ResetText();

            cbLoaiSach.ResetText();
            cbLoaiSach.SelectedItem = null;

            cbChuDe.ResetText();
            cbChuDe.SelectedItem = null;

            txtSoLuong.ResetText();

            cbTacGia.ResetText();
            cbTacGia.SelectedItem = null;

            cbNXB.ResetText();
            cbNXB.SelectedItem = null;

            txtNamXB.ResetText();
            cbNXB.ResetText();
            cbNganh.ResetText();
            txtTags.ResetText();
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            HienThiDS_Sach();
            btReset_Click(sender, e);
        }
    }
}
    