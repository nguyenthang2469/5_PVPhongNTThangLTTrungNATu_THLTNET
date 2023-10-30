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
    public partial class fDoimatkhau : Form
    {
        private DataRow user = null;
        public fDoimatkhau()
        {
            this.user = fDangnhap.user;
            InitializeComponent();
            tbTendangnhap.Text = user["tendangnhap"].ToString();
        }

        private void btnTrolai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacnhan_Click(object sender, EventArgs e)
        {
            string matkhaucu = tbMatkhaucu.Text.Trim();
            string matkhaumoi = tbMatkhaumoi.Text.Trim();
            string xacnhanmatkhau = tbXacnhanmatkhau.Text.Trim();
            string message = "";
            if(matkhaucu == "")
            {
                if(message.Length > 0)
                {
                    message += ", ";
                }
                message += "mật khẩu cũ";
            }
            if(matkhaumoi == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "mật khẩu mới";
            }
            if(xacnhanmatkhau == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                message += "xác nhận mật khẩu";
            }
            if(message.Length > 0)
            {
                MessageBox.Show("Bạn chưa nhập " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                if (matkhaucu == user["matkhau"].ToString())
                {
                    if(matkhaucu != matkhaumoi)
                    {
                        if(matkhaumoi == xacnhanmatkhau)
                        {
                            if(Account.UpdateAccount(user["tendangnhap"].ToString(), matkhaumoi) == System.Net.HttpStatusCode.OK)
                            {
                                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        } else
                        {
                            MessageBox.Show("Xác nhận mật khẩu không trùng khớp với mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    } else
                    {
                        MessageBox.Show("Mật khẩu mới không được trùng mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ckbShowhideoldpassword_CheckedChanged(object sender, EventArgs e)
        {
            tbMatkhaucu.UseSystemPasswordChar = !ckbShowhideoldpassword.Checked;
        }

        private void ckbShowhidenewpassword_CheckedChanged(object sender, EventArgs e)
        {
            tbMatkhaumoi.UseSystemPasswordChar = !ckbShowhidenewpassword.Checked;
        }

        private void ckbShowhideconfirmpassword_CheckedChanged(object sender, EventArgs e)
        {
            tbXacnhanmatkhau.UseSystemPasswordChar = !ckbShowhideconfirmpassword.Checked;
        }
    }
}
