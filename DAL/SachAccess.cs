using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SachAccess:DataAccess
    {
        public bool CRUD_Sach(char kieu,int maSach, string maDauSach, int dangMuon)
        {
            OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CRUD_Sach";
            command.Parameters.AddWithValue("@kieu", kieu);
            command.Parameters.AddWithValue("maSach", maSach);
            command.Parameters.AddWithValue("@maDauSach", maDauSach);
            command.Parameters.AddWithValue("@dangMuon", dangMuon);
            command.Connection = conn;

            return command.ExecuteNonQuery() > 0;
        }
        public int Get_SoLuong_Sach(string maDauSach)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM Sach WHERE MaDauSach ='" + maDauSach + "'";
            cmd.Connection = conn;

            return (int)cmd.ExecuteScalar();
        }
        public bool SachDangDuocMuon(int maSach)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand($"SELECT DangMuon FROM Sach WHERE MaSach = {maSach}",this.conn);
            var reader = cmd.ExecuteReader();
            bool dangMuon = false;
            if(reader.Read())
            {
                dangMuon = reader.GetInt32(0) == 1;
            }
            reader.Close();
            CloseConnection();

            return dangMuon;
        }
    }
}
