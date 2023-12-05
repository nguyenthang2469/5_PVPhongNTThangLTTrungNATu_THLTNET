using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.CSDL
{
    class Phieumuon : DB
    {
        public static DataTable getAllPhieumuon()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM PhieuMuon";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchPhieumuon(int pageSize, int pageIndex, string keyword = "", string nhanvienTimkiem = "", string docgiaTimkiem = "")
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;

                string sqlCount = "SELECT COUNT(*) FROM PhieuMuon p " +
                                    "INNER JOIN NhanVien nv ON p.manhanvienlapphieu = nv.manhanvien " +
                                    "INNER JOIN DocGia dg ON p.madocgia = dg.madocgia ";
                string sqlSelect = "SELECT p.*, tennhanvien, tendocgia FROM PhieuMuon p " +
                                    "INNER JOIN NhanVien nv ON p.manhanvienlapphieu = nv.manhanvien " +
                                    "INNER JOIN DocGia dg ON p.madocgia = dg.madocgia ";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (p.maphieumuon LIKE @keyword OR tennhanvien LIKE @keyword OR tendocgia LIKE @keyword OR ngaylapphieu LIKE @keyword)";
                }
                if (nhanvienTimkiem != "")
                {
                    if(condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "p.manhanvienlapphieu = @manhanvienlapphieu";
                }
                if (docgiaTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "p.madocgia = @madocgia";
                }
                sqlCount += condition;
                sqlSelect += condition;
                
                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        if (DateTime.TryParseExact(keyword, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                        {    
                            countCmd.Parameters.AddWithValue("@keyword", "%" + result.ToString("yyyy-MM-dd") + "%");
                        }
                        else
                        {
                            countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        }
                    }
                    if (!string.IsNullOrEmpty(nhanvienTimkiem))
                    {
                        countCmd.Parameters.AddWithValue("@manhanvienlapphieu", $"{nhanvienTimkiem}");
                    }
                    if (!string.IsNullOrEmpty(docgiaTimkiem))
                    {
                        countCmd.Parameters.AddWithValue("@madocgia", $"{docgiaTimkiem}");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sqlSelect += " ORDER BY maphieumuon OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";
                Console.WriteLine(sqlSelect);

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        if (DateTime.TryParseExact(keyword, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                        {
                            cm.Parameters.AddWithValue("@keyword", "%" + result.ToString("yyyy-MM-dd") + "%");
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        }
                    }
                    if (!string.IsNullOrEmpty(nhanvienTimkiem))
                    {
                        cm.Parameters.AddWithValue("@manhanvienlapphieu", $"{nhanvienTimkiem}");
                    }
                    if (!string.IsNullOrEmpty(docgiaTimkiem))
                    {
                        cm.Parameters.AddWithValue("@madocgia", $"{docgiaTimkiem}");
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

        public static DataRow getPhieumuon(string maphieumuon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM PhieuMuon WHERE maphieumuon = @maphieumuon";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable exportToExcel(string keyword = "", string nhanvienTimkiem = "", string docgiaTimkiem = "", bool sachdangmuonTimkiem = false, bool quahanTimkiem = false)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sqlSelect = "SELECT p.maphieumuon as 'Mã phiếu mượn', " +
                                    "manhanvienlapphieu as 'Mã nhân viên lập phiếu', " +
                                    "nv_lap.tennhanvien as 'Tên nhân viên lập phiếu', " +
                                    "FORMAT(ngaylapphieu, 'dd/MM/yyyy') as 'Ngày lập phiếu', " +
                                    "p.madocgia as 'Mã độc giả', " +
                                    "tendocgia as 'Tên độc giả', " +
                                    "ctpm.masach as 'Mã sách', " +
                                    "tensach as 'Tên sách'," +
                                    "CASE WHEN tinhtrang = 0 THEN N'Đã trả' " +
                                    "WHEN tinhtrang = 1 THEN N'Đang mượn' " +
                                    "ELSE 'Không xác định' " +
                                    "END AS 'Trình trạng', " +
                                    "FORMAT(ngaytrasach, 'dd/MM/yyyy') as 'Ngày trả sách', " +
                                    "tienphat as 'Tiền phạt', " +
                                    "manhanviennhansachtra as 'Mã nhân viên nhận trả sách'," +
                                    "nv_nhan.tennhanvien as 'Tên nhân viên nhận sách trả' " +
                                    "FROM PhieuMuon p " +
                                    "INNER JOIN NhanVien nv_lap ON p.manhanvienlapphieu = nv_lap.manhanvien " +
                                    "INNER JOIN DocGia dg ON p.madocgia = dg.madocgia " +
                                    "INNER JOIN ChiTietPhieuMuon ctpm ON p.maphieumuon = ctpm.maphieumuon " +
                                    "LEFT JOIN NhanVien nv_nhan ON ctpm.manhanviennhansachtra = nv_nhan.manhanvien " +
                                    "INNER JOIN Sach s ON ctpm.masach = s.masach";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (p.maphieumuon LIKE @keyword OR tennhanvien LIKE @keyword OR tendocgia LIKE @keyword OR ngaylapphieu LIKE @keyword)";
                }
                if (nhanvienTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "p.manhanvienlapphieu = @manhanvienlapphieu";
                }
                if (docgiaTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "p.madocgia = @madocgia";
                }
                if (sachdangmuonTimkiem)
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "tinhtrang = 1";
                }
                if (quahanTimkiem)
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "tienphat <> 0";
                }
                sqlSelect += condition;

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        if (DateTime.TryParseExact(keyword, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                        {
                            cm.Parameters.AddWithValue("@keyword", "%" + result.ToString("yyyy-MM-dd") + "%");
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                        }
                    }
                    if (!string.IsNullOrEmpty(nhanvienTimkiem))
                    {
                        cm.Parameters.AddWithValue("@manhanvienlapphieu", $"{nhanvienTimkiem}");
                    }
                    if (!string.IsNullOrEmpty(docgiaTimkiem))
                    {
                        cm.Parameters.AddWithValue("@madocgia", $"{docgiaTimkiem}");
                    }

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }

            return dt;
        }

        public static bool createPhieumuon(
            string maphieumuon,
            string manhanvienlapphieu,
            DateTime ngaylapphieu,
            string madocgia
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO PhieuMuon VALUES (@maphieumuon, @manhanvienlapphieu, @ngaylapphieu,  @madocgia)";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    cm.Parameters.AddWithValue("@manhanvienlapphieu", manhanvienlapphieu);
                    cm.Parameters.AddWithValue("@ngaylapphieu", ngaylapphieu.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@madocgia", madocgia);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool updatePhieumuon(
            string maphieumuon,
            string manhanvienlapphieu,
            string madocgia
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE PhieuMuon SET " +
                    "manhanvienlapphieu = @manhanvienlapphieu, " +
                    "madocgia = @madocgia " +
                    "WHERE maphieumuon = @maphieumuon";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    cm.Parameters.AddWithValue("@manhanvienlapphieu", manhanvienlapphieu);
                    cm.Parameters.AddWithValue("@madocgia", madocgia);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool deletePhieumuon(string maphieumuon)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM PhieuMuon WHERE maphieumuon = @maphieumuon";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
