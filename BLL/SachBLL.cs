using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SachBLL
    {
        SachAccess sach_acc = new SachAccess();
        public bool CRUD_Sach(char kieu,int maSach, string maDauSach, int dangMuon)
        {
            return sach_acc.CRUD_Sach(kieu,  maSach, maDauSach, dangMuon);
        }
        public int Get_SoLuong_Sach(string maDauSach)
        {
            return sach_acc.Get_SoLuong_Sach(maDauSach);
        }
        public bool SachDangDuocMuon(int maSach)
        {
            return sach_acc.SachDangDuocMuon(maSach);
        }
    }
}
