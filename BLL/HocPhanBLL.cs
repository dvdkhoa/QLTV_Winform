using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class HocPhanBLL
    {
        HocPhanAccess hp_acc = new HocPhanAccess();
        public HocPhan Get_HocPhan(byte kieu, string maHocPhan, string tenHocPhan)
        {
            return hp_acc.Get_HocPhan(kieu, maHocPhan, tenHocPhan);
        }
        public List<HocPhan> Get_ALL_HocPhan()
        {
            return hp_acc.Get_ALL_HocPhan();
        }
    }
}
