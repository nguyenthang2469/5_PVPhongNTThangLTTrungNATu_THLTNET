﻿using QuanLyThuVien.Taikhoan;
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
    public partial class fQuanly : Form
    {
        private bool shouldExit = false;
        private bool logout = false;
        DataRow user = null;
        public fQuanly()
        {
            this.user = fDangnhap.user;
            InitializeComponent();
        }

        private void fQuanly_Load(object sender, EventArgs e)
        {
            if (user["loainguoidung"].ToString().Equals("quanly"))
            {
                thôngTinCáNhânToolStripMenuItem.Visible = false;
            }
            if (user["loainguoidung"].ToString().Equals("docgia"))
            {
                quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
            }
            ucThongtinnhom uc = new ucThongtinnhom();
            addUsercontrol(uc);
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(user["loainguoidung"].ToString().Equals("thuthu"))
            {
                fThongtinnhanvien f = new fThongtinnhanvien();
                f.ShowDialog();
            } else
            {
                fThongtindocgia f = new fThongtindocgia();
                f.ShowDialog();
            }
        }

        private void fQuanly_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldExit && MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            } else
            {
                shouldExit = true;
                if(!logout)
                {
                    Application.Exit();
                }
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDangnhap.user = null;
            shouldExit = true;
            logout = true;
            this.Close();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDoimatkhau f = new fDoimatkhau();
            f.ShowDialog();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDanhsachtaikhoan f = new fDanhsachtaikhoan(user);
            f.ShowDialog();
        }

        private void addUsercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnMain.Controls.Clear();
            pnMain.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void thôngTinNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucThongtinnhom uc = new ucThongtinnhom();
            addUsercontrol(uc);
        }
    }
}
