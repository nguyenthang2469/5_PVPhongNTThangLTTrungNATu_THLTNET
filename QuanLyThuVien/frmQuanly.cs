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
                    addFormContent(new frmQuanlytaikhoan());
                    break;
                case 1:
                    break;
            }
        }

        private void addFormContent(Object _frm)
        {
            if (tabNguoidung.Controls.Count > 0) tabNguoidung.Controls.Clear();
            Form frm = _frm as Form;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tabNguoidung.Controls.Add(frm);
            tabNguoidung.Tag = frm;
            frm.Show();
        }

        private void frmQuanly_Load(object sender, EventArgs e)
        {
            tabControl1_SelectedIndexChanged(tabControl1, EventArgs.Empty);
        }
    }
}
