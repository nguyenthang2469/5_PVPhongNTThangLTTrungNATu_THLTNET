using QuanLyThuVien.CSDL;
using QuanLyThuVien.Taikhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class fDangnhap : Form
    {
        public static DataRow user = null;
        public fDangnhap()
        {
            InitializeComponent();
        }

        private void ckbShowhidepassword_CheckedChanged(object sender, EventArgs e)
        {
            tbMatkhau.UseSystemPasswordChar = !ckbShowhidepassword.Checked;
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = tbTendangnhap.Text.Trim();
            string matkhau = tbMatkhau.Text.Trim();
            if(tendangnhap != "" && matkhau != "")
            {
                DataRow dr = Account.getAccount(tendangnhap);
                if (dr == null)
                {
                    tbTendangnhap.SelectAll();
                    tbTendangnhap.Focus();
                    MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    if (dr["matkhau"].ToString() == matkhau)
                    {
                        user = dr;
                        fQuanly f = new fQuanly();
                        this.Hide();
                        f.ShowDialog();
                        if(user == null)
                        {
                            this.Show();
                        }
                    } else
                    {
                        tbMatkhau.Focus();
                        tbMatkhau.SelectAll();
                        MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } else if(tendangnhap != "")
            {
                tbMatkhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else if(matkhau != "")
            {
                tbTendangnhap.Focus();
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                tbTendangnhap.Focus();
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (user == null && MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        public string GenerateRandomString(int length = 10)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()~.?/-+";
            Random random = new Random();

            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(result);
        }

        private void lbQuenmatkhau_Click(object sender, EventArgs e)
        {
            if(tbTendangnhap.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } else
            {
                if(MessageBox.Show("Bạn muốn quên mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string tendangnhap = tbTendangnhap.Text.Trim();
                    DataRow dr = Account.getAccount(tendangnhap);
                    if (dr == null)
                    {
                        tbTendangnhap.SelectAll();
                        tbTendangnhap.Focus();
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        if(Account.UpdateAccount(tendangnhap, GenerateRandomString()) == System.Net.HttpStatusCode.OK)
                        {
                            dr = Account.getAccount(tendangnhap);
                            string matkhau = dr["matkhau"].ToString();
                            tbMatkhau.Text = matkhau;
                            btnDangnhap.Focus();
                            Clipboard.SetText(matkhau);
                            MessageBox.Show("Mật khẩu của bạn đã được khôi phục thành '" + matkhau + "' (copied)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else
                        {
                            MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
