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
    public partial class frmTrangchuAdmin : Form
    {
        public static Form formtrangchu;
        public static Guna.UI2.WinForms.Guna2HtmlLabel lbTitle;
        private bool shouldExit = false;
        private string tendangnhap = "";
        private string loainguoidung = "";
        private bool isSidebarVisible = true;
        private DataRow nhanvien = null;

        public frmTrangchuAdmin(string tendangnhap, string loainguoidung = "quanly")
        {
            InitializeComponent();
            this.tendangnhap = tendangnhap;
            this.loainguoidung = loainguoidung;
        }

        private void frmTrangchuAdmin_Load(object sender, EventArgs e)
        {
            pnContent.Width = 2000;
            guna2ShadowForm1.SetShadowForm(this);
            btnTrangchu_Click(btnTrangchu, EventArgs.Empty);
            lbTendangnhap.Text = tendangnhap;
            formtrangchu = this;
            lbTitle = lbCurrentPage;
            if(loainguoidung == "thuthu")
            {
                btnThongtincanhan.Visible = true;
                nhanvien = Nhanvien.getNhanvienByTendangnhap(tendangnhap);
            }
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

        private void btnQuanly_Click(object sender, EventArgs e)
        {
            ptbCurrentPage.Image = Properties.Resources.list;
            addFormContent(new frmQuanly(loainguoidung));
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

        private void frmTrangchuAdmin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnMuontra_Click(object sender, EventArgs e)
        {
            ptbCurrentPage.Image = Properties.Resources.borrow_return;
            if(loainguoidung == "quanly")
            {
                addFormContent(new frmQuanlyphieumuon());
            }
            else if (loainguoidung == "thuthu")
            {
                addFormContent(new frmQuanlyphieumuon(nhanvien["manhanvien"].ToString(), "thuthu"));
            }
        }

        private void btnThongtincanhan_Click(object sender, EventArgs e)
        {
            if(nhanvien != null)
            {
                frmThongtinnhanvien frm = new frmThongtinnhanvien(nhanvien);
                frm.ShowDialog();
                nhanvien = Nhanvien.getNhanvienByTendangnhap(tendangnhap);
            }
        }
    }
}
