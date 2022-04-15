using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NganhBLL
    {
        NganhAccess nganh_acc = new NganhAccess();
        public List<Nganh> LayToanBoNganh()
        {
            return nganh_acc.LayToanBoNganh();
        }
        public Nganh GetNganh(int kieu, string maNganh, string tenNganh)
        {
            return nganh_acc.GetNganh(kieu, maNganh, tenNganh);
        }
    }
}
