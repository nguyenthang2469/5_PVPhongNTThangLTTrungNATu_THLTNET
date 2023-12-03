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
    public partial class frmDoimatkhau : Form
    {

        private string tendangnhap = string.Empty;
        private DataRow user = null;

        public frmDoimatkhau(string tendangnhap)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
        }

        private void frmDoimatkhau_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            user = Account.getAccount(tendangnhap);
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
            string matkhaucu = tbMatkhaucu.Text.Trim();
            string matkhaumoi = tbMatkhaumoi.Text.Trim();
            string matkhaunhaplai = tbNhaplaimatkhau.Text.Trim();
            if (matkhaucu.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMatkhaucu.Focus();
                return false;
            }
            if (matkhaumoi.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMatkhaumoi.Focus();
                return false;
            }
            if (matkhaunhaplai.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập ô nhập lại mật khẩu", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbNhaplaimatkhau.Focus();
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matkhaucu = tbMatkhaucu.Text.Trim();
            string matkhaumoi = tbMatkhaumoi.Text.Trim();
            string matkhaunhaplai = tbNhaplaimatkhau.Text.Trim();
            if (checkInput())
            {
                if (matkhaucu == user["matkhau"].ToString())
                {
                    if (matkhaucu != matkhaumoi)
                    {
                        if (matkhaumoi == matkhaunhaplai)
                        {
                            if (Account.UpdateAccount(user["tendangnhap"].ToString(), matkhaumoi))
                            {
                                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nhập lại mật khẩu không trùng khớp với mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbNhaplaimatkhau.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbMatkhaumoi.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbMatkhaucu.Focus();
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
