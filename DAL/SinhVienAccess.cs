using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Data.OleDb;

namespace DAL
{
    public class SinhVienAccess:DataAccess
    {
        public List<SinhVien> LayToanBoSinhVien()
        {
            try
            {
                OpenConnection();
                List<SinhVien> dsSV = new List<SinhVien>();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "uspSelectSinhVien";
                command.Parameters.AddWithValue("@Action", 0);
                command.Parameters.AddWithValue("@MaSV", "NULL");
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    SinhVien sv = new SinhVien();
                    sv.MaSV = reader.GetString(0);
                    sv.TenSV = reader.GetString(1);
                    sv.NgaySinh = reader.GetDateTime(2);
                    sv.GioiTinh = reader.GetString(3);
                    
                    if(!reader.IsDBNull(4))
                        sv.Phone = reader.GetString(4);

                    sv.Lop = reader.GetString(5);
                    sv.Nganh = reader.GetString(6);
                    sv.Khoa = reader.GetString(7);

                    dsSV.Add(sv);
                }
                reader.Close();
                CloseConnection();

                return dsSV;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool CRUD_SinhVien(char kieu,string maSV,string tenSV,DateTime ngaySinh,
            string gioiTinh,string phone,string lop, string maNganh,string maKhoa)
        {
            //try
            //{
                OpenConnection();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CRUD_SinhVien";
                command.Parameters.AddWithValue("@kieu", kieu);
                command.Parameters.AddWithValue("@maSV", maSV);
                command.Parameters.AddWithValue("@tenSV", tenSV);
                command.Parameters.AddWithValue("@ngaySinh", ngaySinh);
                command.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@lop", lop);
                command.Parameters.AddWithValue("@maNganh", maNganh);
                command.Parameters.AddWithValue("@maKhoa", maKhoa);
                command.Connection = conn;

                int kq = command.ExecuteNonQuery();

                return kq > 0;

        //}catch(Exception ex)
        //    {
        //        throw ex;
        //    }
}
        public SinhVien GetSinhVien(string maSV)
        {
            try
            {
                OpenConnection();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspSelectSinhVien";
                cmd.Parameters.AddWithValue("@action", 1);

                cmd.Parameters.AddWithValue("@maSV", maSV);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                SinhVien sv = new SinhVien();
                if (reader.Read())
                {
                    sv.MaSV = reader.GetString(0);
                    sv.TenSV = reader.GetString(1);
                    sv.NgaySinh = reader.GetDateTime(2);
                    sv.GioiTinh = reader.GetString(3);
                    sv.Phone = reader.GetString(4);
                    sv.Lop = reader.GetString(5);
                    sv.Nganh = reader.GetString(6);
                    sv.Khoa = reader.GetString(7);
                }
                reader.Close();
                CloseConnection();

                return sv;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_excel(string _path)
        {
            try
            {
                OpenConnection();

                string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", _path);
                OleDbConnection Econ = new OleDbConnection(constr);
                string Query = string.Format("Select [maSV],[tenSV],[ngaySinh],[gioiTinh],[phone],[lop],[nganh],[khoa] FROM [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                Econ.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                Econ.Close();
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];

                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["maSV"] == DBNull.Value || Exceldt.Rows[i]["gioiTinh"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                }
                Exceldt.AcceptChanges();
                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(conn);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SinhVien";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("maSV", "maSV");
                objbulk.ColumnMappings.Add("tenSV", "tenSV");
                objbulk.ColumnMappings.Add("ngaySinh", "ngaySinh");
                objbulk.ColumnMappings.Add("gioiTinh", "gioiTinh");
                objbulk.ColumnMappings.Add("phone", "phone");
                objbulk.ColumnMappings.Add("lop", "lop");
                objbulk.ColumnMappings.Add("nganh", "maNganh");
                objbulk.ColumnMappings.Add("khoa", "maKhoa");

                bool flag = false;
                //inserting Datatable Records to DataBase   
               
                objbulk.WriteToServer(Exceldt);
                CloseConnection();
                flag = true;
                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
