using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KeSachBLL
    {
        KeSachAccess ks_acc = new KeSachAccess();
        public List<KeSach> Get_ALL_KeSach()
        {
            return ks_acc.Get_ALL_KeSach();
        }
        public KeSach Get_KeSach(byte kieu, string maKeSach, string tenKeSach)
        {
            return ks_acc.Get_KeSach(kieu, maKeSach, tenKeSach);
        }
    }
}
