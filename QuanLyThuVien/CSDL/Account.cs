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
    public class Account : DB
    {
        public static int getTotalElements()
        {
            int count = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NguoiDung";
                SqlCommand cm = new SqlCommand(sql, conn);
                count = (int)cm.ExecuteScalar();
                cm.Dispose();
                conn.Close();
            }
            return count;
        }

        public static DataTable getAllAccount()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NguoiDung";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
                ad.Dispose();
                conn.Close();
            }
            return dt;
        }

        public static DataTable searchAccount(int pageSize, int pageIndex, string keyword = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                int offset = (pageIndex - 1) * pageSize;

                string sql = $"SELECT * FROM NguoiDung WHERE tendangnhap like '{keyword}%' and loainguoidung <> 'quanly' ORDER BY tendangnhap OFFSET {offset} ROWS FETCH NEXT {pageSize} ROWS ONLY";
                SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
                ad.Fill(dt);
                ad.Dispose();
                conn.Close();
            }
            return dt;
        }

        public static DataRow getAccount(string tendangnhap)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = $"SELECT * FROM NguoiDung WHERE tendangnhap = '{tendangnhap}'";
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

        public static HttpStatusCode CreateAccount(string tendangnhap, string matkhau, string loainguoidung)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO NguoiDung VALUES ('{tendangnhap}','{matkhau}','{loainguoidung}')";
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

        public static HttpStatusCode UpdateAccount(string tendangnhap, string matkhau)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE NguoiDung SET matkhau = '{matkhau}' WHERE tendangnhap = '{tendangnhap}'";
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

        public static HttpStatusCode UpdateAccount(string tendangnhap, string matkhau, string loainguoidung)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE NguoiDung SET matkhau = '{matkhau}' , loainguoidung = '{loainguoidung}'  WHERE tendangnhap = '{tendangnhap}'";
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

        public static HttpStatusCode DeleteAccount(string tendangnhap)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"DELETE FROM NguoiDung WHERE tendangnhap = '{tendangnhap}'";
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
