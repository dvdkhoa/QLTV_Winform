using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ChuDeBLL
    {
        ChuDeAccess cd_acc = new ChuDeAccess();
        public List<ChuDe> GetAll_ChuDe()
        {
            return cd_acc.GetAll_ChuDe();
        }
        public ChuDe GetChuDe(int kieu, string maCD, string tenCD)
        {
            return cd_acc.GetChuDe(kieu, maCD, tenCD);
        }
    }
}
