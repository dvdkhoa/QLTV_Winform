using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAL
{
    public class PhieuMuonAccess:DataAccess
    {
        public List<PhieuMuon> LayToanBoPhieuMuon()
        {
            try
            {
                OpenConnection();
                List<PhieuMuon> dsPM = new List<PhieuMuon>();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SelectPhieuMuon";
                command.Parameters.AddWithValue("@action", 100);
                command.Parameters.AddWithValue("@maPM", "");
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PhieuMuon pm = new PhieuMuon();
                    pm.MaPM = reader.GetInt32(0);
                    pm.MaSV = reader.GetString(1);
                    pm.NgayMuon = reader.GetDateTime(2);

                    if (!reader.IsDBNull(3))
                    {
                        pm.NgayTra = reader.GetDateTime(3);
                    }
                    dsPM.Add(pm);
                }
                reader.Close();
                CloseConnection();

                return dsPM;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<PhieuMuon> LayToanBoPhieuMuon_ChuaTra()
        {
            OpenConnection(); 
            List<PhieuMuon> dsPM = new List<PhieuMuon>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT *FROM PhieuMuon where ngayTra is null";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PhieuMuon pm = new PhieuMuon();
                pm.MaPM = reader.GetInt32(0);
                pm.MaSV = reader.GetString(1);
                pm.NgayMuon = reader.GetDateTime(2);
                
                if(!reader.IsDBNull(3))
                {
                    pm.NgayTra = reader.GetDateTime(3);
                }    
                dsPM.Add(pm);
            }
            reader.Close();
            CloseConnection();
            
            return dsPM;
        }
        public bool CRUD_PhieuMuon(char kieu,int maPM,string maSV,string ngayMuon)
        {
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CRUD_PhieuMuon";
                command.Parameters.AddWithValue("@kieu", kieu);
                command.Parameters.AddWithValue("@maPM", maPM);
                command.Parameters.AddWithValue("@maSV", maSV);
                command.Parameters.AddWithValue("@ngayMuon", ngayMuon);
                
                command.Connection = conn;

                int kq = command.ExecuteNonQuery();

                return kq > 0;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public int Get_MaPM_VuaThem(string maSV)
        {
            try
            {
                OpenConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 maPM FROM PhieuMuon WHERE MaSV='" + maSV + "' ORDER BY maPM DESC";
                cmd.Connection = conn;

                return (int)cmd.ExecuteScalar();
            }    
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool TraSach(int maPM)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "TraSach";
            command.Parameters.AddWithValue("@maPM", maPM);
            command.Parameters.Add("@ngayTra", DateTime.Now);
            command.Connection = conn;

            int kq = command.ExecuteNonQuery();
            return kq > 0;
        }


        public int Check_SV_MuonSach(string maSV)
        {
            try
            {
                OpenConnection();
                List<PhieuMuon> dsPM = new List<PhieuMuon>();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select COUNT(*) from PhieuMuon where NgayTra IS NULL and MaSV='" + maSV + "'";
                cmd.Connection = conn;

                return (int)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<PhieuMuon> Get_DS_PM_1_SV_TheoMa(string maSV, byte sl, char kieu , string tu, string den )
        {
            try
            {
                OpenConnection();
                List<PhieuMuon> dsPM = new List<PhieuMuon>();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                if (kieu == 'a')
                    cmd.CommandText = "SELECT * FROM PhieuMuon WHERE "+ (!(sl==1) ? "" : "PhieuMuon.maSV='" + maSV + "' ");
                else if (kieu == 'd')
                    cmd.CommandText = "SELECT * FROM PhieuMuon WHERE " + (!(sl == 1) ? "" : "PhieuMuon.maSV='" + maSV + "' AND") +
                                                              " DAY(ngayMuon)=" + DateTime.Now.Day;
                else if (kieu == 'w')
                    cmd.CommandText = "SELECT * FROM PhieuMuon WHERE " + (!(sl == 1) ? "" : "PhieuMuon.maSV='" + maSV + "' AND") +
                                               " DATEPART(WEEK,ngayMuon)=DATEPART(WEEK,GETDATE())";
                else if (kieu == 'm')
                    cmd.CommandText = "SELECT * FROM PhieuMuon WHERE " + (!(sl == 1) ? "" : "PhieuMuon.maSV='" + maSV + "' AND") +
                                                            " MONTH(ngayMuon)= " + DateTime.Now.Month;
                else if (kieu == 'q')
                {
                    cmd.CommandText = "SELECT * FROM PhieuMuon WHERE " + (!(sl == 1) ? "" : "PhieuMuon.maSV='" + maSV + "' AND") +
                                        " DATEPART(QUARTER,ngayMuon)=DATEPART(QUARTER,GETDATE())";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM PhieuMuon WHERE " + (!(sl == 1) ? "" : "PhieuMuon.maSV='" + maSV + "' AND") +
                       " ngayMuon BETWEEN '" + tu + "' AND '" + den + "'";
                }
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    PhieuMuon pm = new PhieuMuon();
                    pm.MaPM = reader.GetInt32(0);
                    pm.MaSV = reader.GetString(1);
                    pm.NgayMuon = reader.GetDateTime(2);

                    if (!reader.IsDBNull(3))
                    {
                        pm.NgayTra = reader.GetDateTime(3);
                    }
                    dsPM.Add(pm);
                }
                reader.Close();

                CloseConnection();

                return dsPM;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
