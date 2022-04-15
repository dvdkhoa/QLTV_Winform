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
    public class HocPhanAccess:DataAccess
    {
        public List<HocPhan> Get_ALL_HocPhan()
        {
            try
            {
                OpenConnection();
                List<HocPhan> dsHocPhan = new List<HocPhan>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectHocPhan";
                cmd.Parameters.AddWithValue("Action", 0);
                cmd.Parameters.AddWithValue("maHocPhan", "");
                cmd.Parameters.AddWithValue("tenHocPhan", "");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    HocPhan hp = new HocPhan();
                    hp.MaHocPhan = reader.GetString(0);
                    hp.TenHocPhan = reader.GetString(1);

                    dsHocPhan.Add(hp);
                }
                reader.Close();
                CloseConnection();

                return dsHocPhan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HocPhan Get_HocPhan(byte kieu, string maHocPhan, string tenHocPhan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SelectHocPhan";
                cmd.Parameters.AddWithValue("Action", kieu);
                cmd.Parameters.AddWithValue("maHocPhan", maHocPhan);
                cmd.Parameters.AddWithValue("tenHocPhan", tenHocPhan);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                HocPhan hp = new HocPhan();
                if (reader.Read())
                {
                    hp.MaHocPhan = reader.GetString(0);
                    hp.TenHocPhan = reader.GetString(1);
                }
                reader.Close();
                CloseConnection();

                return hp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
