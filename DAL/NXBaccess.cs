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
    public class NXBaccess:DataAccess
    {
        public List<NXB> LayToanBoNXB()
        {
            List<NXB> dsNXB = new List<NXB>();
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM NXB";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NXB nxb = new NXB();
                nxb.MaNXB = reader.GetString(0);
                nxb.TenNXB = reader.GetString(1);
                if(!reader.IsDBNull(2))
                {
                    nxb.DiaChi = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    nxb.Phone = reader.GetString(3);
                }
                dsNXB.Add(nxb);
            }
            reader.Close();
            return dsNXB;
        }
        public bool CRUD_NXB(char kieu,string maNXB,string tenNXB,string diachi,string phone)
        {
            OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "CRUD_NXB";
            command.Parameters.AddWithValue("@kieu", kieu);
            command.Parameters.AddWithValue("@maNXB", maNXB);
            command.Parameters.AddWithValue("@tenNXB", tenNXB);
            command.Parameters.AddWithValue("@diachi", diachi);
            command.Parameters.AddWithValue("@phone", phone);
            command.Connection = conn;

            return command.ExecuteNonQuery() > 0;
        }
        public NXB GetNXB(int kieu,string maNXB,string tenNXB)
        {
            OpenConnection();
            NXB nxb = new NXB();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "uspSelectNXB";
            command.Parameters.AddWithValue("@Action", kieu);
            command.Parameters.AddWithValue("@MaNXB", maNXB);
            command.Parameters.AddWithValue("@TenNXB", tenNXB);
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                nxb.MaNXB = reader.GetString(0);
                nxb.TenNXB = reader.GetString(1);
                if (!reader.IsDBNull(2))
                    nxb.DiaChi = reader.GetString(2);
                if (!reader.IsDBNull(3))
                    nxb.Phone = reader.GetString(3);
            }
            reader.Close();
            CloseConnection();

            return nxb;
        }
    }
}
