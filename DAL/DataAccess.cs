using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DataAccess
    {
        private string strconn = "Server=DVDKHOA\\SQLEXPRESS;Database=QLTV_3;Trusted_Connection=True";
        protected SqlConnection conn = null;


        public void OpenConnection()
        {
            try
            {
                if(conn==null)
                {
                    conn = new SqlConnection(strconn);
                    conn.Open();
                    return;
                }
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
