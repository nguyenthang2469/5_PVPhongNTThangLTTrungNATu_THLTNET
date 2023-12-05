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
    class Chitietphieumuon : DB
    {
        public static DataTable getAllChitietphieumuon()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM ChiTietPhieuMuon";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchChitietphieumuon(int pageSize, int pageIndex, string keyword = "", string maphieu = "", string tinhTrangTimkiem = "", int? tienphatTimkiem = null)
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;

                string sqlCount = "SELECT COUNT(*) FROM ChiTietPhieuMuon ctpm " +
                                    "LEFT JOIN NhanVien nv ON nv.manhanvien = ctpm.manhanviennhansachtra " +
                                    "INNER JOIN Sach s ON s.masach = ctpm.masach";
                string sqlSelect = "SELECT ctpm.*, ISNULL(tennhanvien, '') as tennhanvien, tensach FROM ChiTietPhieuMuon ctpm " +
                                    "LEFT JOIN NhanVien nv ON nv.manhanvien = ctpm.manhanviennhansachtra " +
                                    "INNER JOIN Sach s ON s.masach = ctpm.masach";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (maphieumuon LIKE @keyword OR tensach LIKE @keyword)";
                }
                if (maphieu != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "maphieumuon = @maphieumuon";
                }
                if (tinhTrangTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "tinhtrang = @tinhtrang";
                }
                if (tienphatTimkiem != null)
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    if (tienphatTimkiem == 0)
                    {
                        condition += "tienphat = 0";
                    } else
                    {
                        condition += "tienphat <> 0";
                    }
                }
                sqlCount += condition;
                sqlSelect += condition;
                
                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(maphieu))
                    {
                        countCmd.Parameters.AddWithValue("@maphieumuon", $"{maphieu}");
                    }
                    if (!string.IsNullOrEmpty(tinhTrangTimkiem))
                    {
                        countCmd.Parameters.AddWithValue("@tinhtrang", $"{tinhTrangTimkiem}");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sqlSelect += " ORDER BY maphieumuon OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(maphieu))
                    {
                        cm.Parameters.AddWithValue("@maphieumuon", $"{maphieu}");
                    }
                    if (!string.IsNullOrEmpty(tinhTrangTimkiem))
                    {
                        cm.Parameters.AddWithValue("@tinhtrang", $"{tinhTrangTimkiem}");
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

        public static int countChitietphieumuonByDocgia(string keyword = "", string madocgia = "", string tinhTrangTimkiem = "", int? tienphatTimkiem = null)
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();

                string sqlCount = "SELECT COUNT(*) FROM ChiTietPhieuMuon ctpm " +
                                    "LEFT JOIN NhanVien nv ON nv.manhanvien = ctpm.manhanviennhansachtra " +
                                    "INNER JOIN Sach s ON s.masach = ctpm.masach " +
                                    "INNER JOIN PhieuMuon p ON p.maphieumuon = ctpm.maphieumuon";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (maphieumuon LIKE @keyword)";
                }
                if (madocgia != "")
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
                if (tinhTrangTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "tinhtrang = @tinhtrang";
                }
                if (tienphatTimkiem != null)
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    if (tienphatTimkiem == 0)
                    {
                        condition += "tienphat = 0";
                    }
                    else
                    {
                        condition += "tienphat <> 0";
                    }
                }
                sqlCount += condition;
                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(madocgia))
                    {
                        countCmd.Parameters.AddWithValue("@madocgia", $"{madocgia}");
                    }
                    if (!string.IsNullOrEmpty(tinhTrangTimkiem))
                    {
                        countCmd.Parameters.AddWithValue("@tinhtrang", $"{tinhTrangTimkiem}");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }
            }

            return totalAccount;
        }

        public static DataRow getChitietphieumuon(string maphieumuon, string masach)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM ChiTietPhieuMuon WHERE maphieumuon = @maphieumuon AND masach = @masach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    cm.Parameters.AddWithValue("@masach", masach);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable exportToExcel(string maphieu, string keyword = "", string tinhTrangTimkiem = "", int? tienphatTimkiem = null)
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
                                    "INNER JOIN Sach s ON ctpm.masach = s.masach " +
                                    "WHERE p.maphieumuon = @maphieumuon";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE (maphieumuon LIKE @keyword OR tensach LIKE @keyword)";
                }
                if (tinhTrangTimkiem != "")
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    condition += "tinhtrang = @tinhtrang";
                }
                if (tienphatTimkiem != null)
                {
                    if (condition.Length == 0)
                    {
                        condition += " WHERE ";
                    }
                    else
                    {
                        condition += " AND ";
                    }
                    if (tienphatTimkiem == 0)
                    {
                        condition += "tienphat = 0";
                    }
                    else
                    {
                        condition += "tienphat <> 0";
                    }
                }
                sqlSelect += condition;

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieu);
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(tinhTrangTimkiem))
                    {
                        cm.Parameters.AddWithValue("@tinhtrang", $"{tinhTrangTimkiem}");
                    }

                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }

            return dt;
        }

        public static bool createChitietphieumuon(
            string maphieumuon,
            string masach
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO ChiTietPhieuMuon (maphieumuon, masach) VALUES (@maphieumuon, @masach)";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    cm.Parameters.AddWithValue("@masach", masach);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool updateChitietphieumuon(
            string maphieumuon,
            string masach,
            string tinhtrang,
            DateTime ngaytrasach,
            string manhanviennhansachtra,
            int? tienphat = null
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string conditionTienphat = "";
                if(tienphat != null)
                {
                    conditionTienphat = ", tienphat = @tienphat";
                }
                string sql = $"UPDATE ChiTietPhieuMuon SET " +
                    "tinhtrang = @tinhtrang, " +
                    "ngaytrasach = @ngaytrasach, " +
                    "manhanviennhansachtra = @manhanviennhansachtra" + conditionTienphat +
                    " WHERE maphieumuon = @maphieumuon AND masach = @masach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    cm.Parameters.AddWithValue("@masach", masach);
                    cm.Parameters.AddWithValue("@ngaytrasach", ngaytrasach.ToString("yyyy-MM-dd"));
                    cm.Parameters.AddWithValue("@manhanviennhansachtra", manhanviennhansachtra);
                    cm.Parameters.AddWithValue("@tinhtrang", tinhtrang);
                    if (tienphat != null)
                    {
                        cm.Parameters.AddWithValue("@tienphat", tienphat);
                    }

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool deleteChitietphieumuon(string maphieumuon, string masach)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM ChiTietPhieuMuon WHERE maphieumuon = @maphieumuon AND masach = @masach";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    cm.Parameters.AddWithValue("@masach", masach);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
