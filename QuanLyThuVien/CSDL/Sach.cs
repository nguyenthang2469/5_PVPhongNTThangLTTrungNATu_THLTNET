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
    class Sach : DB
    {
        public static DataTable getAllSach()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM Sach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchSach(int pageSize, int pageIndex, string keyword = "", string tacgiaTimkiem = "", string nhaxuatbanTimkiem = "")
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;

                string sqlCount = "SELECT COUNT(*) FROM Sach s " +
                                    "INNER JOIN TacGia tg ON s.matacgia = tg.matacgia " +
                                    "INNER JOIN NhaXuatBan nxb ON s.manhaxuatban = nxb.manhaxuatban";
                string sqlSelect = "SELECT s.*, tentacgia, tennhaxuatban FROM Sach s " +
                                    "INNER JOIN TacGia tg ON s.matacgia = tg.matacgia " +
                                    "INNER JOIN NhaXuatBan nxb ON s.manhaxuatban = nxb.manhaxuatban";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (masach LIKE @keyword OR tensach LIKE @keyword OR loaisach LIKE @keyword)";
                }
                if (tacgiaTimkiem != "")
                {
                    if(condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "s.matacgia = @matacgia";
                }
                if (nhaxuatbanTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "s.manhaxuatban = @manhaxuatban";
                }
                sqlCount += condition;
                sqlSelect += condition;
                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(tacgiaTimkiem))
                    {
                        countCmd.Parameters.AddWithValue("@matacgia", $"{tacgiaTimkiem}");
                    }
                    if (!string.IsNullOrEmpty(nhaxuatbanTimkiem))
                    {
                        countCmd.Parameters.AddWithValue("@manhaxuatban", $"{nhaxuatbanTimkiem}");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sqlSelect += " ORDER BY masach OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(tacgiaTimkiem))
                    {
                        cm.Parameters.AddWithValue("@matacgia", $"{tacgiaTimkiem}");
                    }
                    if (!string.IsNullOrEmpty(nhaxuatbanTimkiem))
                    {
                        cm.Parameters.AddWithValue("@manhaxuatban", $"{nhaxuatbanTimkiem}");
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

        public static DataRow getSach(string masach)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM Sach WHERE masach = @masach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@masach", masach);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable exportToExcel(string keyword = "", string tacgiaTimkiem = "", string nhaxuatbanTimkiem = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sqlSelect = "SELECT masach as 'Mã sách', " +
                                    "tensach as 'Tên sách', " +
                                    "loaisach as 'Loại sách', " +
                                    "tentacgia as 'Tên tác giả', " +
                                    "tennhaxuatban as 'Tên nhà xuất bản', " +
                                    "FORMAT(ngayxuatban, 'dd/MM/yyyy') as 'Ngày xuất bản', " +
                                    "soluong as 'Số lượng' FROM Sach s " +
                                    "INNER JOIN TacGia tg ON s.matacgia = tg.matacgia " +
                                    "INNER JOIN NhaXuatBan nxb ON s.manhaxuatban = nxb.manhaxuatban";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (masach LIKE @keyword OR tensach LIKE @keyword OR loaisach LIKE @keyword)";
                }
                if (tacgiaTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE s.matacgia = @matacgia";
                    }
                    else
                    {
                        condition += " AND s.matacgia = @matacgia";
                    }
                }
                if (nhaxuatbanTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE s.manhaxuatban = @manhaxuatban";
                    }
                    else
                    {
                        condition += " AND s.manhaxuatban = @manhaxuatban";
                    }
                }
                sqlSelect += condition;

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(tacgiaTimkiem))
                    {
                        cm.Parameters.AddWithValue("@matacgia", $"{tacgiaTimkiem}");
                    }
                    if (!string.IsNullOrEmpty(nhaxuatbanTimkiem))
                    {
                        cm.Parameters.AddWithValue("@manhaxuatban", $"{nhaxuatbanTimkiem}");
                    }

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }

            return dt;
        }

        public static bool createSach(
            string masach,
            string tensach,
            string loaisach,
            string matacgia,
            string manhaxuatban,
            DateTime ngayxuatban,
            int soluong
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO Sach VALUES (@masach, @tensach, @loaisach,  @matacgia, @manhaxuatban, @ngayxuatban, @soluong)";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@masach", masach);
                    cm.Parameters.AddWithValue("@tensach", tensach);
                    cm.Parameters.AddWithValue("@loaisach", loaisach);
                    cm.Parameters.AddWithValue("@matacgia", matacgia);
                    cm.Parameters.AddWithValue("@manhaxuatban", manhaxuatban);
                    cm.Parameters.AddWithValue("@ngayxuatban", ngayxuatban.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@soluong", soluong);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool updateSach(
            string masach,
            string tensach,
            string loaisach,
            string matacgia,
            string manhaxuatban,
            DateTime ngayxuatban,
            int soluong
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE Sach SET " +
                    "tensach = @tensach, " +
                    "loaisach = @loaisach, " +
                    "matacgia = @matacgia, " +
                    "manhaxuatban = @manhaxuatban, " +
                    "ngayxuatban = @ngayxuatban, " +
                    "soluong = @soluong " +
                    "WHERE masach = @masach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@masach", masach);
                    cm.Parameters.AddWithValue("@tensach", tensach);
                    cm.Parameters.AddWithValue("@loaisach", loaisach);
                    cm.Parameters.AddWithValue("@matacgia", matacgia);
                    cm.Parameters.AddWithValue("@manhaxuatban", manhaxuatban);
                    cm.Parameters.AddWithValue("@ngayxuatban", ngayxuatban.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@soluong", soluong);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool deleteSach(string masach)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM Sach WHERE masach = @masach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@masach", masach);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
