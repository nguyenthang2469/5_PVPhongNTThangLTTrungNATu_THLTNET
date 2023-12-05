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
    public partial class frmTrangchuDocgia : Form
    {
        public static Form formtrangchu;
        private bool shouldExit = false;
        private string tendangnhap = string.Empty;
        private bool isSidebarVisible = true;
        private DataRow docgia = null;

        public frmTrangchuDocgia(string tendangnhap)
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            docgia = Docgia.getDocgiaByTendangnhap(tendangnhap);
        }

        private void frmTrangchuDocgia_Load(object sender, EventArgs e)
        {
            pnContent.Width = 2000;
            guna2ShadowForm1.SetShadowForm(this);
            btnTrangchu_Click(btnTrangchu, EventArgs.Empty);
            lbTendangnhap.Text = tendangnhap;
            formtrangchu = this;
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
            if (frm.Width > 900)
            {
                this.Width = frm.Width + 205;
            }
            if (frm.Height > 600)
            {
                this.Height = frm.Height + 53;
            }
            pnContent.Controls.Add(frm);
            pnContent.Tag = frm;
            lbCurrentPage.Text = frm.Text;
            frm.Show();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            ptbCurrentPage.Image = Properties.Resources.list_book;
            addFormContent(new frmQuanlysach("docgia"));
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

        private void frmTrangchuDocgia_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSidebar_Click(object sender, EventArgs e)
        {
            if (isSidebarVisible)
            {
                guna2Panel_left.Width = 58;
                lbTendangnhap.Visible = false;
                lbXinchao.Visible = false;
                ptbBook.Visible = false;

                foreach (Control control in guna2Panel_left.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)control;
                        button.Tag = button.Text;
                        button.Text = string.Empty;
                        button.Width = 54;
                    }
                }
            }
            else
            {
                guna2Panel_left.Width = 205;
                lbTendangnhap.Visible = true;
                lbXinchao.Visible = true;
                ptbBook.Visible = true;
                foreach (Control control in guna2Panel_left.Controls)
                {
                    if (control is Guna.UI2.WinForms.Guna2Button)
                    {
                        Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)control;
                        button.Width = 201;
                        button.Text = button.Tag?.ToString();
                    }
                }
            }

            isSidebarVisible = !isSidebarVisible;
        }

        private void btnThongtincanhan_Click(object sender, EventArgs e)
        {
            frmThongtindocgia frm = new frmThongtindocgia(docgia);
            frm.ShowDialog();
        }

        private void btnMuontra_Click(object sender, EventArgs e)
        {
            addFormContent(new frmQuanlyphieumuon(docgia["madocgia"].ToString(), "docgia"));
        }
    }
}
