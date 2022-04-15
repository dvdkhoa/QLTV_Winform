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
    public class NganhAccess:DataAccess
    {
        public List<Nganh> LayToanBoNganh()
        {
            try
            {
                OpenConnection();
                List<Nganh> dsNganh = new List<Nganh>();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectNganh";
                command.Parameters.AddWithValue("@Action", 0);
                command.Parameters.AddWithValue("@MaNganh", "");
                command.Parameters.AddWithValue("@TenNganh", "");
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Nganh nganh = new Nganh();

                    nganh.MaNganh = reader.GetString(0);
                    nganh.TenNganh = reader.GetString(1);
                    if(!reader.IsDBNull(2))
                    {
                        nganh.MaBoMon = reader.GetString(2);
                    }

                    dsNganh.Add(nganh);
                }
                reader.Close();
                CloseConnection();

                return dsNganh;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Nganh GetNganh(int kieu, string maNganh, string tenNganh)
        {
            OpenConnection();
            Nganh nganh = new Nganh();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "uspSelectNganh";
            command.Parameters.AddWithValue("@Action", kieu);
            command.Parameters.AddWithValue("@maNganh", maNganh);
            command.Parameters.AddWithValue("@tenNganh", tenNganh);
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                nganh.MaNganh = reader.GetString(0);
                nganh.TenNganh= reader.GetString(1);
                if (!reader.IsDBNull(2))
                    nganh.MaBoMon = reader.GetString(2);
            }
            reader.Close();
            CloseConnection();

            return nganh;
        }
    }
}
