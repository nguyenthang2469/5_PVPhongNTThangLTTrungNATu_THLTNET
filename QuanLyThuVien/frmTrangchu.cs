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
    public partial class frmTrangchu : Form
    {
        private bool shouldExit = false;
        private string tendangnhap = string.Empty;

        public frmTrangchu()
        {
            InitializeComponent();
        }

        public frmTrangchu(string tendangnhap)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
        }

        private void frmTrangchu_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            btnTrangchu_Click(btnTrangchu, EventArgs.Empty);
        }

        private void btnTrangchu_Click(object sender, EventArgs e)
        {
            ptbCurrentPage.Image = Properties.Resources.information;
            addFormContent(new frmThongtinnhom());
        }

        private void addFormContent(Object _frm)
        {
            if (pnContent.Controls.Count > 0) pnContent.Controls.Clear();
            Form frm = _frm as Form;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnContent.Controls.Add(frm);
            pnContent.Tag = frm;
            lbCurrentPage.Text = frm.Text;
            frm.Show();
        }

        private void btnQuanly_Click(object sender, EventArgs e)
        {
            ptbCurrentPage.Image = Properties.Resources.list;
            addFormContent(new frmQuanly());
        }

        private void btnDoimatkhau_Click(object sender, EventArgs e)
        {
            frmDoimatkhau frm = new frmDoimatkhau(tendangnhap);
            frm.ShowDialog();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            shouldExit = true;
            frmLogin.logout = true;
            this.Close();
        }

        private void frmTrangchu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldExit && MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                shouldExit = true;
                if (!frmLogin.logout)
                {
                    Application.Exit();
                }
            }
        }
    }
}
