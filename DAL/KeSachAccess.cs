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
    public class KeSachAccess:DataAccess
    {
        public List<KeSach> Get_ALL_KeSach()
        {
            try
            {
                OpenConnection();
                List<KeSach> dsKeSach = new List<KeSach>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectKeSach";
                cmd.Parameters.AddWithValue("Action", 0);
                cmd.Parameters.AddWithValue("maKeSach", "");
                cmd.Parameters.AddWithValue("tenKeSach", "");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    KeSach ks = new KeSach();
                    ks.MaKeSach = reader.GetString(0);
                    ks.TenKeSach = reader.GetString(1);

                    dsKeSach.Add(ks);
                }
                reader.Close();
                CloseConnection();

                return dsKeSach;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public KeSach Get_KeSach(byte kieu, string maKeSach, string tenKeSach)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectKeSach";
                cmd.Parameters.AddWithValue("Action", kieu);
                cmd.Parameters.AddWithValue("maKeSach", maKeSach);
                cmd.Parameters.AddWithValue("tenKeSach", tenKeSach);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                KeSach ks = new KeSach();
                if(reader.Read())
                {
                    ks.MaKeSach = reader.GetString(0);
                    ks.TenKeSach = reader.GetString(1);
                }
                reader.Close();
                CloseConnection();

                return ks;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
