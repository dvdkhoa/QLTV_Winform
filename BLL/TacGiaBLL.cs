using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TacGiaBLL
    {
        TacGiaAccess tga = new TacGiaAccess();

        public List<TacGia> LayToanBoTacGia()
        {
            return tga.LayToanBoTacGia();
        }
        
        public bool CRUD_TacGia(char kieu,string maTG,string tenTG,string diaChi,string phone)
        {
            return tga.CRUD_TacGia(kieu, maTG, tenTG, diaChi, phone);
        }

        public TacGia GetTacGia(int action,string maTG,string tenTG)
        {
            return tga.GetTacGia(action,maTG,tenTG);
        }
    }
}
