using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhoaBLL
    {
        KhoaAccess khoa_acc = new KhoaAccess();
        public List<Khoa> GetAllKhoa()
        {
            return khoa_acc.GetALLKhoa();
        }
        public Khoa GetKhoa(int kieu, string maKhoa, string tenKhoa)
        {
            return khoa_acc.GetKhoa(kieu, maKhoa, tenKhoa);
        }
    }
}
