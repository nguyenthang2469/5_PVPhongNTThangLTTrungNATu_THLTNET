using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.CSDL
{
    class Docgia : DB
    {
        public static DataTable getAllDocgia()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM DocGia";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
                ad.Dispose();
                conn.Close();
            }
            return dt;
        }

        public static DataRow getDocgia(string tendangnhap)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM DocGia WHERE tendangnhap = '" + tendangnhap + "'";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
                ad.Dispose();
                conn.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]; // Trả về hàng đầu tiên
            }
            else
            {
                return null; // Không tìm thấy bản ghi
            }
        }

        public static DataRow searchDocgia(string field, string keySearch)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM DocGia WHERE " + field + " LIKE '" + keySearch + "%'";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
                ad.Dispose();
                conn.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]; // Trả về hàng đầu tiên
            }
            else
            {
                return null; // Không tìm thấy bản ghi
            }
        }

        public static HttpStatusCode CreateDocgia(
            string madocgia,
            string tendocgia,
            DateTime ngaysinh,
            int gioitinh,
            string diachi,
            string lophoc,
            DateTime ngaytaothe,
            string manhanvientaothe,
            string tendangnhap
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO DocGia VALUES ('" +
                    $"{madocgia}'," +
                    $"N'{tendocgia}'," +
                    $"'{ngaysinh.ToString("yyyy-MM-dd")}', " +
                    $"'{gioitinh}'," +
                    $"N'{diachi}'," +
                    $"N'{lophoc}'," +
                    $"'{ngaytaothe.ToString("yyyy-MM-dd")}'," +
                    $"'{manhanvientaothe}'," +
                    $"'{tendangnhap}')";
                SqlCommand cm = new SqlCommand(sql, conn);
                rowsAffected = cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
            }
            if (rowsAffected > 0) // Nếu có dòng thay đổi
            {
                return HttpStatusCode.Created; // Trả về status code 200 nếu cập nhật thành công
            }
            else
            {
                return HttpStatusCode.InternalServerError; // Hoặc mã trạng thái khác tùy theo trường hợp
            }
        }

        public static HttpStatusCode UpdateDocgia(
            string madocgia,
            string tendocgia,
            DateTime ngaysinh,
            int gioitinh,
            string diachi,
            string lophoc,
            DateTime ngaytaothe
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE DocGia SET " +
                    $"tendocgia = N'{tendocgia}', " +
                    $"ngaysinh = '{ngaysinh.ToString("yyyy - MM - dd")}', " +
                    $"gioitinh = '{gioitinh}', " +
                    $"diachi = N'{diachi}', " +
                    $"lophoc = N'{lophoc}', " +
                    $"ngaytaothe = '{ngaytaothe.ToString("yyyy-MM-dd")}' " +
                    $"WHERE madocgia = '{madocgia}'";
                SqlCommand cm = new SqlCommand(sql, conn);
                rowsAffected = cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
            }
            if (rowsAffected > 0) // Nếu có dòng thay đổi
            {
                return HttpStatusCode.OK; // Trả về status code 200 nếu cập nhật thành công
            }
            else
            {
                return HttpStatusCode.InternalServerError; // Hoặc mã trạng thái khác tùy theo trường hợp
            }
        }
        public static HttpStatusCode DeleteDocgia(string madocgia)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM DocGia WHERE madocgia = '" + madocgia + "'";
                SqlCommand cm = new SqlCommand(sql, conn);
                rowsAffected = cm.ExecuteNonQuery();
                cm.Dispose();
                conn.Close();
            }
            if (rowsAffected > 0) // Nếu có dòng thay đổi
            {
                return HttpStatusCode.OK; // Trả về status code 200 nếu xóa thành công
            }
            else
            {
                return HttpStatusCode.InternalServerError; // Hoặc mã trạng thái khác tùy theo trường hợp
            }
        }
    }
}
