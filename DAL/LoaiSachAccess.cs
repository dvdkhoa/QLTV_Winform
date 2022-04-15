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
    public class LoaiSachAccess:DataAccess
    {
        public List<LoaiSach> LayToanBoLoaiSach()
        {
            List<LoaiSach> dsLS = new List<LoaiSach>();
            OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM LoaiSach";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                LoaiSach ls = new LoaiSach();

                ls.MaLoaiSach = reader.GetString(0);
                ls.TenLoaiSach = reader.GetString(1);
                
                dsLS.Add(ls);
            }
            reader.Close();
            CloseConnection();

            return dsLS;
        }
        public bool CRUD_LoaiSach(char kieu, string maLS,string tenLS)
        {
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CRUD_LoaiSach";
                command.Parameters.AddWithValue("@kieu", kieu);
                command.Parameters.AddWithValue("@maLS", maLS);
                command.Parameters.AddWithValue("@tenLS", tenLS);
                command.Connection = conn;

                return command.ExecuteNonQuery() > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public LoaiSach GetLoaiSach(int kieu,string maLS,string tenLS)
        {
            OpenConnection();
            LoaiSach ls = new LoaiSach();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "uspSelectLoaiSach";
            command.Parameters.AddWithValue("@Action", kieu);
            command.Parameters.AddWithValue("@MaLS", maLS);
            command.Parameters.AddWithValue("TenLS", tenLS);
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                ls.MaLoaiSach = reader.GetString(0);
                ls.TenLoaiSach = reader.GetString(1);
                reader.Close();
            }    
            CloseConnection();

            return ls;
        }
    }
}
