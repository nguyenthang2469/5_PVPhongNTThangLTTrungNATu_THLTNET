using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.CSDL
{
    public class DB
    {
        private static string connectionString = @"Data Source=.;Initial Catalog=quanlythuvien;Integrated Security=True";
        
        // phương thức tạo kết nối
        protected static SqlConnection connect()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable getData(string sql)
        {
            SqlConnection conn = connect();
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ad.Dispose();
            conn.Close();
            return dt;
        }
    }
}
