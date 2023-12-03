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
    public partial class frmThongtinnhanvien : Form
    {

        private DataRow nhanvien = null;
        private bool isUpdate = false;

        public frmThongtinnhanvien(DataRow nhanvien)
        {
            InitializeComponent();
            this.nhanvien = nhanvien;
        }

        private void frmThongtinnhanvien_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";
            loadInfo();
        }

        public void loadInfo()
        {
            tbManhanvien.Text = nhanvien["manhanvien"].ToString();
            tbTennhanvien.Text = nhanvien["tennhanvien"].ToString();
            dtpNgaysinh.Value = (DateTime)nhanvien["ngaysinh"];
            cbGioitinh.SelectedItem = nhanvien["gioitinh"].ToString();
            tbSodienthoai.Text = nhanvien["sodienthoai"].ToString();
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
            string manhanvien = tbManhanvien.Text.Trim();
            string tennhanvien = tbTennhanvien.Text.Trim();
            string gioitinh = (string)cbGioitinh.SelectedItem;
            string sodienthoai = tbSodienthoai.Text.Trim();
            if (manhanvien.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbManhanvien.Focus();
                return false;
            }
            if (tennhanvien.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTennhanvien.Focus();
                return false;
            }
            if (gioitinh == null || gioitinh.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGioitinh.Focus();
                return false;
            }
            if (sodienthoai.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số điên thoại", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSodienthoai.Focus();
                return false;
            }
            return true;
        }

        private void setStateInput(bool state)
        {
            tbTennhanvien.Enabled = state;
            dtpNgaysinh.Enabled = state;
            cbGioitinh.Enabled = state;
            tbSodienthoai.Enabled = state;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                string manhanvien = tbManhanvien.Text.Trim();
                string tennhanvien = tbTennhanvien.Text.Trim();
                DateTime ngaysinh = dtpNgaysinh.Value;
                string gioitinh = (string)cbGioitinh.SelectedItem;
                string sodienthoai = tbSodienthoai.Text.Trim();
                if (checkInput())
                {
                    if (Nhanvien.updateNhanvien(manhanvien, tennhanvien, ngaysinh, gioitinh, sodienthoai))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setStateInput(false);
                    }
                    else
                    {
                        MessageBox.Show("Xảy ra lỗi trong qua trình cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    isUpdate = !isUpdate;
                    nhanvien = Nhanvien.getNhanvien(manhanvien);
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
