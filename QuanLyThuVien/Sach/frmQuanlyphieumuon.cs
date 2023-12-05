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
    public partial class frmQuanlyphieumuon : Form
    {
        private string loainguoidung = "";
        private string manhanvien = "";
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private string docgiaTimkiem = "";
        private string nhanvienTimkiem = "";
        private bool sachdangmuonTimkiem = false;
        private bool quahanTimkiem = false;
        private DataGridViewRow selectedRow = null;
        SortedDictionary<string, string> docgiaDictionary = new SortedDictionary<string, string>();
        SortedDictionary<string, string> nhanvienDictionary = new SortedDictionary<string, string>();

        public frmQuanlyphieumuon()
        {
            InitializeComponent();
            this.loainguoidung = "quanly";
        }

        public frmQuanlyphieumuon(string ma, string loainguoidung)
        {
            InitializeComponent();
            this.loainguoidung = loainguoidung;
            if(loainguoidung == "thuthu")
            {
                this.manhanvien = ma;
            } else if(loainguoidung == "docgia")
            {
                this.docgiaTimkiem = ma;
            }
        }

        private void frmQuanlyphieumuon_Load(object sender, EventArgs e)
        {
            cbSohang.SelectedIndex = 2;
            cbXuatexcel.SelectedIndex = 0;
            dtpNgaylapphieu.CustomFormat = "dd/MM/yyyy";
            loadComboboxDocgia();
            loadComboboxNhanvien();
            if(loainguoidung == "docgia")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnXuatexcel.Visible = false;
                cbXuatexcel.Visible = false;
                cbTimkiemdocgia.Visible = false;
                cbTimkiemnhanvien.Visible = false;
            } else
            {
                cbTimkiemdocgia.SelectedIndexChanged += cbTimkiemdocgia_SelectedIndexChanged;
            }
        }

        private void loadComboboxDocgia()
        {
            try
            {
                docgiaDictionary.Clear();
                docgiaDictionary.Add("Default", "Chọn độc giả");
                System.Data.DataTable dt = Docgia.getAllDocgia();
                cbMadocgia.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row[0].ToString()}-{row[1].ToString()}";

                    docgiaDictionary.Add(row[0].ToString().ToUpper(), displayText);
                }
                if(docgiaDictionary.Count > 0)
                {
                    cbMadocgia.DataSource = new BindingSource(docgiaDictionary, null);
                    cbMadocgia.DisplayMember = "Value";
                    cbMadocgia.ValueMember = "Key";

                    cbTimkiemdocgia.DataSource = new BindingSource(docgiaDictionary, null);
                    cbTimkiemdocgia.DisplayMember = "Value";
                    cbTimkiemdocgia.ValueMember = "Key";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lấy dữ liệu thất bại", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadComboboxNhanvien()
        {
            try
            {
                nhanvienDictionary.Clear();
                nhanvienDictionary.Add("Default", "Chọn nhân viên");
                System.Data.DataTable dt = Nhanvien.getAllNhanvien();
                cbManhanvienlapphieu.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row[0]}-{row[1]}";

                    nhanvienDictionary.Add(row[0].ToString().ToUpper(), displayText);
                }
                if(nhanvienDictionary.Count > 0)
                {
                    cbManhanvienlapphieu.DataSource = new BindingSource(nhanvienDictionary, null);
                    cbManhanvienlapphieu.DisplayMember = "Value";
                    cbManhanvienlapphieu.ValueMember = "Key";

                    cbTimkiemnhanvien.DataSource = new BindingSource(nhanvienDictionary, null);
                    cbTimkiemnhanvien.DisplayMember = "Value";
                    cbTimkiemnhanvien.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu thất bại" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void loadData()
        {
            Tuple<int, System.Data.DataTable> result = Phieumuon.searchPhieumuon(pageSize, pageIndex, keySearch, nhanvienTimkiem, docgiaTimkiem);
            System.Data.DataTable dt = result.Item2;
            lbSonguoidung.Text = "Tổng số phiếu mượn: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            dt.Columns.Add("stt", typeof(int));
            dt.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvPhieumuon.DataSource = dt;
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
            dgvPhieumuon.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.NONE)
            {
                SwitchMode(CHUCNANG.UPDATE);
            }
            else
            {
                string maphieumuon = tbMaphieumuon.Text.Trim();
                string manhanvienlapphieu = (string)cbManhanvienlapphieu.SelectedValue;
                string madocgia = (string)cbMadocgia.SelectedValue;
                DateTime ngaylapphieu = dtpNgaylapphieu.Value;
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Phieumuon.getPhieumuon(maphieumuon) != null)
                    {
                        MessageBox.Show("Mã phiếu mượn đã tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Phieumuon.createPhieumuon(maphieumuon, manhanvienlapphieu, ngaylapphieu, madocgia))
                    {
                        dgvPhieumuon.Enabled = true;
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        btnThem.Focus();
                        MessageBox.Show("Thêm thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else if(chucnanghientai == CHUCNANG.UPDATE)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Phieumuon.updatePhieumuon(maphieumuon, manhanvienlapphieu, madocgia))
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
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu mượn này?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string maphieumuon = dgvPhieumuon.CurrentRow.Cells[1].Value.ToString();
                if (Phieumuon.deletePhieumuon(maphieumuon))
                {
                    MessageBox.Show("Xóa phiếu mượn sách thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvPhieumuon_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvPhieumuon.SelectionChanged -= dgvPhieumuon_SelectionChanged;
                dgvPhieumuon.ClearSelection();
                selectedRow.Selected = true;
                dgvPhieumuon.SelectionChanged += dgvPhieumuon_SelectionChanged;
                return;
            }
            else
            {
                this.selectedRow = null;
                if (dgvPhieumuon.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvPhieumuon.CurrentRow;
                    tbMaphieumuon.Text = (string)selectedRow.Cells["colMaphieumuon"].Value;
                    cbMadocgia.SelectedValue = selectedRow.Cells["colMadocgia"].Value;
                    cbManhanvienlapphieu.SelectedValue = selectedRow.Cells["colManhanvienlapphieu"].Value;
                    dtpNgaylapphieu.Value = (DateTime)selectedRow.Cells["colNgaylapphieu"].Value;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnChitietphieu.Enabled = true;
                }
                else if (chucnanghientai == CHUCNANG.NONE)
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnChitietphieu.Enabled = false;
                }
            }
        }

        private void dgvPhieumuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            bool isColumnNgayxb = dgvPhieumuon.Columns["colNgaylapphieu"] != null
                && e.ColumnIndex == dgvPhieumuon.Columns["colNgaylapphieu"].Index
                && e.Value != null;
            if (isColumnNgayxb)
            {
                DateTime ngaySinh = (DateTime)e.Value;
                e.Value = ngaySinh.ToString("dd/MM/yyyy");
            }
        }

        private void clearInput()
        {
            tbMaphieumuon.Text = "";
            cbManhanvienlapphieu.SelectedIndex = 0;
            cbMadocgia.SelectedIndex= 0;
        }

        private bool checkInput()
        {
            string maphieumuon = cbMadocgia.Text;
            string manhanvienlapphieu = (string)cbManhanvienlapphieu.SelectedValue;
            string madocgia = (string)cbMadocgia.SelectedValue;
            if(maphieumuon == "")
            {
                MessageBox.Show("Vui lòng nhập mã phiếu mượn", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMaphieumuon.Focus();
                return false;
            }
            if (madocgia == null || cbMadocgia.SelectedIndex == 0 || madocgia.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn độc giả mượn sách", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMadocgia.Focus();
                return false;
            }
            if (manhanvienlapphieu == null || cbManhanvienlapphieu.SelectedIndex == 0 || manhanvienlapphieu.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập phiếu", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbManhanvienlapphieu.Focus();
                return false;
            }
            return true;
        }

        private void setStateInput(bool enabled)
        {
            tbMaphieumuon.Enabled = enabled;
            if(loainguoidung == "quanly")
            {
                cbManhanvienlapphieu.Enabled = enabled;
            }
            cbMadocgia.Enabled = enabled;
            tbTimkiem.Enabled = !enabled;
            cbTimkiemdocgia.Enabled = !enabled;
            cbTimkiemnhanvien.Enabled = !enabled;
            cbXuatexcel.Enabled = !enabled;
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
            btnChitietphieu.Visible = state;
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
                        tbMaphieumuon.Focus();
                        setStateButton(false);
                        clearInput();
                        dtpNgaylapphieu.Value = DateTime.Today;
                        cbMadocgia.SelectedIndex = 0;
                        if(loainguoidung == "quanly")
                        {
                            cbManhanvienlapphieu.SelectedIndex = 0;
                        } else if(loainguoidung == "thuthu")
                        {
                            cbManhanvienlapphieu.SelectedValue = manhanvien;
                        }
                        dgvPhieumuon.ClearSelection();
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        tbMaphieumuon.Enabled = false;
                        cbMadocgia.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvPhieumuon.Enabled = true;
                        dgvPhieumuon_SelectionChanged(dgvPhieumuon, EventArgs.Empty);
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
                System.Data.DataTable dataTable = Phieumuon.exportToExcel(keySearch, nhanvienTimkiem, docgiaTimkiem, sachdangmuonTimkiem, quahanTimkiem);
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

        private void cbTimkiemdocgia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimkiemdocgia.SelectedIndex != 0)
            {
                this.docgiaTimkiem = (string)cbTimkiemdocgia.SelectedValue;
            }
            else this.docgiaTimkiem = "";
            loadData();
        }

        private void cbTimkiemnhanvien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimkiemnhanvien.SelectedIndex != 0)
            {
                this.nhanvienTimkiem = (string)cbTimkiemnhanvien.SelectedValue;
            }
            else this.nhanvienTimkiem = "";
            loadData();
        }

        private void btnChitietphieu_Click(object sender, EventArgs e)
        {
            if(loainguoidung == "quanly")
            {
                frmChitietphieumuon frm = new frmChitietphieumuon(selectedRow);
                frm.ShowDialog();
            } else if(loainguoidung == "thuthu")
            {
                frmChitietphieumuon frm = new frmChitietphieumuon(selectedRow, manhanvien, "thuthu");
                frm.ShowDialog();
            } else if (loainguoidung == "docgia")
            {
                frmChitietphieumuon frm = new frmChitietphieumuon(selectedRow, docgiaTimkiem, "docgia");
                frm.ShowDialog();
            }
        }

        private void cbXuatexcel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbXuatexcel.SelectedIndex == 1)
            {
                this.sachdangmuonTimkiem = true;
                this.quahanTimkiem = false;
            } else if(cbXuatexcel.SelectedIndex == 2)
            {
                this.sachdangmuonTimkiem = false;
                this.quahanTimkiem = true;
            }
        }
    }
}
