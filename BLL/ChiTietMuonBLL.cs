using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ChiTietMuonBLL
    {
        ChiTietMuonAccess cta = new ChiTietMuonAccess();
        public List<ChiTietMuon> LayToanBoCTMuon()
        {
            return cta.LayToanBoCTMuon();
        }
        public List<ChiTietMuon> GetChiTietMuon(int maPM)
        {
            return cta.GetChiTietMuon(maPM);
        }
        public bool CRUD_ChiTietMuon(char kieu, int maPM,int maSach)
        {
            return cta.CRUD_ChiTietMuon(kieu, maPM, maSach);
        }
    }
}
