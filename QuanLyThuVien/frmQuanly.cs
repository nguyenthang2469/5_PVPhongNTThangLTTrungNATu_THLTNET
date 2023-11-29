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
    public partial class frmQuanly : Form
    {
        public frmQuanly()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = tabControl1.SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    addFormContent(new frmQuanlytaikhoan(), tabNguoidung);
                    break;
                case 1:
                    addFormContent(new frmQuanlynhanvien(), tabThuthu);
                    break;
                case 2:
                    addFormContent(new frmQuanlydocgia(), tabDocgia);
                    break;
                case 3:
                    addFormContent(new frmQuanlysach(), tabSach);
                    break;
                case 4:
                    addFormContent(new frmQuanlytacgia(), tabTacgia);
                    break;
                case 5:
                    addFormContent(new frmQuanlynhaxuatban(), tabNhaxuatban);
                    break;
            }
        }

        private void addFormContent(Object _frm, TabPage tabPage)
        {
            if (tabPage.Controls.Count > 0) tabPage.Controls.Clear();
            Form frm = _frm as Form;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (frm.Width > 900)
            {
                frmTrangchuAdmin.formtrangchu.Width = frm.Width + 205;
            }
            if (frm.Height > 600)
            {
                frmTrangchuAdmin.formtrangchu.Height = frm.Height + 53;
            }
            frm.Dock = DockStyle.Fill;
            tabPage.Controls.Add(frm);
            tabPage.Tag = frm;
            frm.Show();
        }

        private void frmQuanly_Load(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(tabControl1, EventArgs.Empty);
        }
    }
}
