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
    public partial class frmLogin : Form
    {

        private bool isPasswordVisible = false;
        public static bool logout = true;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(logout && MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            // Chuyển đổi giữa hiển thị và ẩn mật khẩu
            isPasswordVisible = !isPasswordVisible;

            // Thiết lập kiểu cho TextBox
            tbMatkhau.UseSystemPasswordChar = !isPasswordVisible;

            // Thiết lập biểu tượng tương ứng
            if (isPasswordVisible)
            {
                ptbEye.Image = Properties.Resources.eye;
            }
            else
            {
                ptbEye.Image = Properties.Resources.close_eye;
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string tendangnhap = tbTendangnhap.Text.Trim();
            string matkhau = tbMatkhau.Text.Trim();
            if (tendangnhap != "" && matkhau != "")
            {
                DataRow dr = Account.getAccount(tendangnhap);
                if (dr == null)
                {
                    tbTendangnhap.SelectAll();
                    tbTendangnhap.Focus();
                    MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (dr["matkhau"].ToString().Equals(matkhau))
                    {
                        if (dr["loainguoidung"].ToString().Equals("docgia") && Docgia.getDocgia(dr["tendangnhap"].ToString()) == null)
                        {
                            MessageBox.Show("Tài khoản của bạn chưa thể sử dụng do chưa lập thẻ độc giả, vui lòng liên hệ với thủ thư để cấp thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (dr["loainguoidung"].ToString().Equals("thuthu") && Nhanvien.getNhanvien(dr["tendangnhap"].ToString()) == null)
                        {
                            MessageBox.Show("Tài khoản của bạn chưa được kích hoạt, vui lòng liên hệ quản lý để đăng ký thông tin nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form frm = null;
                        if(dr["loainguoidung"].ToString().Equals("quanly"))
                        {
                            frm = new frmTrangchuAdmin(dr["tendangnhap"].ToString());
                        } else if(dr["loainguoidung"].ToString().Equals("thuthu"))
                        {
                            frm = new frmTrangchuAdmin();
                        } else
                        {
                            frm = new frmTrangchuAdmin();
                        }
                        this.Hide();
                        logout = false;
                        frm.ShowDialog();
                        if (logout)
                        {
                            this.Show();
                        }
                    }
                    else
                    {
                        tbMatkhau.Focus();
                        tbMatkhau.SelectAll();
                        MessageBox.Show("Mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (tendangnhap != "")
            {
                tbMatkhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (matkhau != "")
            {
                tbTendangnhap.Focus();
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tbTendangnhap.Focus();
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tbValidate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                // Nếu không phải số hoặc chữ cái, thì không cho phép nhập.
                e.Handled = true;
            }
        }

        private void tbKeyEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDangnhap.PerformClick();
            }
        }

        private void lbQuenmatkhau_Click(object sender, EventArgs e)
        {
            if (tbTendangnhap.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (MessageBox.Show("Bạn muốn quên mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string tendangnhap = tbTendangnhap.Text.Trim();
                    DataRow dr = Account.getAccount(tendangnhap);
                    if (dr == null)
                    {
                        tbTendangnhap.SelectAll();
                        tbTendangnhap.Focus();
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (Account.UpdateAccount(tendangnhap, GenerateRandomString()))
                        {
                            dr = Account.getAccount(tendangnhap);
                            string matkhau = dr["matkhau"].ToString();
                            tbMatkhau.Text = matkhau;
                            btnDangnhap.Focus();
                            Clipboard.SetText(matkhau);
                            MessageBox.Show("Mật khẩu của bạn đã được khôi phục thành '" + matkhau + "' (copied)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
