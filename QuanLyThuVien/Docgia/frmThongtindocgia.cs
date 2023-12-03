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
    public partial class frmThongtindocgia : Form
    {

        private DataRow docgia = null;
        private bool isUpdate = false;

        public frmThongtindocgia(DataRow docgia)
        {
            InitializeComponent();
            this.docgia = docgia;
        }

        private void frmThongtindocgia_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";
            loadInfo();
        }

        public void loadInfo()
        {
            tbMadocgia.Text = docgia["madocgia"].ToString();
            tbTendocgia.Text = docgia["tendocgia"].ToString();
            dtpNgaysinh.Value = (DateTime)docgia["ngaysinh"];
            cbGioitinh.SelectedItem = docgia["gioitinh"].ToString();
            tbDiachi.Text = docgia["diachi"].ToString();
            tbLophoc.Text = docgia["lophoc"].ToString();
        }

        private void enter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLuu.PerformClick();
            }
        }

        private bool checkInput()
        {
            string madocgia = tbMadocgia.Text.Trim();
            string tendocgia = tbTendocgia.Text.Trim();
            string gioitinh = (string)cbGioitinh.SelectedItem;
            string diachi = tbDiachi.Text.Trim();
            string lophoc = tbLophoc.Text.Trim();
            if (madocgia.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã độc giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMadocgia.Focus();
                return false;
            }
            if (tendocgia.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên độc giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTendocgia.Focus();
                return false;
            }
            if (gioitinh == null || gioitinh.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGioitinh.Focus();
                return false;
            }
            if (diachi.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbDiachi.Focus();
                return false;
            }
            if (lophoc.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập lớp học", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLophoc.Focus();
                return false;
            }
            return true;
        }

        private void setStateInput(bool state)
        {
            tbTendocgia.Enabled = state;
            dtpNgaysinh.Enabled = state;
            cbGioitinh.Enabled = state;
            tbDiachi.Enabled = state;
            tbLophoc.Enabled = state;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                string madocgia = tbMadocgia.Text.Trim();
                string tendocgia = tbTendocgia.Text.Trim();
                DateTime ngaysinh = dtpNgaysinh.Value;
                string gioitinh = (string)cbGioitinh.SelectedItem;
                string diachi = tbDiachi.Text.Trim();
                string lophoc = tbLophoc.Text.Trim();
                if (checkInput())
                {
                    if (Docgia.updateDocgia(madocgia, tendocgia, ngaysinh, gioitinh, diachi, lophoc, (DateTime)docgia["ngaytaothe"], docgia["manhanvientaothe"].ToString()))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setStateInput(false);
                    }
                    else
                    {
                        MessageBox.Show("Xảy ra lỗi trong qua trình cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    isUpdate = !isUpdate;
                    docgia = Docgia.getDocgia(madocgia);
                    loadInfo();
                    btnLuu.Text = "Chỉnh sửa";
                }
            }
            else
            {
                btnLuu.Text = "Lưu";
                setStateInput(true);
                isUpdate = !isUpdate;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
