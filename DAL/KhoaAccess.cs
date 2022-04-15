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
    public class KhoaAccess:DataAccess
    {
        public List<Khoa> GetALLKhoa()
        {
            try
            {
                OpenConnection();
                List<Khoa> dsKhoa = new List<Khoa>();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectKhoa";
                command.Parameters.AddWithValue("@Action", 0);
                command.Parameters.AddWithValue("@MaKhoa", "");
                command.Parameters.AddWithValue("@TenKhoa", "");
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Khoa khoa = new Khoa();

                    khoa.MaKhoa = reader.GetString(0);
                    khoa.TenKhoa = reader.GetString(1);
                    
                    dsKhoa.Add(khoa);
                }
                reader.Close();
                CloseConnection();

                return dsKhoa;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Khoa GetKhoa(int kieu, string maKhoa, string tenKhoa)
        {
            OpenConnection();
            Khoa khoa = new Khoa();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "uspSelectKhoa";
            command.Parameters.AddWithValue("@Action", kieu);
            command.Parameters.AddWithValue("@maKhoa", maKhoa);
            command.Parameters.AddWithValue("@tenKhoa", tenKhoa);
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                khoa.MaKhoa = reader.GetString(0);
                khoa.TenKhoa = reader.GetString(1);
            }
            reader.Close();
            CloseConnection();

            return khoa;
        }
    }
}
