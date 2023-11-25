using QuanLyThuVien.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Taikhoan
{
    public partial class fThongtinnhanvien : Form
    {
        private DataRow user = null;
        private DataRow nhanvien = null;

        public void loadInfo()
        {
            this.nhanvien = Nhanvien.getNhanvien(user["tendangnhap"].ToString());
            tbManhanvien.Text = nhanvien["manhanvien"].ToString();
            tbTennhanvien.Text = nhanvien["tennhanvien"].ToString();
            dtpNgaysinh.Value = (DateTime)nhanvien["ngaysinh"];
            cbGioitinh.SelectedIndex = Convert.ToInt32(nhanvien["gioitinh"]);
            tbSodienthoai.Text = nhanvien["sodienthoai"].ToString();
            tbTendangnhap.Text = nhanvien["tendangnhap"].ToString();
        }

        public fThongtinnhanvien()
        {
            //user = fDangnhap.user;
            InitializeComponent();
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";
            loadInfo();
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            tbTennhanvien.Enabled = true;
            dtpNgaysinh.Enabled = true;
            cbGioitinh.Enabled = true;
            tbSodienthoai.Enabled = true;
            tbTennhanvien.Focus();
            (sender as Button).Visible = false;
            btnLuu.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tennhanvien = tbTennhanvien.Text.Trim();
            DateTime ngaysinh = dtpNgaysinh.Value;
            int gioitinh = cbGioitinh.SelectedIndex;
            string sodienthoai = tbSodienthoai.Text.Trim();
            string message = "";

            if (tennhanvien == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "tên nhân viên";
            }
            if (sodienthoai == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "số điện thoại";
            }
            if (message.Length > 0)
            {
                MessageBox.Show("Bạn chưa nhập " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                //if (Nhanvien.UpdateNhanvien(nhanvien["manhanvien"].ToString(), tennhanvien, ngaysinh, gioitinh, sodienthoai) == System.Net.HttpStatusCode.OK)
                //{
                //    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    loadInfo();
                //    tbTennhanvien.Enabled = false;
                //    dtpNgaysinh.Enabled = false;
                //    cbGioitinh.Enabled = false;
                //    tbSodienthoai.Enabled = false;
                //    (sender as Button).Visible = false;
                //    btnCapnhat.Visible = true;
                //}
                //else
                //{
                //    MessageBox.Show("Xảy ra lỗi trong qua trình cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
    }
}
