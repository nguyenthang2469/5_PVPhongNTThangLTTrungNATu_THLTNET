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
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
                conn.Close();
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchDocgia(int pageSize, int pageIndex, string keyword = "")
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;

                string sqlCount = "SELECT COUNT(*) FROM DocGia";
                string sqlSelect = "SELECT * FROM DocGia";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sqlCount += " WHERE madocgia LIKE @keyword OR tendocgia LIKE @keyword OR lophoc LIKE @keyword OR manhanvientaothe LIKE @keyword OR tendangnhap LIKE @keyword";
                    sqlSelect += " WHERE madocgia LIKE @keyword OR tendocgia LIKE @keyword OR lophoc LIKE @keyword OR manhanvientaothe LIKE @keyword OR tendangnhap LIKE @keyword";
                }

                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sqlSelect += " ORDER BY madocgia OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";

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

        public static DataRow getDocgia(string madocgia)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM DocGia WHERE madocgia = @madocgia";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@madocgia", madocgia);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataRow getDocgiaByTendangnhap(string tendangnhap)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM DocGia WHERE tendangnhap = @tendangnhap";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static bool createDocgia(
            string madocgia,
            string tendocgia,
            DateTime ngaysinh,
            string gioitinh,
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
                string sql = $"INSERT INTO DocGia VALUES (@madocgia, @tendocgia, @ngaysinh,  @gioitinh, @diachi, @lophoc, @ngaytaothe, @manhanvientaothe, @tendangnhap)";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@madocgia", madocgia);
                    cm.Parameters.AddWithValue("@tendocgia", tendocgia);
                    cm.Parameters.AddWithValue("@ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@gioitinh", gioitinh);
                    cm.Parameters.AddWithValue("@diachi", diachi);
                    cm.Parameters.AddWithValue("@lophoc", lophoc);
                    cm.Parameters.AddWithValue("@ngaytaothe", ngaytaothe.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@manhanvientaothe", manhanvientaothe);
                    cm.Parameters.AddWithValue("@tendangnhap", tendangnhap);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool updateDocgia(
            string madocgia,
            string tendocgia,
            DateTime ngaysinh,
            string gioitinh,
            string diachi,
            string lophoc,
            DateTime ngaytaothe,
            string manhanvientaothe
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE DocGia SET " +
                    "tendocgia = @tendocgia, " +
                    "ngaysinh = @ngaysinh, " +
                    "gioitinh = @gioitinh, " +
                    "diachi = @diachi, " +
                    "lophoc = @lophoc, " +
                    "ngaytaothe = @ngaytaothe, " +
                    "manhanvientaothe = @manhanvientaothe " +
                    "WHERE madocgia = @madocgia";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@madocgia", madocgia);
                    cm.Parameters.AddWithValue("@tendocgia", tendocgia);
                    cm.Parameters.AddWithValue("@ngaysinh", ngaysinh.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@gioitinh", gioitinh);
                    cm.Parameters.AddWithValue("@diachi", diachi);
                    cm.Parameters.AddWithValue("@lophoc", lophoc);
                    cm.Parameters.AddWithValue("@ngaytaothe", ngaytaothe);
                    cm.Parameters.AddWithValue("@manhanvientaothe", manhanvientaothe);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool deleteDocgia(string madocgia, string tendangnhap)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM DocGia WHERE madocgia = @madocgia";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@madocgia", madocgia);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0 && Account.DeleteAccount(tendangnhap);
        }
    }
}
