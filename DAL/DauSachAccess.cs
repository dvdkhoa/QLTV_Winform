using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
using System.Data.OleDb;

namespace DAL
{
    public class DauSachAccess : DataAccess
    {
        public List<DauSach> LayToanBoDauSach()
        {
            List<DauSach> dsDauSach = new List<DauSach>();
            //try
            //{
                OpenConnection();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM DauSach";
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DauSach dauSach = new DauSach();
                    dauSach.MaDauSach = reader.GetString(0);
                    dauSach.TenDauSach = reader.GetString(1);
                    dauSach.MaLS = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                    {
                        dauSach.MaChuDe = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        dauSach.MaTG = reader.GetString(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        dauSach.MaNXB = reader.GetString(5);
                    }

                    if (!reader.IsDBNull(6))
                    {
                        dauSach.NamXB = reader.GetInt32(6);
                    }

                    if (!reader.IsDBNull(7))
                    {
                        dauSach.MaNganh = reader.GetString(7);
                    }

                    if (!reader.IsDBNull(8))
                    {
                        dauSach.MaHocPhan = reader.GetString(8);
                    }

                    if (!reader.IsDBNull(9))
                    {
                        dauSach.MaKeSach = reader.GetString(9);
                    }

                    if (!reader.IsDBNull(10))
                    {
                        dauSach.SoTrang = reader.GetInt32(10);
                    }

                    if (!reader.IsDBNull(11))
                    {
                        dauSach.KhoCo = reader.GetString(11);
                    }

                    if (!reader.IsDBNull(12))
                    {
                        dauSach.Tags = reader.GetString(12);
                    }

                    if (!reader.IsDBNull(13))
                    {
                        dauSach.MinhHoa = reader.GetString(13);
                    }

                    if (!reader.IsDBNull(14))
                    {
                        dauSach.GiaBia = (long)reader.GetSqlMoney(14);
                    }

                    if (!reader.IsDBNull(15))
                    {
                        dauSach.Nguon = reader.GetString(15);
                    }

                    if (!reader.IsDBNull(16))
                    {
                        dauSach.TenKhac = reader.GetString(16);
                    }

                    if (!reader.IsDBNull(17))
                    {
                        dauSach.TungThu = reader.GetString(17);
                    }

                    if (!reader.IsDBNull(18))
                    {
                        dauSach.ISBN= reader.GetString(18);
                    }

                    if (!reader.IsDBNull(19))
                    {
                        dauSach.SoTap = reader.GetInt32(19);
                    }

                    if (!reader.IsDBNull(20))
                    {
                        dauSach.TenTap = reader.GetString(20);
                    }

                    if (!reader.IsDBNull(21))
                    {
                        dauSach.DinhKem = reader.GetString(21);
                    }

                    if (!reader.IsDBNull(22))
                    {
                        dauSach.NgonNgu = reader.GetString(22);
                    }

                    dsDauSach.Add(dauSach);
                }
                reader.Close();
                CloseConnection();

                return dsDauSach;
            //}
            //catch (exception ex)
            //{
            //    throw ex;
            //}
        }

        public bool CRUD_DauSach(char kieu, string maDauSach, string tenDauSach,
            string maLS, string maChuDe, string maTG, string maNXB, int namXB,
            string maNganh, string maHocPhan, string maKeSach, int soTrang,
            string khoCo, string tags, string minhHoa, long giaBia, string nguon,
            string tenKhac, string tungThu, string ISBN, int soTap, string tenTap,
            string dinhKem, string ngonNgu)
        {
            //try
            //{
                OpenConnection();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CRUD_DauSach";
                command.Connection = conn;

                command.Parameters.AddWithValue("@Kieu", kieu);
                command.Parameters.AddWithValue("@MaDauSach", maDauSach);
                command.Parameters.AddWithValue("@TenDauSach", tenDauSach);
                command.Parameters.AddWithValue("@MaLS", maLS);
                command.Parameters.AddWithValue("@maChuDe", maChuDe);
                command.Parameters.AddWithValue("@MaTG", maTG);
                command.Parameters.AddWithValue("@MaNXB", maNXB);
                command.Parameters.AddWithValue("@NamXB", namXB);
                command.Parameters.AddWithValue("@maNganh", maNganh);
                
                if(!string.IsNullOrEmpty(maHocPhan))
                    command.Parameters.AddWithValue("@maHocPhan", maHocPhan);    
                else
                    command.Parameters.AddWithValue("@maHocPhan", DBNull.Value);

                if(!string.IsNullOrEmpty(maKeSach))
                    command.Parameters.AddWithValue("@maKeSach", maKeSach);
                else
                    command.Parameters.AddWithValue("@maKeSach", DBNull.Value);

                command.Parameters.AddWithValue("@soTrang", soTrang);
                command.Parameters.AddWithValue("@khoco", khoCo);
                command.Parameters.AddWithValue("@Tags", tags);
                command.Parameters.AddWithValue("@minhHoa", minhHoa);
                command.Parameters.AddWithValue("@giaBia", giaBia);
                command.Parameters.AddWithValue("@nguon", nguon);
                command.Parameters.AddWithValue("@tenKhac", tenKhac);
                command.Parameters.AddWithValue("@tungThu", tungThu);
                command.Parameters.AddWithValue("@isbn", ISBN);
                command.Parameters.AddWithValue("@soTap", soTap);
                command.Parameters.AddWithValue("@tenTap", tenTap);
                command.Parameters.AddWithValue("@dinhKem", dinhKem);
                command.Parameters.AddWithValue("@ngonNgu", ngonNgu);


                int ret = command.ExecuteNonQuery();
                CloseConnection();

                if (ret > 0)
                    return true;
                return false;

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public List<DauSach> TimDauSach(string tenDauSach, string maLS, string maTG, string maNXB, int namXB, string nganh, string khoa, string tags)
        {
            try
            {
                string query;
                bool a = string.IsNullOrEmpty(tenDauSach);
                bool b = string.IsNullOrEmpty(maLS);
                bool c = string.IsNullOrEmpty(maTG);
                bool d = string.IsNullOrEmpty(maNXB);
                bool h = namXB == -1;
                bool e = string.IsNullOrEmpty(nganh);
                bool f = string.IsNullOrEmpty(khoa);
                bool g = string.IsNullOrEmpty(tags);
                if ((a && b && c && d && h && e && f && g))
                    query = "SELECT *FROM DauSach";
                else
                {
                    query = "SELECT *FROM DauSach WHERE";
                    if (!a)
                        query = query + "AND TenDauSach=N'" + tenDauSach + "' ";
                    if (!b)
                        query = query + "AND MaLS='" + maLS + "' ";
                    if (!c)
                        query = query + "AND MaTG='" + maTG + "' ";
                    if (!d)
                        query = query + "AND MaNXB='" + maNXB + "' ";
                    if (!h)
                        query = query + "AND NamXB=" + namXB + " ";
                    if (!e)
                        query = query + "AND Nganh=N'" + nganh + "' ";
                    if (!f)
                        query = query + "AND Khoa=N'" + khoa + "' ";
                    if (!g)
                        query = query + "AND Tags=N'" + tags + "' ";

                    int vt = query.IndexOf("AND");
                    query = query.Remove(vt, 3);
                }
                OpenConnection();
                List<DauSach> dsDauSach = new List<DauSach>();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Connection = conn;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DauSach dauSach = new DauSach();
                    dauSach.MaDauSach = reader.GetString(0);
                    dauSach.TenDauSach = reader.GetString(1);
                    dauSach.MaLS = reader.GetString(2);

                    if (!reader.IsDBNull(3))
                    {
                        dauSach.MaChuDe = reader.GetString(3);
                    }

                    if (!reader.IsDBNull(4))
                    {
                        dauSach.MaTG = reader.GetString(4);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        dauSach.MaNXB = reader.GetString(5);
                    }

                    if (!reader.IsDBNull(6))
                    {
                        dauSach.NamXB = reader.GetInt32(6);
                    }

                    if (!reader.IsDBNull(7))
                    {
                        dauSach.MaNganh = reader.GetString(7);
                    }

                    if (!reader.IsDBNull(8))
                    {
                        dauSach.MaHocPhan = reader.GetString(8);
                    }

                    if (!reader.IsDBNull(9))
                    {
                        dauSach.MaKeSach = reader.GetString(9);
                    }

                    if (!reader.IsDBNull(10))
                    {
                        dauSach.SoTrang = reader.GetInt32(10);
                    }

                    if (!reader.IsDBNull(11))
                    {
                        dauSach.KhoCo = reader.GetString(11);
                    }

                    if (!reader.IsDBNull(12))
                    {
                        dauSach.Tags = reader.GetString(12);
                    }

                    if (!reader.IsDBNull(13))
                    {
                        dauSach.MinhHoa = reader.GetString(13);
                    }

                    if (!reader.IsDBNull(14))
                    {
                        dauSach.GiaBia = (long)reader.GetSqlMoney(14);
                    }

                    if (!reader.IsDBNull(15))
                    {
                        dauSach.Nguon = reader.GetString(15);
                    }

                    if (!reader.IsDBNull(16))
                    {
                        dauSach.TenKhac = reader.GetString(16);
                    }

                    if (!reader.IsDBNull(17))
                    {
                        dauSach.TungThu = reader.GetString(17);
                    }

                    if (!reader.IsDBNull(18))
                    {
                        dauSach.ISBN = reader.GetString(18);
                    }

                    if (!reader.IsDBNull(19))
                    {
                        dauSach.SoTap = reader.GetInt32(19);
                    }

                    if (!reader.IsDBNull(20))
                    {
                        dauSach.TenTap = reader.GetString(20);
                    }

                    if (!reader.IsDBNull(21))
                    {
                        dauSach.DinhKem = reader.GetString(21);
                    }

                    if (!reader.IsDBNull(22))
                    {
                        dauSach.NgonNgu = reader.GetString(22);
                    }

                    dsDauSach.Add(dauSach);
                }
                reader.Close();
                CloseConnection();
                return dsDauSach;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DauSach> TimDauSach_ten_GanDung(string tenDauSach, string maLS, string maCD, string maTG, string maNXB, int namXB, string maNganh, string maKhoa, string tags)
        {

            OpenConnection();
            List<DauSach> dsDauSach = new List<DauSach>();

            string q_tenDauSach = "select *from DauSach where TenSach like N'%" + tenDauSach + "' or TenSach like N'%" + tenDauSach + "%' or TenSach like N'%" + tenDauSach + "'";
            string q_maLS = "select *from DauSach where MaLS='" + maLS + "'";
            string q_maCD = "select *from DauSach where MaChuDe='" + maCD + "'";
            string q_maTG = "select *from DauSach where MaTG='" + maTG + "'";
            string q_maNXB = "select *from DauSach where MaNXB='" + maNXB + "'";
            string q_namXB = "select *from DauSach where NamXB=" + namXB;
            string q_nganh = "select *from DauSach where maNganh='" + maNganh + "'";
            string q_khoa = "select *from DauSach where maKhoa='" + maKhoa + "'";
            string q_tags = "select *from DauSach where Tags like N'%" + tags + "' or Tags like N'%" + tags + "%' or Tags like N'%" + tags + "'";

            bool a = string.IsNullOrEmpty(tenDauSach);
            bool b = string.IsNullOrEmpty(maLS);
            bool k = string.IsNullOrEmpty(maCD);
            bool c = string.IsNullOrEmpty(maTG);
            bool d = string.IsNullOrEmpty(maNXB);
            bool e = namXB == -1;
            bool f = string.IsNullOrEmpty(maNganh);
            bool g = string.IsNullOrEmpty(maKhoa);
            bool h = string.IsNullOrEmpty(tags);

            string query = "";

            if ((a && b && c && d && e && f && g && h && k))
                query = "SELECT *FROM DauSach";
            else
            {
                if (!a)
                    query = query + " intersect " + q_tenDauSach;
                if (!b)
                    query = query + " intersect " + q_maLS;
                if (!c)
                    query = query + " intersect " + q_maTG;
                if (!d)
                    query = query + " intersect " + q_maNXB;
                if (!e)
                    query = query + " intersect " + q_namXB;
                if (!f)
                    query = query + " intersect " + q_nganh;
                if (!g)
                    query = query + " intersect " + q_khoa;
                if (!h)
                    query = query + " intersect " + q_tags;
                if(!k)
                    query = query + " intersect " + q_maCD;

                int vt = query.IndexOf("intersect");
                query = query.Remove(vt, 10);
            }
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Connection = conn;

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DauSach dauSach = new DauSach();
                dauSach.MaDauSach = reader.GetString(0);
                dauSach.TenDauSach = reader.GetString(1);
                dauSach.MaLS = reader.GetString(2);

                if (!reader.IsDBNull(3))
                {
                    dauSach.MaChuDe = reader.GetString(3);
                }

                if (!reader.IsDBNull(4))
                {
                    dauSach.MaTG = reader.GetString(4);
                }

                if (!reader.IsDBNull(5))
                {
                    dauSach.MaNXB = reader.GetString(5);
                }

                if (!reader.IsDBNull(6))
                {
                    dauSach.NamXB = reader.GetInt32(6);
                }

                if (!reader.IsDBNull(7))
                {
                    dauSach.MaNganh = reader.GetString(7);
                }

                if (!reader.IsDBNull(8))
                {
                    dauSach.MaHocPhan = reader.GetString(8);
                }

                if (!reader.IsDBNull(9))
                {
                    dauSach.MaKeSach = reader.GetString(9);
                }

                if (!reader.IsDBNull(10))
                {
                    dauSach.SoTrang = reader.GetInt32(10);
                }

                if (!reader.IsDBNull(11))
                {
                    dauSach.KhoCo = reader.GetString(11);
                }

                if (!reader.IsDBNull(12))
                {
                    dauSach.Tags = reader.GetString(12);
                }

                if (!reader.IsDBNull(13))
                {
                    dauSach.MinhHoa = reader.GetString(13);
                }

                if (!reader.IsDBNull(14))
                {
                    dauSach.GiaBia = (long)reader.GetSqlMoney(14);
                }

                if (!reader.IsDBNull(15))
                {
                    dauSach.Nguon = reader.GetString(15);
                }

                if (!reader.IsDBNull(16))
                {
                    dauSach.TenKhac = reader.GetString(16);
                }

                if (!reader.IsDBNull(17))
                {
                    dauSach.TungThu = reader.GetString(17);
                }

                if (!reader.IsDBNull(18))
                {
                    dauSach.ISBN = reader.GetString(18);
                }

                if (!reader.IsDBNull(19))
                {
                    dauSach.SoTap = reader.GetInt32(19);
                }

                if (!reader.IsDBNull(20))
                {
                    dauSach.TenTap = reader.GetString(20);
                }

                if (!reader.IsDBNull(21))
                {
                    dauSach.DinhKem = reader.GetString(21);
                }

                if (!reader.IsDBNull(22))
                {
                    dauSach.NgonNgu = reader.GetString(22);
                }

                dsDauSach.Add(dauSach);
            }
            reader.Close();
            CloseConnection();

            return dsDauSach;
        }
        public void MuonDauSach(string maDauSach)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE DauSach SET SL=SL-1 WHERE MaDauSach='" + maDauSach + "'";
                cmd.Connection = conn;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        SachAccess s_acc = new SachAccess();
        List<String> dsDauSach = new List<string>();
        List<int> dsSL = new List<int>();
        public bool Insert_excel_dauSach(string _path)
        {
            //try
            //{
                OpenConnection();

                string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", _path);
                OleDbConnection Econ = new OleDbConnection(constr);
                string Query = string.Format("Select [MaDauSach], [TenSach], [MaLS], [maChuDe], [MaTG], [MaNXB], [NamXB]," +
                    " [maNganh], [MaHocPhan], [MaKeSach], [SoTrang], [KhoCo], [Tags], [MinhHoa], [GiaBia]," +
                    " [Nguon], [TenKhac], [TungThu], [ISBN], [SoTap], [TenTap], [DinhKem], [NgonNgu], [SoLuong] FROM [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                Econ.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                Econ.Close();
                oda.Fill(ds);
                DataTable Exceldt = ds.Tables[0];

                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["MaDauSach"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                        continue;
                    }
                        dsDauSach.Add((string)Exceldt.Rows[i]["MaDauSach"]);
                        dsSL.Add((int)int.Parse(Exceldt.Rows[i]["SoLuong"].ToString()));
                }
                Exceldt.AcceptChanges();
                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(conn);
                //assigning Destination table name      
                objbulk.DestinationTableName = "DauSach";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("MaDauSach", "MaDauSach");
                objbulk.ColumnMappings.Add("TenSach", "TenSach");
                objbulk.ColumnMappings.Add("MaLS", "MaLS");
                objbulk.ColumnMappings.Add("maChuDe", "maChuDe");
                objbulk.ColumnMappings.Add("MaTG", "MaTG");
                objbulk.ColumnMappings.Add("MaNXB", "MaNXB");
                objbulk.ColumnMappings.Add("NamXB", "NamXB");
                objbulk.ColumnMappings.Add("maNganh", "maNganh");
                objbulk.ColumnMappings.Add("MaHocPhan", "MaHocPhan");
                objbulk.ColumnMappings.Add("MaKeSach", "MaKeSach");
                objbulk.ColumnMappings.Add("SoTrang", "SoTrang");
                objbulk.ColumnMappings.Add("KhoCo", "KhoCo");
                objbulk.ColumnMappings.Add("Tags", "Tags");
                objbulk.ColumnMappings.Add("MinhHoa", "MinhHoa");
                objbulk.ColumnMappings.Add("GiaBia", "GiaBia");
                objbulk.ColumnMappings.Add("Nguon", "Nguon");
                objbulk.ColumnMappings.Add("TenKhac", "TenKhac");
                objbulk.ColumnMappings.Add("TungThu", "TungThu");
                objbulk.ColumnMappings.Add("ISBN", "ISBN");
                objbulk.ColumnMappings.Add("SoTap", "SoTap");
                objbulk.ColumnMappings.Add("TenTap", "TenTap");
                objbulk.ColumnMappings.Add("DinhKem", "DinhKem");
                objbulk.ColumnMappings.Add("NgonNgu", "NgonNgu");
                
                

                bool flag = false;
                //inserting Datatable Records to DataBase   

                objbulk.WriteToServer(Exceldt);
                CloseConnection();
                for(int i=0;i<dsDauSach.Count;i++)
                {
                    for(int j=0; j<dsSL[i]; j++)
                    {
                    s_acc.CRUD_Sach('t', 0, dsDauSach[i], 0);
                }
                }
                flag = true;

                return flag;
            
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
