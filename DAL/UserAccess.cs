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
    public class UserAccess:DataAccess
    {
        public User GetUser(string tenDN)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Get_user";
            cmd.Parameters.AddWithValue("@tenDN", tenDN);
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();
            User u = new User();
            if (reader.Read())
            {
                u.tenDN = reader.GetString(0);
                u.pass = reader.GetString(1);
                u.quyen = reader.GetInt32(2);
            }
            reader.Close();
            CloseConnection();

            return u;
        }
    }
}
