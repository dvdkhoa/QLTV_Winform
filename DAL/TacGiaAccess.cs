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
    public class TacGiaAccess:DataAccess
    {
        public List<TacGia> LayToanBoTacGia()
        {
            List<TacGia> dsTG = new List<TacGia>();
            OpenConnection();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM TacGia";
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                TacGia tg = new TacGia();
                tg.MaTG = reader.GetString(0);
                tg.TenTG = reader.GetString(1);
                if(!reader.IsDBNull(2))
                {
                    tg.DiaChi = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    tg.phone = reader.GetString(3);
                }
                dsTG.Add(tg);
            }
            reader.Close();
            CloseConnection();
            
            return dsTG; 
        }
        public bool CRUD_TacGia(char kieu,string maTG,string tenTG,string diaChi,string phone)
        {
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CRUD_TacGia";
                command.Parameters.AddWithValue("@kieu", kieu);
                command.Parameters.AddWithValue("@maTG", maTG);
                command.Parameters.AddWithValue("@tenTg", tenTG);
                command.Parameters.AddWithValue("@diachi", diaChi);
                command.Parameters.AddWithValue("@phone", phone);
                command.Connection = conn;

                int ret = command.ExecuteNonQuery();

                CloseConnection();
                return ret > 0;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Number.ToString());
            }
        }
         public TacGia GetTacGia(int action,string maTG,string tenTG)
         {
             try
             {
                 OpenConnection();

                 SqlCommand command = new SqlCommand();
                 command.CommandType = CommandType.StoredProcedure;
                 command.CommandText = "uspSelectTacGia";
                 command.Parameters.AddWithValue("@Action", action);
                 command.Parameters.AddWithValue("@MaTG", maTG);
                 command.Parameters.AddWithValue("@tenTG", tenTG);
                 command.Connection = conn;

                 SqlDataReader reader = command.ExecuteReader();
                 TacGia tg = new TacGia();
                if (reader.Read())
                {
                    tg.MaTG = reader.GetString(0);
                    tg.TenTG = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                        tg.DiaChi = reader.GetString(2);
                    if (!reader.IsDBNull(3))
                        tg.phone = reader.GetString(3);
                    reader.Close();
                }
                CloseConnection();
                return tg;
            }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
    }
}
