using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.CSDL
{
    public class Account : DB
    {
        public static int count(string loainguoidung)
        {
            int count = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string whereClause = "";
                if(loainguoidung.Equals("quanly"))
                {
                    whereClause = " WHERE loainguoidung <> 'quanly'";
                } else if(loainguoidung.Equals("thuthu"))
                {
                    whereClause = " WHERE loainguoidung = 'docgia'";
                }
                string sql = "SELECT COUNT(*) FROM NguoiDung" + whereClause;
                MessageBox.Show(sql);
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    count = (int)cm.ExecuteScalar();
                }
                MessageBox.Show(count.ToString());
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
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
                conn.Close();
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchAccount(string loainguoidung, int pageSize, int pageIndex, string keyword = "")
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;
                string condition = "";

                if (loainguoidung.Equals("quanly"))
                {
                    condition = "loainguoidung <> 'quanly'";
                }
                else if (loainguoidung.Equals("thuthu"))
                {
                    condition = "loainguoidung = 'docgia'";
                }
                else
                {
                    // Trả về Tuple với totalAccount = 0 và listAccount = null
                    return Tuple.Create(0, (DataTable)null);
                }

                string sql = $"SELECT COUNT(*) FROM NguoiDung WHERE tendangnhap like @keyword and {condition}";
                using (SqlCommand countCmd = new SqlCommand(sql, conn))
                {
                    countCmd.Parameters.AddWithValue("@keyword", $"{keyword}%");
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sql = $"SELECT * FROM NguoiDung WHERE tendangnhap like @keyword and {condition} ORDER BY tendangnhap OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@keyword", $"{keyword}%");
                    cm.Parameters.AddWithValue("@offset", offset);
                    cm.Parameters.AddWithValue("@pageSize", pageSize);

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }

            // Trả về Tuple với totalAccount và listAccount
            return Tuple.Create(totalAccount, dt);
        }

        public static DataRow getAccount(string tendangnhap)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = $"SELECT * FROM NguoiDung WHERE tendangnhap = @tendangnhap";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@tendangnhap", tendangnhap);

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
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

        public static bool CreateAccount(string tendangnhap, string matkhau, string loainguoidung)
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
                return true; // Trả về status code 200 nếu cập nhật thành công
            }
            return false; // Hoặc mã trạng thái khác tùy theo trường hợp
        }

        public static bool UpdateAccount(string tendangnhap, string matkhau)
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
                return true; // Trả về status code 200 nếu cập nhật thành công
            }
            return false; // Hoặc mã trạng thái khác tùy theo trường hợp
        }

        public static bool UpdateAccount(string tendangnhap, string matkhau, string loainguoidung)
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
                return true; // Trả về status code 200 nếu cập nhật thành công
            }
            return false; // Hoặc mã trạng thái khác tùy theo trường hợp
        }

        public static bool DeleteAccount(string tendangnhap)
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
                return true; // Trả về status code 200 nếu xóa thành công
            }
            return false; // Hoặc mã trạng thái khác tùy theo trường hợp
        }
    }
}
