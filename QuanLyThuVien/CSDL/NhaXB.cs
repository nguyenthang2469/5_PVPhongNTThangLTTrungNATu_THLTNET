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
    class NhaXB : DB
    {
        public static DataTable getAllNhaXB()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhaXuatBan";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter ad = new SqlDataAdapter(cm);
                    ad.Fill(dt);
                }
            }
            return dt;
        }

        public static Tuple<int, DataTable> searchNhaXB(int pageSize, int pageIndex, string keyword = "")
        {
            DataTable dt = new DataTable();
            int totalAccount = 0;

            using (SqlConnection conn = connect())
            {
                conn.Open();
                int offset = (pageIndex - 1) * pageSize;

                string sqlCount = "SELECT COUNT(*) FROM NhaXuatBan";
                string sqlSelect = "SELECT * FROM NhaXuatBan";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sqlCount += " WHERE (manhaxuatban LIKE @keyword OR tennhaxuatban LIKE @keyword)";
                    sqlSelect += " WHERE (manhaxuatban LIKE @keyword OR tennhaxuatban LIKE @keyword)";
                }

                using (SqlCommand countCmd = new SqlCommand(sqlCount, conn))
                {
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        countCmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");
                    }
                    totalAccount = (int)countCmd.ExecuteScalar();
                }

                sqlSelect += " ORDER BY manhaxuatban OFFSET @offset ROWS FETCH NEXT @pageSize ROWS ONLY";

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

        public static DataRow getNhaXB(string manhaxuatban)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = connect())
            {
                string sql = "SELECT * FROM NhaXuatBan WHERE manhaxuatban = @manhaxuatban";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhaxuatban", manhaxuatban);
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

                string sqlSelect = "SELECT manhaxuatban as 'Mã nhà xuất bản', tennhaxuatban as 'Tên nhà xuất bản' FROM NhaXuatBan";

                if (!string.IsNullOrEmpty(keyword))
                {
                    sqlSelect += " WHERE (manhaxuatban LIKE @keyword OR tennhaxuatban LIKE @keyword)";
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

        public static bool createNhaXB(
            string manhaxuatban,
            string tennhaxuatban
        ) {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"INSERT INTO NhaXuatBan VALUES (@manhaxuatban, @tennhaxuatban)";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhaxuatban", manhaxuatban);
                    cm.Parameters.AddWithValue("@tennhaxuatban", tennhaxuatban);
                    
                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool updateNhaXB(
            string manhaxuatban,
            string tennhaxuatban
        )
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = $"UPDATE NhaXuatBan SET " +
                    "tennhaxuatban = @tennhaxuatban " +
                    "WHERE manhaxuatban = @manhaxuatban";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhaxuatban", manhaxuatban);
                    cm.Parameters.AddWithValue("@tennhaxuatban", tennhaxuatban);
                    
                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }

        public static bool deleteNhaXB(string manhaxuatban)
        {
            int rowsAffected = 0;
            using (SqlConnection conn = connect())
            {
                conn.Open();
                string sql = "DELETE FROM NhaXuatBan WHERE manhaxuatban = @manhaxuatban";
                using (SqlCommand cm = new SqlCommand(sql, conn))
                {
                    cm.Parameters.AddWithValue("@manhaxuatban", manhaxuatban);

                    rowsAffected = cm.ExecuteNonQuery();
                }
            }
            return rowsAffected > 0;
        }
    }
}
