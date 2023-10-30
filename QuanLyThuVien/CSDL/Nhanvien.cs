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
    class Nhanvien : DB
    {
        public static DataTable getAllNhanvien()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhanVien";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
                ad.Dispose();
                conn.Close();
            }
            return dt;
        }

        public static DataRow getNhanvien(string tendangnhap)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhanVien WHERE tendangnhap = '" + tendangnhap + "'";
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

        public static DataRow searchNhanvien(string field, string keySearch)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhanVien WHERE " + field + " LIKE '" + keySearch + "%'";
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

        public static HttpStatusCode CreateNhanvien(
            string manhanvien,
            string tennhanvien,
            DateTime ngaysinh,
            int gioitinh,
            string sodienthoai,
            string tendangnhap
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO NhanVien VALUES ('" +
                    $"{manhanvien}'," +
                    $"N'{tennhanvien}'," +
                    $"'{ngaysinh.ToString("yyyy-MM-dd")}', " +
                    $"'{gioitinh}'," +
                    $"'{sodienthoai}'," +
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

        public static HttpStatusCode UpdateNhanvien(
            string manhanvien,
            string tennhanvien,
            DateTime ngaysinh,
            int gioitinh,
            string sodienthoai
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE NhanVien SET " +
                    $"tennhanvien = N'{tennhanvien}', " +
                    $"ngaysinh = '{ngaysinh.ToString("yyyy - MM - dd")}', " +
                    $"gioitinh = '{gioitinh}', " +
                    $"sodienthoai = '{sodienthoai}'" +
                    $"WHERE manhanvien = '{manhanvien}'";
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
        public static HttpStatusCode DeleteNhanvien(string manhanvien)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM NhanVien WHERE manhanvien = '" + manhanvien + "'";
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
