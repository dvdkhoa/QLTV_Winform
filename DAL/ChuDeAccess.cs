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
    public class ChuDeAccess:DataAccess
    {
        public List<ChuDe> GetAll_ChuDe()
        {
            try
            {
                List<ChuDe> dsCD = new List<ChuDe>();
                OpenConnection();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectChuDe";
                command.Parameters.AddWithValue("@Action", 0);
                command.Parameters.AddWithValue("@maCD", "");
                command.Parameters.AddWithValue("@tenCD", "");

                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ChuDe cd = new ChuDe();

                    cd.MaChuDe = reader.GetString(0);
                    cd.TenChuDe = reader.GetString(1);

                    dsCD.Add(cd);
                }
                reader.Close();
                CloseConnection();

                return dsCD;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public ChuDe GetChuDe(int kieu, string maCD, string tenCD)
        {
            OpenConnection();
            ChuDe cd = new ChuDe();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "uspSelectChuDe";
            command.Parameters.AddWithValue("@Action", kieu);
            command.Parameters.AddWithValue("@maCD", maCD);
            command.Parameters.AddWithValue("tenCD", tenCD);
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                cd.MaChuDe = reader.GetString(0);
                cd.TenChuDe = reader.GetString(1);
            }
            reader.Close();
            CloseConnection();

            return cd;
        }
    }
}
