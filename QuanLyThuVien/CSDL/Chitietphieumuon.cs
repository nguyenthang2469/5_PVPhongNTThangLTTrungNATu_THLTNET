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
                    condition = " WHERE (maphieumuon LIKE @keyword OR tennhanvien LIKE @keyword OR tendocgia LIKE @keyword)";
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
                Console.WriteLine(sqlSelect);
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

        public static DataRow getChitietphieumuon(string maphieumuon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM ChiTietPhieuMuon WHERE maphieumuon = @maphieumuon";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@maphieumuon", maphieumuon);
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public static DataTable exportToExcel(string keyword = "", string nhanvienTimkiem = "", string docgiaTimkiem = "")
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sqlSelect = "SELECT p.*, tennhanvien, tendocgia FROM ChiTietPhieuMuon p " +
                                    "INNER JOIN NhanVien nv tg ON p.manhanvienlapphieu = nv.manhanvien " +
                                    "INNER JOIN DocGia dg ON p.madocgia = dg.madocgia";
                string condition = "";
                if (!string.IsNullOrEmpty(keyword))
                {
                    condition = " WHERE maphieumuon LIKE @keyword OR tennhanvien LIKE @keyword OR tendocgia LIKE @keyword";
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
                    condition += "p.manhanvien = @manhanvien";
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
                sqlSelect += condition;

                using (SqlCommand cm = new SqlCommand(sqlSelect, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        cm.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    if (!string.IsNullOrEmpty(nhanvienTimkiem))
                    {
                        cm.Parameters.AddWithValue("@manhanvien", $"{nhanvienTimkiem}");
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

        public static bool createChitietphieumuon(
            string maphieumuon,
            string manhanvienlapphieu,
            DateTime ngaylapphieu,
            string madocgia
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO ChiTietPhieuMuon VALUES (@maphieumuon, @manhanvienlapphieu, @ngaylapphieu,  @madocgia)";
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

        public static bool updateChitietphieumuon(
            string maphieumuon,
            string manhanvienlapphieu,
            DateTime ngaylapphieu,
            string madocgia
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE ChiTietPhieuMuon SET " +
                    "manhanvienlapphieu = @manhanvienlapphieu, " +
                    "ngaylapphieu = @ngaylapphieu, " +
                    "madocgia = @madocgia " +
                    "WHERE maphieumuon = @maphieumuon";
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

        public static bool deleteChitietphieumuon(string masach)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM ChiTietPhieuMuon WHERE masach = @masach";
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
