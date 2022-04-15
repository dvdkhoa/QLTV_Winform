using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DauSachBLL
    {
        //Khởi tạo các BLL để sử dụng cho xử lý logic
        DauSachAccess dauSach_acc = new DauSachAccess();
        TacGiaAccess tga = new TacGiaAccess();
        LoaiSachAccess lsa = new LoaiSachAccess();
        ChuDeAccess cda = new ChuDeAccess();
        NXBaccess nxba = new NXBaccess();
        NganhAccess nganh_acc = new NganhAccess();
        KhoaAccess khoa_acc = new KhoaAccess();

        SachBLL sach_bll = new SachBLL();

        public List<DauSach> LayToanBoDauSach()
        {
            return dauSach_acc.LayToanBoDauSach();
        }
        public bool CRUD_DauSach(char kieu, string maDauSach, string tenDauSach,
           string maLS, string maChuDe, string maTG, string maNXB, int namXB,
           string maNganh, string maHocPhan, string maKeSach, int soTrang,
           string khoCo, string tags, string minhHoa, long giaBia, string nguon,
           string tenKhac, string tungThu, string ISBN, int soTap, string tenTap,
           string dinhKem, string ngonNgu, int soLuong)
        {
            bool a= dauSach_acc.CRUD_DauSach( kieu, maDauSach, tenDauSach,maLS, maChuDe, maTG, maNXB, namXB,
                  maNganh, maHocPhan, maKeSach, soTrang, khoCo, tags, minhHoa, giaBia, nguon,
                   tenKhac, tungThu, ISBN, soTap, tenTap, dinhKem, ngonNgu);
            bool b = false;
            if (kieu =='t' && a)
            {
                for (int i = 0; i < soLuong; i++)
                {
                    b = sach_bll.CRUD_Sach('t', 0, maDauSach, 0);
                }
                return a && b;
            }
            return a;
        }

        public List<DauSach> TimDauSach(string tenDauSach, string maLS, string maTG, string maNXB,int namXB, string nganh, string khoa, string tags)
        {
            return dauSach_acc.TimDauSach(tenDauSach, maLS, maTG, maNXB,namXB, nganh, khoa, tags);
        }
        //public List<DauSach> TimDauSach(string tenDauSach, string tenNXB, string tenTG, string tenLS, string nganh, string khoa, string tags)
        //{

        //}
        public List<DauSach> TimDauSach_ten(string tenDauSach, string tenLS, string tenTG, string tenNXB,int namXB, string nganh, string khoa, string tags)
        {
            //Tìm tác giả theo tên => lấy được tác giả
            TacGia tg = tga.GetTacGia(2, "", tenTG);
            //Tìm NXB theo tên => lấy được NXB
            NXB nxb = nxba.GetNXB(2, "", tenNXB);
            //Tìm loại sách theo tên => lấy được loại sách
            LoaiSach ls = lsa.GetLoaiSach(2, "", tenLS);

            return dauSach_acc.TimDauSach(tenDauSach, ls.MaLoaiSach, tg.MaTG, nxb.MaNXB, namXB, nganh, khoa, tags);
        }
        public List<DauSach> TimDauSach_ten_GanDung(string tenDauSach, string tenLS, string tenChuDe, string tenTG, string tenNXB, int namXB, string tenNganh, string tenKhoa, string tags)
        {
            //Tìm tác giả theo tên => lấy được mã tác giả
            TacGia tg = tga.GetTacGia(2, "", tenTG);
            
            //Tìm NXB theo tên => lấy được mã NXB
            NXB nxb = nxba.GetNXB(2, "", tenNXB);
            
            //Tìm loại sách theo tên => lấy được mã loại sách
            LoaiSach ls = lsa.GetLoaiSach(2, "", tenLS);

            //Tìm chủ đề theo tên => lấy được mã chủ đề
            ChuDe cd = cda.GetChuDe(2, "", tenChuDe);

            //Tìm ngành theo tên => lấy được mã ngành
            Nganh nganh = nganh_acc.GetNganh(2, "", tenNganh);

            //Tìm khoa theo tên => lấy được mã khoa
            Khoa khoa = khoa_acc.GetKhoa(2, "", tenKhoa);


            return dauSach_acc.TimDauSach_ten_GanDung(tenDauSach, ls.MaLoaiSach, cd.MaChuDe, tg.MaTG, nxb.MaNXB, namXB, nganh.MaNganh, khoa.MaKhoa, tags);
        }
        public void MuonDauSach(string maDauSach)
        {
            dauSach_acc.MuonDauSach(maDauSach);
        }
        public bool Insert_excel_dauSach(string _path)
        {
            return dauSach_acc.Insert_excel_dauSach(_path);
        }
    }
}
