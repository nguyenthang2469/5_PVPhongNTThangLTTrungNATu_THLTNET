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
    public partial class fThongtindocgia : Form
    {
        private DataRow user = null;
        private DataRow docgia = null;

        public void loadInfo()
        {
            this.docgia = Docgia.getDocgia(user["tendangnhap"].ToString());
            tbMadocgia.Text = docgia["madocgia"].ToString();
            tbTendocgia.Text = docgia["tendocgia"].ToString();
            dtpNgaysinh.Value = (DateTime)docgia["ngaysinh"];
            cbGioitinh.SelectedIndex = Convert.ToInt32(docgia["gioitinh"]);
            tbDiachi.Text = docgia["diachi"].ToString();
            tbLophoc.Text = docgia["lophoc"].ToString();
            dtpNgaytaothe.Value = (DateTime)docgia["ngaytaothe"];
            tbManhanvientaothe.Text = docgia["manhanvientaothe"].ToString();
            tbTendangnhap.Text = docgia["tendangnhap"].ToString();
        }
        public fThongtindocgia()
        {
            //user = fDangnhap.user;
            InitializeComponent();
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaytaothe.CustomFormat = "dd/MM/yyyy";
            loadInfo();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            tbTendocgia.Enabled = true;
            dtpNgaysinh.Enabled = true;
            cbGioitinh.Enabled = true;
            tbDiachi.Enabled = true;
            tbLophoc.Enabled = true;
            dtpNgaytaothe.Enabled = true;
            tbTendocgia.Focus();
            (sender as Button).Visible = false;
            btnLuu.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tendocgia = tbTendocgia.Text.Trim();
            DateTime ngaysinh = dtpNgaysinh.Value;
            int gioitinh = cbGioitinh.SelectedIndex;
            string diachi = tbDiachi.Text.Trim();
            string lophoc = tbLophoc.Text.Trim();
            DateTime ngaysinhtaothe = dtpNgaytaothe.Value;
            string message = "";

            if (tendocgia == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "tên độc giả";
            }
            if (diachi == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "địa chỉ";
            }
            if (lophoc == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "lớp học";
            }
            if (message.Length > 0)
            {
                MessageBox.Show("Bạn chưa nhập " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                //if (Docgia.UpdateDocgia(docgia["madocgia"].ToString(), tendocgia, ngaysinh, gioitinh, diachi, lophoc, ngaysinhtaothe) == System.Net.HttpStatusCode.OK)
                //{
                //    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    loadInfo();
                //    tbTendocgia.Enabled = false;
                //    dtpNgaysinh.Enabled = false;
                //    cbGioitinh.Enabled = false;
                //    tbDiachi.Enabled = false;
                //    tbLophoc.Enabled = false;
                //    dtpNgaytaothe.Enabled = false;
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
