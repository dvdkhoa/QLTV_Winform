using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BoMonBLL
    {
        BoMonAccess bm_acc = new BoMonAccess();
        public List<BoMon> GetALLBoMon()
        {
            return bm_acc.GetALLBoMon();
        }
    }
}
