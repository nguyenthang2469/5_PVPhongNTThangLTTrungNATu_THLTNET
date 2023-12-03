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
    class Nhanvien : DB
    {
        public static DataTable getAllNhanvien()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhanVien";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchNhanvien(int pageSize, int pageIndex, string keyword = "")
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;

                string sqlCount = "SELECT COUNT(*) FROM NhanVien";
                string sqlSelect = "SELECT * FROM NhanVien";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sqlCount += " WHERE (manhanvien LIKE @keyword OR tennhanvien LIKE @keyword OR tendangnhap LIKE @keyword)";
                    sqlSelect += " WHERE (manhanvien LIKE @keyword OR tennhanvien LIKE @keyword OR tendangnhap LIKE @keyword)";
                }

                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sqlSelect += " ORDER BY manhanvien OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }

                    cm.Parameters.AddWithValue("@offset", offset);
                    cm.Parameters.AddWithValue("@pageSize", pageSize);

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }

            // Trả về Tuple với totalAccount và listAccount
            return Tuple.Create(totalAccount, dt);
        }

        public static DataRow getNhanvien(string manhanvien)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhanVien WHERE manhanvien = @manhanvien";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable exportToExcel(string keyword = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = connect())
            {
                conn.Open();

                string sqlSelect = "SELECT manhanvien as 'Mã nhân viên', " +
                                "tennhanvien as 'Tên nhân viên', " +
                                "FORMAT(ngaysinh, 'dd/MM/yyyy') as 'Ngày sinh', " +
                                "gioitinh as 'Giới tính', " +
                                "sodienthoai as 'Số điện thoại' FROM NhanVien";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sqlSelect += " WHERE (manhanvien LIKE @keyword OR tennhanvien LIKE @keyword OR tendangnhap LIKE @keyword)";
                }

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }

            return dt;
        }

        public static DataRow getNhanvienByTendangnhap(string tendangnhap)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhanVien WHERE tendangnhap = @tendangnhap";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool createNhanvien(
            string manhanvien,
            string tennhanvien,
            DateTime ngaysinh,
            string gioitinh,
            string sodienthoai,
            string tendangnhap
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "INSERT INTO NhanVien VALUES (@manhanvien, @tennhanvien, @ngaysinh, @gioitinh, @sodienthoai, @tendangnhap)";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.Parameters.AddWithValue("@tennhanvien", tennhanvien);
                    cm.Parameters.AddWithValue("@ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@gioitinh", gioitinh);
                    cm.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                    cm.Parameters.AddWithValue("@tendangnhap", tendangnhap);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool updateNhanvien(
            string manhanvien,
            string tennhanvien,
            DateTime ngaysinh,
            string gioitinh,
            string sodienthoai
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE NhanVien SET " +
                    "tennhanvien = @tennhanvien, " +
                    "ngaysinh = @ngaysinh, " +
                    "gioitinh = @gioitinh, " +
                    "sodienthoai = @sodienthoai " +
                    "WHERE manhanvien = @manhanvien";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@tennhanvien", tennhanvien);
                    cm.Parameters.AddWithValue("@ngaysinh", ngaysinh.ToString("yyyy - MM - dd"));
                    cm.Parameters.AddWithValue("@gioitinh", gioitinh);
                    cm.Parameters.AddWithValue("@sodienthoai", sodienthoai);
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
        public static bool deleteNhanvien(string manhanvien, string tendangnhap)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM NhanVien WHERE manhanvien = @manhanvien";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0 && Account.DeleteAccount(tendangnhap);
        }
    }
}
