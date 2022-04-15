using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class LoaiSachBLL
    {
        LoaiSachAccess lsa = new LoaiSachAccess();

        public List<LoaiSach> LayToanBoLoaiSach()
        {
            return lsa.LayToanBoLoaiSach();
        }

        public LoaiSach GetLoaiSach(int kieu,string maLS,string tenLS)
        {
            return lsa.GetLoaiSach(kieu,maLS,tenLS);
        }

        public bool CRUD_LoaiSach(char kieu,string maLS,string tenLS)
        {
            return lsa.CRUD_LoaiSach(kieu, maLS, tenLS);
        }
    }
}
