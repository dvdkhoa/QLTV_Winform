using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SinhVienBLL
    {
        SinhVienAccess sva = new SinhVienAccess();

        public List<SinhVien> LayToanBoSinhVien()
        {
            return sva.LayToanBoSinhVien();
        }

        public bool CRUD_SinhVien(char kieu,string maSV,string tenSV,DateTime ngaySinh,
            string gioiTinh,string phone,string lop, string maNganh,string maKhoa)
        {
           return sva.CRUD_SinhVien(kieu, maSV, tenSV, ngaySinh, gioiTinh,
               phone, lop, maNganh, maKhoa); ;
        }
        public SinhVien GetSinhVien(string maSV)
        {
            return sva.GetSinhVien(maSV);
        }
        public bool Insert_excel(string _path)
        {
            return sva.Insert_excel(_path);
        }
    }
}
