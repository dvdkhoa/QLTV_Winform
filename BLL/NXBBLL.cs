using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NXBBLL
    {
        NXBaccess nxba = new NXBaccess();
        
        public List<NXB> LayToanBoNXB()
        {
            return nxba.LayToanBoNXB();
        }

        public bool CRUD_NXB(char kieu,string maNXB,string tenNXB,string diachi,string phone)
        {
            return nxba.CRUD_NXB(kieu, maNXB, tenNXB, diachi, phone);
        }
        public NXB GetNXB(int kieu,string maNXB,string tenNXB)
        {
            return nxba.GetNXB(kieu,maNXB,tenNXB);
        }
    }
}
