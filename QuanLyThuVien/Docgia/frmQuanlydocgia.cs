using Microsoft.Office.Interop.Excel;
using QuanLyThuVien.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Taikhoan
{
    public partial class frmQuanlydocgia : Form
    {
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private DataGridViewRow selectedRow = null;
        private List<string> usernames = new List<string>();

        public frmQuanlydocgia()
        {
            InitializeComponent();
        }

        private void frmQuanlytdocgia_Load(object sender, EventArgs e)
        {
            cbSohang.SelectedIndex = 2;
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaytaothe.CustomFormat = "dd/MM/yyyy";
            loadComboboxTendangnhap();
            loadComboboxManhanvien();
        }

        private void loadComboboxTendangnhap()
        {
            try
            {
                System.Data.DataTable dt = DB.getData("SELECT tendangnhap FROM NguoiDung " +
                    "WHERE tendangnhap NOT IN(SELECT tendangnhap FROM DocGia where tendangnhap IS NOT NULL) " +
                    "AND NOT tendangnhap = 'admin' AND loainguoidung = 'docgia'"
                );
                cbTendangnhap.Items.Clear();
                usernames.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    usernames.Add(row["tendangnhap"].ToString());
                }
                cbTendangnhap.Items.AddRange(usernames.ToArray());
            }
            catch (Exception)
            {
                MessageBox.Show("Lấy dữ liệu thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadComboboxManhanvien()
        {
            try
            {
                Dictionary<string, string> nhanvienDictionary = new Dictionary<string, string>();
                System.Data.DataTable dt = Nhanvien.getAllNhanvien();
                cbManhanvien.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row["manhanvien"].ToString()}-{row["tennhanvien"].ToString()}";

                    nhanvienDictionary.Add(row["manhanvien"].ToString(), displayText);
                }
                if(nhanvienDictionary.Count > 0)
                {
                    cbManhanvien.DataSource = new BindingSource(nhanvienDictionary, null);
                    cbManhanvien.DisplayMember = "Value";
                    cbManhanvien.ValueMember = "Key";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lấy dữ liệu thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadData()
        {
            Tuple<int, System.Data.DataTable> result = Docgia.searchDocgia(pageSize, pageIndex, keySearch);
            System.Data.DataTable dt = result.Item2;
            lbSonguoidung.Text = "Tổng số độc giả: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            dt.Columns.Add("stt", typeof(int));
            dt.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvDocgia.DataSource = dt;
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
        
        private void cbSohang_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageSize = int.Parse((sender as ComboBox).SelectedItem.ToString());
            pageIndex = 1;
            loadData();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            SwitchMode(CHUCNANG.ADD);
            dgvDocgia.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.NONE)
            {
                SwitchMode(CHUCNANG.UPDATE);
            }
            else
            {
                string madocgia = tbMadocgia.Text.Trim();
                string tendocgia = tbTendocgia.Text.Trim();
                DateTime ngaysinh = dtpNgaysinh.Value;
                string gioitinh = (string)cbGioitinh.SelectedItem;
                string diachi = tbDiachi.Text.Trim();
                string lophoc = tbLophoc.Text.Trim();
                DateTime ngaytaothe = dtpNgaytaothe.Value;
                string manhanvientaothe = (string)cbManhanvien.SelectedValue;
                string tendangnhap = (string)cbTendangnhap.SelectedItem;
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Docgia.getDocgia(madocgia) != null)
                    {
                        MessageBox.Show("Mã độc giả đã tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Docgia.createDocgia(madocgia, tendocgia, ngaysinh, gioitinh, diachi, lophoc, ngaytaothe, manhanvientaothe, tendangnhap))
                    {
                        dgvDocgia.Enabled = true;
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        btnThem.Focus();
                        loadComboboxTendangnhap();
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
                    if (Docgia.updateDocgia(madocgia, tendocgia, ngaysinh, gioitinh, diachi, lophoc, ngaytaothe, manhanvientaothe))
                    {
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        loadComboboxTendangnhap();
                        MessageBox.Show("Cập nhật thành công", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa độc giả này?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string madocgia = dgvDocgia.CurrentRow.Cells[1].Value.ToString();
                string tendangnhap = dgvDocgia.CurrentRow.Cells[9].Value.ToString();
                if (Docgia.deleteDocgia(madocgia, tendangnhap))
                {
                    MessageBox.Show("Xóa độc giả " + madocgia + " thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvDocgia_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvDocgia.SelectionChanged -= dgvDocgia_SelectionChanged;
                dgvDocgia.ClearSelection();
                selectedRow.Selected = true;
                dgvDocgia.SelectionChanged += dgvDocgia_SelectionChanged;
                return;
            } else
            {
                this.selectedRow = null;
                if (dgvDocgia.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvDocgia.CurrentRow;
                    setComboboxTendangnhap(selectedRow.Cells[9].Value.ToString());
                    tbMadocgia.Text = (string)selectedRow.Cells[1].Value;
                    tbTendocgia.Text = (string)selectedRow.Cells[2].Value;
                    dtpNgaysinh.Value = (DateTime)selectedRow.Cells[3].Value;
                    cbGioitinh.SelectedItem = selectedRow.Cells[4].Value;
                    tbDiachi.Text = (string)selectedRow.Cells[5].Value;
                    tbLophoc.Text = (string)selectedRow.Cells[6].Value;
                    dtpNgaytaothe.Value = (DateTime)selectedRow.Cells[7].Value;
                    cbManhanvien.SelectedValue = selectedRow.Cells[8].Value;
                    cbTendangnhap.SelectedItem = selectedRow.Cells[9].Value;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    return;
                } else if(chucnanghientai == CHUCNANG.NONE)
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                cbTendangnhap.Items.Clear();
                cbTendangnhap.Items.AddRange(usernames.ToArray());
            }
        }

        private void dgvDocgia_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bool isColumnNgaysinh = dgvDocgia.Columns["colNgaySinh"] != null
                && e.ColumnIndex == dgvDocgia.Columns["colNgaySinh"].Index
                && e.Value != null;
            bool isColumnNgaytaothe = dgvDocgia.Columns["colNgaytaothe"] != null
                && e.ColumnIndex == dgvDocgia.Columns["colNgaytaothe"].Index
                && e.Value != null;
            if (isColumnNgaysinh || isColumnNgaytaothe)
            {
                DateTime ngaySinh = (DateTime)e.Value;
                e.Value = ngaySinh.ToString("dd/MM/yyyy");
            }
        }

        private void setComboboxTendangnhap(string tendangnhap)
        {
            cbTendangnhap.Items.Clear();
            cbTendangnhap.Items.AddRange(usernames.ToArray());
            if(!string.IsNullOrEmpty(tendangnhap))
            {
                cbTendangnhap.Items.Add(tendangnhap);
            }
        }

        private void clearInput()
        {
            tbMadocgia.Text = "";
            tbTendocgia.Text = "";
            cbGioitinh.SelectedIndex = -1;
            tbDiachi.Text = "";
            tbLophoc.Text = "";
            cbManhanvien.SelectedIndex = -1;
            cbTendangnhap.SelectedIndex = -1;
        }

        private bool checkInput()
        {
            string madocgia = tbMadocgia.Text.Trim();
            string tendocgia = tbTendocgia.Text.Trim();
            string gioitinh = (string)cbGioitinh.SelectedItem;
            string diachi = tbDiachi.Text.Trim();
            string lophoc = tbLophoc.Text.Trim();
            string manhanvientaothe = (string)cbManhanvien.SelectedValue;
            string tendangnhap = (string)cbTendangnhap.SelectedItem;
            if (madocgia.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã độc giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMadocgia.Focus();
                return false;
            }
            if (tendocgia.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên độc giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTendocgia.Focus();
                return false;
            }
            if (gioitinh == null || gioitinh.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGioitinh.Focus();
                return false;
            }
            if (diachi.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbDiachi.Focus();
                return false;
            }
            if (lophoc.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập lớp học", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLophoc.Focus();
                return false;
            }
            if (manhanvientaothe == null || manhanvientaothe.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên tạo thẻ", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbManhanvien.Focus();
                return false;
            }
            if (tendangnhap == null || tendangnhap.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn tên đăng nhập", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTendangnhap.Focus();
                return false;
            }
            return true;
        }

        private void setStateInput(bool enabled)
        {
            tbMadocgia.Enabled = enabled;
            tbTendocgia.Enabled = enabled;
            dtpNgaysinh.Enabled = enabled;
            cbGioitinh.Enabled = enabled;
            tbDiachi.Enabled = enabled;
            tbLophoc.Enabled = enabled;
            dtpNgaytaothe.Enabled = enabled;
            cbManhanvien.Enabled = enabled;
            cbTendangnhap.Enabled = enabled;
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
                        tbMadocgia.Focus();
                        setStateButton(false);
                        clearInput();
                        dgvDocgia.ClearSelection();
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        tbMadocgia.Enabled = false;
                        cbTendangnhap.Enabled = false;
                        tbTendocgia.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvDocgia.Enabled = true;
                        dgvDocgia_SelectionChanged(dgvDocgia, EventArgs.Empty);
                        break;
                    }
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            this.keySearch = tbTimkiem.Text.Trim();
            this.pageIndex = 1;
            this.pageSize = 10;
            loadData();
        }

        private void tbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimkiem.PerformClick();
            }
        }
        
        private void enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSua.PerformClick();
            }
        }

        private void btnXuatexcel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dataTable = Docgia.exportToExcel(keySearch);
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
                worksheet.Name = "Danh sách độc giả";

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
