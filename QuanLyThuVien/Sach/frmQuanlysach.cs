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
    public partial class frmQuanlysach : Form
    {
        private string loainguoidung = "";
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private string tacgiaTimkiem = "";
        private string nhaxuatbanTimkiem = "";
        private DataGridViewRow selectedRow = null;
        SortedDictionary<string, string> tacgiaDictionary = new SortedDictionary<string, string>();
        SortedDictionary<string, string> nhaxbDictionary = new SortedDictionary<string, string>();

        public frmQuanlysach(string loainguoidung = "quanly")
        {
            InitializeComponent();
            this.loainguoidung = loainguoidung;
        }

        private void frmQuanlysach_Load(object sender, EventArgs e)
        {
            cbSohang.SelectedIndex = 2;
            dtpNgayxuatban.CustomFormat = "dd/MM/yyyy";
            loadComboboxTacgia();
            loadComboboxNhaxb();
            if (loainguoidung != "quanly")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnXuatexcel.Visible = false;
            }
        }

        private void loadComboboxTacgia()
        {
            try
            {
                tacgiaDictionary.Clear();
                System.Data.DataTable dt = TacGia.getAllTacgia();
                cbTacgia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row[0].ToString()}-{row[1].ToString()}";

                    tacgiaDictionary.Add(row[0].ToString().ToUpper(), displayText);
                }
                if(tacgiaDictionary.Count > 0)
                {
                    cbTacgia.DataSource = new BindingSource(tacgiaDictionary, null);
                    cbTacgia.DisplayMember = "Value";
                    cbTacgia.ValueMember = "Key";

                    tacgiaDictionary.Add("-1", "Tác giả");
                    cbTimkiemtacgia.DataSource = new BindingSource(tacgiaDictionary, null);
                    cbTimkiemtacgia.DisplayMember = "Value";
                    cbTimkiemtacgia.ValueMember = "Key";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lấy dữ liệu thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadComboboxNhaxb()
        {
            try
            {
                nhaxbDictionary.Clear();
                System.Data.DataTable dt = NhaXB.getAllNhaXB();
                cbNhaxuatban.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row[0].ToString()}-{row[1].ToString()}";

                    nhaxbDictionary.Add(row[0].ToString().ToUpper(), displayText);
                }
                if(nhaxbDictionary.Count > 0)
                {
                    cbNhaxuatban.DataSource = new BindingSource(nhaxbDictionary, null);
                    cbNhaxuatban.DisplayMember = "Value";
                    cbNhaxuatban.ValueMember = "Key";

                    nhaxbDictionary.Add("-1", "Nhà xuất bản");
                    cbTimkiemnhaxb.DataSource = new BindingSource(nhaxbDictionary, null);
                    cbTimkiemnhaxb.DisplayMember = "Value";
                    cbTimkiemnhaxb.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu thất bại" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadData()
        {
            Tuple<int, System.Data.DataTable> result = Sach.searchSach(pageSize, pageIndex, keySearch, tacgiaTimkiem, nhaxuatbanTimkiem);
            System.Data.DataTable dt = result.Item2;
            lbSonguoidung.Text = "Tổng số sách: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            dt.Columns.Add("stt", typeof(int));
            dt.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvSach.DataSource = dt;
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
            dgvSach.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.NONE)
            {
                SwitchMode(CHUCNANG.UPDATE);
            }
            else
            {
                string masach = tbMasach.Text.Trim();
                string tensach = tbTensach.Text.Trim();
                string loaisach = tbLoaisach.Text.Trim();
                string tacgia = (string)cbTacgia.SelectedValue;
                string nhaxb = (string)cbNhaxuatban.SelectedValue;
                DateTime ngayxuatban = dtpNgayxuatban.Value;
                int soluong = (int)nudSoluong.Value;
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Sach.getSach(masach) != null)
                    {
                        MessageBox.Show("Mã sách đã tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Sach.createSach(masach, tensach, loaisach, tacgia, nhaxb, ngayxuatban, soluong))
                    {
                        dgvSach.Enabled = true;
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        btnThem.Focus();
                        MessageBox.Show("Thêm thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (chucnanghientai == CHUCNANG.UPDATE)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Sach.updateSach(masach, tensach, loaisach, tacgia, nhaxb, ngayxuatban, soluong))
                    {
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        MessageBox.Show("Cập nhật thành công", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(chucnanghientai == CHUCNANG.NONE)
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa sách này?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string masach = dgvSach.CurrentRow.Cells[1].Value.ToString();
                if (Sach.deleteSach(masach))
                {
                    MessageBox.Show("Xóa sách thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi khi xóa, vui lòng thử lại sau", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                SwitchMode(CHUCNANG.NONE);
            }
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvSach.SelectionChanged -= dgvSach_SelectionChanged;
                dgvSach.ClearSelection();
                selectedRow.Selected = true;
                dgvSach.SelectionChanged += dgvSach_SelectionChanged;
                return;
            } else
            {
                this.selectedRow = null;
                if (dgvSach.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvSach.CurrentRow;
                    tbMasach.Text = (string)selectedRow.Cells["colMasach"].Value;
                    tbTensach.Text = (string)selectedRow.Cells["colTensach"].Value;
                    tbLoaisach.Text = (string)selectedRow.Cells["colLoaisach"].Value;
                    cbTacgia.SelectedValue = selectedRow.Cells["colMatacgia"].Value;
                    cbNhaxuatban.SelectedValue = selectedRow.Cells["colManhaxuatban"].Value;
                    dtpNgayxuatban.Value = (DateTime)selectedRow.Cells["colNgayxuatban"].Value;
                    decimal soluong;
                    if (decimal.TryParse(selectedRow.Cells["colSoluong"].Value.ToString(), out soluong))
                    {
                        nudSoluong.Value = soluong;
                    }
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                } else if(chucnanghientai == CHUCNANG.NONE)
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void dgvSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bool isColumnNgayxb = dgvSach.Columns["colNgayxuatban"] != null
                && e.ColumnIndex == dgvSach.Columns["colNgayxuatban"].Index
                && e.Value != null;
            if (isColumnNgayxb)
            {
                DateTime ngaySinh = (DateTime)e.Value;
                e.Value = ngaySinh.ToString("dd/MM/yyyy");
            }
        }

        private void clearInput()
        {
            tbMasach.Text = "";
            tbTensach.Text = "";
            tbLoaisach.Text = "";
            cbTacgia.SelectedIndex = -1;
            cbNhaxuatban.SelectedIndex = -1;
            nudSoluong.Value = 0;
        }

        private bool checkInput()
        {
            string masach = tbMasach.Text.Trim();
            string tensach = tbTensach.Text.Trim();
            string loaisach = tbLoaisach.Text.Trim();
            string tacgia = (string)cbTacgia.SelectedValue;
            string nhaxb = (string)cbNhaxuatban.SelectedValue;
            string soluong = nudSoluong.Value.ToString();
            if (masach.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã sách", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMasach.Focus();
                return false;
            }
            if (tensach.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên sách", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTensach.Focus();
                return false;
            }
            if (loaisach.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập loại sách", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLoaisach.Focus();
                return false;
            }
            if (tacgia == null || tacgia.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn tác giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTacgia.Focus();
                return false;
            }
            if (nhaxb == null || nhaxb.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbNhaxuatban.Focus();
                return false;
            }
            if(soluong.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudSoluong.Focus();
                return false;
            }
            if (int.Parse(soluong) <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nudSoluong.Focus();
                return false;
            }
            return true;
        }

        private void setStateInput(bool enabled)
        {
            tbMasach.Enabled = enabled;
            tbTensach.Enabled = enabled;
            tbLoaisach.Enabled = enabled;
            cbTacgia.Enabled = enabled;
            cbNhaxuatban.Enabled = enabled;
            dtpNgayxuatban.Enabled = enabled;
            nudSoluong.Enabled = enabled;
            tbTimkiem.Enabled = !enabled;
            cbTimkiemtacgia.Enabled = !enabled;
            cbTimkiemnhaxb.Enabled = !enabled;
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
                        tbMasach.Focus();
                        setStateButton(false);
                        clearInput();
                        dgvSach.ClearSelection();
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        tbMasach.Enabled = false;
                        tbTensach.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvSach.Enabled = true;
                        dgvSach_SelectionChanged(dgvSach, EventArgs.Empty);
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
                System.Data.DataTable dataTable = Sach.exportToExcel(keySearch);
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
                worksheet.Name = "Danh sách sách";

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

        private void cbTimkiemtacgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimkiemtacgia.SelectedIndex != 0)
            {
                this.tacgiaTimkiem = (string)cbTimkiemtacgia.SelectedValue;
            }
            else this.tacgiaTimkiem = "";
            loadData();
        }

        private void cbTimkiemnhaxb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimkiemnhaxb.SelectedIndex != 0)
            {
                this.nhaxuatbanTimkiem = (string)cbTimkiemnhaxb.SelectedValue;
            }
            else this.nhaxuatbanTimkiem = "";
            loadData();
        }
    }
}
