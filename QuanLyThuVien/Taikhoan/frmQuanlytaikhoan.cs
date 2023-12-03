﻿using QuanLyThuVien.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLyThuVien.Taikhoan
{
    public partial class frmQuanlytaikhoan : Form
    {
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private string loainguoidungTimkiem = "";
        private string loainguoidung = "quanly";
        DataGridViewRow selectedRow = null;
        SortedDictionary<string, string> roles = new SortedDictionary<string, string>
        {
            { "thuthu", "Thủ thư" },
            { "docgia", "Độc giả" }
        };

        
        public frmQuanlytaikhoan()
        {
            InitializeComponent();
        }

        public frmQuanlytaikhoan(string loainguoidung)
        {
            InitializeComponent();
            this.loainguoidung = loainguoidung;
        }

        private void frmQuanlytaikhoan_Load(object sender, EventArgs e)
        {
            cbSohang.SelectedIndex = 2;
            cbLoainguoidung.DataSource = new BindingSource(roles, null);
            cbLoainguoidung.DisplayMember = "Value";
            cbLoainguoidung.ValueMember = "Key";
            roles.Add("-1", "Loại người dùng");
            cbTimkiemloainguoidung.DataSource = new BindingSource(roles, null);
            cbTimkiemloainguoidung.DisplayMember = "Value";
            cbTimkiemloainguoidung.ValueMember = "Key";

            if(loainguoidung == "thuthu")
            {
                cbTimkiemloainguoidung.Visible = false;
            }
        }

        private void loadData()
        {
            Tuple<int, System.Data.DataTable> result = Account.searchAccount(loainguoidung, pageSize, pageIndex, keySearch, loainguoidungTimkiem);
            System.Data.DataTable dt = result.Item2;
            lbSonguoidung.Text = "Tổng số người dùng: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            dt.Columns.Add("stt", typeof(int));
            dt.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvNguoidung.DataSource = dt;
            UpdatePager();
            showButtonPage();
            if (keySearch != "" && result.Item1 == 0) MessageBox.Show("Không tìm thấy bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showButtonPage(bool isShow = true)
        {
            if (isShow)
            {
                if (pageIndex == 1)
                {
                    btnFirst.Enabled = false;
                    btnBefore.Enabled = false;
                }
                else
                {
                    btnFirst.Enabled = true;
                    btnBefore.Enabled = true;
                }
                if (pageIndex == totalPages || totalPages == 0)
                {
                    btnLast.Enabled = false;
                    btnAfter.Enabled = false;
                }
                else
                {
                    btnLast.Enabled = true;
                    btnAfter.Enabled = true;
                }
            }
            else
            {
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                btnBefore.Enabled = false;
                btnAfter.Enabled = false;
            }
        }

        private void UpdatePager()
        {
            lbChimuc.Text = (pageIndex > totalPages ? 0 : pageIndex) + "/" + totalPages;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (pageIndex < totalPages)
            {
                pageIndex = totalPages;
                loadData();
            }
        }

        private void btnAfter_Click(object sender, EventArgs e)
        {
            if (pageIndex < totalPages)
            {
                pageIndex++;
                loadData();
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                loadData();
            }
        }

        private void btnFist_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex = 1;
                loadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.NONE)
            {
                SwitchMode(CHUCNANG.UPDATE);
            }
            else
            {
                string tendangnhap = tbTendangnhap.Text.Trim();
                string matkhau = tbMatkhau.Text.Trim();
                string loainguoidung = (string)cbLoainguoidung.SelectedValue;
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Account.getAccount(tendangnhap) != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Account.CreateAccount(tendangnhap, matkhau, loainguoidung))
                    {
                        dgvNguoidung.Enabled = true;
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        btnThem.Focus();
                        MessageBox.Show("Thêm thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (chucnanghientai == CHUCNANG.UPDATE)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Account.getAccount(tendangnhap) == null)
                    {
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Account.UpdateAccount(tendangnhap, matkhau, loainguoidung))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(chucnanghientai == CHUCNANG.NONE)
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa người dùng này?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string tendangnhap = dgvNguoidung.CurrentRow.Cells[0].Value.ToString();
                if (Account.DeleteAccount(tendangnhap))
                {
                    MessageBox.Show("Xóa tài khoản " + tendangnhap + " thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi khi xóa, vui lòng thử lại sau", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {
                SwitchMode(CHUCNANG.NONE);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SwitchMode(CHUCNANG.ADD);
            dgvNguoidung.Enabled = false;
        }

        private void dgvNguoidung_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvNguoidung.SelectionChanged -= dgvNguoidung_SelectionChanged;
                dgvNguoidung.ClearSelection();
                selectedRow.Selected = true;
                dgvNguoidung.SelectionChanged += dgvNguoidung_SelectionChanged;
                return;
            } else
            {
                this.selectedRow = null;
                if (dgvNguoidung.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvNguoidung.CurrentRow;
                    tbTendangnhap.Text = selectedRow.Cells[1].Value.ToString();
                    tbMatkhau.Text = selectedRow.Cells[2].Value.ToString();
                    cbLoainguoidung.SelectedValue = selectedRow.Cells[3].Value.ToString();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                } else if(chucnanghientai == CHUCNANG.NONE)
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void clearInput()
        {
            tbTendangnhap.Text = "";
            tbMatkhau.Text = "";
            cbLoainguoidung.SelectedIndex = -1;
        }

        private void setStateInput(bool enabled)
        {
            tbTendangnhap.Enabled = enabled;
            tbMatkhau.Enabled = enabled;
            if (loainguoidung.Equals("quanly"))
            {
                cbLoainguoidung.Enabled = enabled;
            }
            tbTimkiem.Enabled = !enabled;
            cbSohang.Enabled = !enabled;
        }

        private void setStateButton(bool state)
        {
            // State = true: hiển thị thêm sửa xóa, không thì hiển thị lưu hủy
            if(state)
            {
                btnSua.Text = "Sửa";
                btnXoa.Text = "Xóa";
                btnThem.Focus();
            } else
            {
                btnSua.Text = "Lưu";
                btnXoa.Text = "Hủy";
                btnSua.Focus();
            }
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnTimkiem.Enabled = state;
            btnXuatexcel.Enabled = state;
            btnThem.Visible = state;
            showButtonPage(state);
        }

        private void SwitchMode(int chucNang)
        {
            chucnanghientai = chucNang;
            switch (chucnanghientai)
            {
                case CHUCNANG.ADD:
                    {
                        setStateInput(true);
                        tbTendangnhap.Focus();
                        setStateButton(false);
                        clearInput();
                        dgvNguoidung.ClearSelection();
                        if (loainguoidung.Equals("quanly"))
                        {
                            cbLoainguoidung.SelectedIndex = -1;
                        }
                        else
                        {
                            cbLoainguoidung.SelectedIndex = 1;
                        }
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        tbTendangnhap.Enabled = false;
                        tbMatkhau.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvNguoidung.Enabled = true;
                        dgvNguoidung_SelectionChanged(dgvNguoidung, EventArgs.Empty);
                        break;
                    }
            }
        }

        private bool checkInput()
        {
            string tendangnhap = tbTendangnhap.Text.Trim();
            string matkhau = tbMatkhau.Text.Trim();
            string loainguoidung = (string)cbLoainguoidung.SelectedValue;
            if (tendangnhap.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTendangnhap.Focus();
                return false;
            }
            if (matkhau.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMatkhau.Focus();
                return false;
            }
            if (loainguoidung == null || loainguoidung.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn loại người dùng", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbLoainguoidung.Focus();
                return false;
            }
            return true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            this.keySearch = tbTimkiem.Text.Trim();
            this.pageIndex = 1;
            this.pageSize = 10;
            loadData();
        }

        private void cbSohang_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = int.Parse((sender as ComboBox).SelectedItem.ToString());
            pageIndex = 1;
            loadData();
        }

        private void enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSua.PerformClick();
            }
        }

        private void tbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimkiem.PerformClick();
            }
        }

        private void cbTimkiemloainguoidung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimkiemloainguoidung.SelectedIndex != 0)
            {
                this.loainguoidungTimkiem = (string)cbTimkiemloainguoidung.SelectedValue;
            }
            else this.loainguoidungTimkiem = "";
            loadData();
        }

        private void btnXuatexcel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dataTable = Account.exportToExcel(loainguoidung, keySearch, loainguoidungTimkiem);
                // Tạo một ứng dụng Excel mới
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel chưa được cài trên máy của bạn", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo một workbook mới và một worksheet mới
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];
                worksheet.Name = "Danh sách người dùng";

                // Ghi dữ liệu từ DataTable vào ExcelWorksheet
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataTable.Columns[i].ColumnName;
                }

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
                    }
                }
                worksheet.Columns.AutoFit();

                // Lưu workbook vào một file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Export to Excel";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất Excel thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Đóng workbook và ứng dụng Excel
                workbook.Close(false);
                Marshal.ReleaseComObject(workbook); // Giải phóng tài nguyên COM
                excelApp.Quit();
                Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi khi export: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
