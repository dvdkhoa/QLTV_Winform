using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class PhieuMuonBLL
    {
        PhieuMuonAccess pma = new PhieuMuonAccess();
        ChiTietMuonBLL ctm_bll = new ChiTietMuonBLL();
        SachBLL sachBLL = new SachBLL();

        public List<PhieuMuon> LayToanBoPhieuMuon()
        {
            return pma.LayToanBoPhieuMuon();
        }    
        public List<PhieuMuon> LayToanBoPhieuMuon_ChuaTra()
        {
            return pma.LayToanBoPhieuMuon_ChuaTra();
        }
        public bool CRUD_PhieuMuon(char kieu,int maPM,string maSV,DateTime ngayMuon)
        {
            return pma.CRUD_PhieuMuon(kieu,maPM, maSV, ngayMuon.ToShortDateString());
        }

        public bool MuonSach(PhieuMuon pm, List<ChiTietMuon> dsCTM)
        {
            var kq = this.CRUD_PhieuMuon('t', 0, pm.MaSV, pm.NgayMuon);
            if(kq)
            {
                //Lấy mã phiếu mượn mới vừa add vào database ra để sử dụng
                int maPM = this.Get_MaPM_VuaThem(pm.MaSV);

                foreach (ChiTietMuon ct in dsCTM)
                {
                    kq = ctm_bll.CRUD_ChiTietMuon('t', maPM, ct.MaSach);
                }
            }
            return kq;
        }

        public bool TraSach(int maPM)
        {
            var ds_ctm = ctm_bll.GetChiTietMuon(maPM);
            foreach(var ct in ds_ctm)
            {
                sachBLL.CRUD_Sach('s', ct.MaSach, "", 0);
            }
            return pma.TraSach(maPM);
        }
        public int Check_SV_MuonSach(string maSV)
        {
            return pma.Check_SV_MuonSach(maSV);
        }
        public int Get_MaPM_VuaThem(string maSV)
        {
            return pma.Get_MaPM_VuaThem(maSV);
        }
        public List<PhieuMuon> Get_DS_PM_1_SV_TheoMa(string maSV,byte sl, char kieu, string tu, string den)
        {
            return pma.Get_DS_PM_1_SV_TheoMa(maSV, sl, kieu, tu, den);
        }
    }
}
