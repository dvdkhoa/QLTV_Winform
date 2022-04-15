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
    public class BoMonAccess:DataAccess
    {
        public List<BoMon> GetALLBoMon()
        {
            try
            {
                List<BoMon> dsBoMon = new List<BoMon>();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectBoMon";
                command.Parameters.AddWithValue("@Action", 0);
                command.Parameters.AddWithValue("@maBM", "");
                command.Parameters.AddWithValue("@tenBM", "");
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BoMon bm = new BoMon();

                    bm.MaBoMon = reader.GetString(0);
                    bm.TenBoMon = reader.GetString(1);
                    bm.MaKhoa = reader.GetString(2);

                    dsBoMon.Add(bm);
                }
                reader.Close();
                CloseConnection();

                return dsBoMon;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
