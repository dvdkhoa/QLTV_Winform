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
    public class ChiTietMuonAccess:DataAccess
    {
        public List<ChiTietMuon> LayToanBoCTMuon()
        {
            OpenConnection();
            List<ChiTietMuon> dsCT = new List<ChiTietMuon>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_selectChiTietMuon";
            command.Parameters.AddWithValue("@action", 100);
            command.Parameters.AddWithValue("maPM", "");
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ChiTietMuon ct = new ChiTietMuon();
                ct.MaPM = reader.GetInt32(0);
                ct.MaSach = reader.GetInt32(1);
            }
            reader.Close();
            CloseConnection();

            return dsCT;
        }

        public List<ChiTietMuon> GetChiTietMuon(int maPM)
        {
            OpenConnection();
            List<ChiTietMuon> dsCTM = new List<ChiTietMuon>();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "usp_SelectChiTietMuon";
            command.Parameters.AddWithValue("@action", 1);
            command.Parameters.AddWithValue("@maPM", maPM);
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ChiTietMuon ct = new ChiTietMuon();
                ct.MaPM = reader.GetInt32(0);
                ct.MaSach = reader.GetInt32(1);

                dsCTM.Add(ct);
            }
            reader.Close();
            CloseConnection();

            return dsCTM;
        }
        public bool CRUD_ChiTietMuon(char kieu,int maPM,int maSach)
        {
            //try
            //{
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CRUD_ChiTietMuon";
                command.Parameters.AddWithValue("@kieu", kieu);
                command.Parameters.AddWithValue("@maPM", maPM);
                command.Parameters.AddWithValue("@maSach", maSach);
                command.Connection=conn;

                int kq = command.ExecuteNonQuery();

                return kq > 0;
            //}catch(Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
