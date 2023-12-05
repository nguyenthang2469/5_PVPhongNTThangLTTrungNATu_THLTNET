using Microsoft.Office.Interop.Excel;
using QuanLyThuVien.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Taikhoan
{
    public partial class frmChitietphieumuon : Form
    {
        private string maphieu = "";
        private string madocgia = "";
        private string loainguoidung = "";
        private string manhanvien = "";
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private string tinhtrangTimkiem = "";
        private int? tienphatTimkiem = null;
        private DataGridViewRow selectedRow = null;
        SortedDictionary<string, string> sachDictionary = new SortedDictionary<string, string>();
        SortedDictionary<string, string> nhanvienDictionary = new SortedDictionary<string, string>();
        SortedDictionary<string, string> tinhtrangDictionary = new SortedDictionary<string, string>()
        {
            { "Default", "Chọn tình trạng" },
            { "True", "Đang mượn" },
            { "False", "Đã trả" }
        };

        public frmChitietphieumuon(DataGridViewRow phieumuon, string loainguoidung = "quanly")
        {
            InitializeComponent();
            this.maphieu = phieumuon.Cells["colMaphieumuon"].Value.ToString();
            this.madocgia = phieumuon.Cells["colMadocgia"].Value.ToString();
            this.loainguoidung = loainguoidung;
        }

        public frmChitietphieumuon(DataGridViewRow phieumuon, string ma, string loainguoidung)
        {
            InitializeComponent();
            this.maphieu = phieumuon.Cells["colMaphieumuon"].Value.ToString();
            this.madocgia = phieumuon.Cells["colMadocgia"].Value.ToString();
            this.loainguoidung = loainguoidung;
            if(loainguoidung == "thuthu")
            {
                this.manhanvien = ma;
            } else if(loainguoidung == "docgia")
            {
                this.madocgia = ma;
            }
        }

        private void frmChitietphieumuon_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            cbSohang.SelectedIndex = 2;
            cbVipham.SelectedIndex = 0;
            dtpNgaytrasach.CustomFormat = "dd/MM/yyyy";
            tbMaphieumuon.Text = maphieu;
            loadComboboxSach();
            loadComboboxNhanvien();
            loadComboboxTinhtrang();
            if (loainguoidung == "docgia")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnXuatexcel.Visible = false;
            }
        }

        private void loadComboboxTinhtrang()
        {
            cbTinhtrang.DataSource = new BindingSource(tinhtrangDictionary, null);
            cbTinhtrang.DisplayMember = "Value";
            cbTinhtrang.ValueMember = "Key";

            cbTimkiemtinhtrang.DataSource = new BindingSource(tinhtrangDictionary, null);
            cbTimkiemtinhtrang.DisplayMember = "Value";
            cbTimkiemtinhtrang.ValueMember = "Key";
        }

        private void loadComboboxSach()
        {
            try
            {
                sachDictionary.Clear();
                sachDictionary.Add("Default", "Chọn sách");
                System.Data.DataTable dt = Sach.getAllSach();
                cbMasach.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row[0]}-{row[1]}";

                    sachDictionary.Add(row[0].ToString().ToUpper(), displayText);
                }
                if(sachDictionary.Count > 0)
                {
                    cbMasach.DataSource = new BindingSource(sachDictionary, null);
                    cbMasach.DisplayMember = "Value";
                    cbMasach.ValueMember = "Key";
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
                cbManhanviennhantra.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    string displayText = $"{row[0]}-{row[1]}";

                    nhanvienDictionary.Add(row[0].ToString().ToUpper(), displayText);
                }
                if(nhanvienDictionary.Count > 0)
                {
                    cbManhanviennhantra.DataSource = new BindingSource(nhanvienDictionary, null);
                    cbManhanviennhantra.DisplayMember = "Value";
                    cbManhanviennhantra.ValueMember = "Key";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy dữ liệu thất bại" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void loadData()
        {
            Tuple<int, System.Data.DataTable> result = Chitietphieumuon.searchChitietphieumuon(pageSize, pageIndex, keySearch, maphieu, tinhtrangTimkiem, tienphatTimkiem);
            System.Data.DataTable dt = result.Item2;
            lbSonguoidung.Text = "Tổng số sách trong phiếu: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            dt.Columns.Add("stt", typeof(int));
            dt.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvChitietphieumuon.DataSource = dt;
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
            dgvChitietphieumuon.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.NONE)
            {
                if(selectedRow.Cells["colTinhtrang"].Value.ToString() == "True")
                {
                    SwitchMode(CHUCNANG.RETURNBOOK);
                } else SwitchMode(CHUCNANG.UPDATE);
            }
            else
            {
                string manhanviennhansachtra = (string)cbManhanviennhantra.SelectedValue;
                string masach = (string)cbMasach.SelectedValue;
                DateTime ngaytrasach = dtpNgaytrasach.Value;
                string tinhtrang = (string)cbTinhtrang.SelectedValue;
                int.TryParse(nudTienphat.Value.ToString(), out int tienphat);
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if(Chitietphieumuon.countChitietphieumuonByDocgia("", madocgia, "True") >= 5)
                    {
                        MessageBox.Show("Độc giả chỉ được phép mượn tối đa 5 sách cùng lúc", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    DataRow sach = Sach.getSach(masach);
                    if(sach != null && int.TryParse(sach["soluong"].ToString(), out int soluong))
                    {
                        if(soluong <= 0)
                        {
                            MessageBox.Show("Sách hiện tại đang hết, không thể mượn", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    if (Chitietphieumuon.getChitietphieumuon(maphieu, masach) != null)
                    {
                        MessageBox.Show("Sách này đã tồn tại trong phiếu mượn " + maphieu, "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Chitietphieumuon.createChitietphieumuon(maphieu, masach))
                    {
                        dgvChitietphieumuon.Enabled = true;
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        btnThem.Focus();
                        MessageBox.Show("Mượn sách thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (Chitietphieumuon.updateChitietphieumuon(maphieu, masach, tinhtrang, ngaytrasach, manhanviennhansachtra, tienphat))
                    {
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        MessageBox.Show("Cập nhật thành công", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else if(chucnanghientai == CHUCNANG.RETURNBOOK)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Chitietphieumuon.updateChitietphieumuon(maphieu, masach, tinhtrang, ngaytrasach, manhanviennhansachtra))
                    {
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
                        DataRow chitietphieumuon = Chitietphieumuon.getChitietphieumuon(maphieu, masach);
                        if (chitietphieumuon != null)
                        {
                            try
                            {
                                if(chitietphieumuon["tienphat"] != null && int.TryParse(chitietphieumuon["tienphat"].ToString(), out int tienphatAfterReturnBook))
                                {
                                    if(tienphat > 0)
                                    {
                                        MessageBox.Show("Tiền phạt của độc giả là " + tienphatAfterReturnBook, "Thông báo tiền phạt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        MessageBox.Show("Trả sách thành công", "Thông báo trả sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Trả sách thất bại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(chucnanghientai == CHUCNANG.NONE)
            {
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa sách này khỏi phiếu mượn?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string masach = selectedRow.Cells["colMasach"].Value.ToString();
                if (Chitietphieumuon.deleteChitietphieumuon(maphieu, masach))
                {
                    MessageBox.Show("Xóa sách khỏi phiếu mượn thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvChitietphieumuon_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvChitietphieumuon.SelectionChanged -= dgvChitietphieumuon_SelectionChanged;
                dgvChitietphieumuon.ClearSelection();
                selectedRow.Selected = true;
                dgvChitietphieumuon.SelectionChanged += dgvChitietphieumuon_SelectionChanged;
                return;
            }
            else
            {
                this.selectedRow = null;
                if (dgvChitietphieumuon.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvChitietphieumuon.CurrentRow;
                    cbMasach.SelectedValue = (string)selectedRow.Cells["colMasach"].Value;
                    if (selectedRow.Cells["colManhanviennhansachtra"].Value != DBNull.Value)
                    {
                        cbManhanviennhantra.SelectedValue = (string)selectedRow.Cells["colManhanviennhansachtra"].Value;
                    }
                    else
                    {
                        cbManhanviennhantra.SelectedIndex = -1;
                    }
                    if (selectedRow.Cells["colNgaytrasach"].Value is DateTime)
                    {
                        dtpNgaytrasach.Value = (DateTime)selectedRow.Cells["colNgaytrasach"].Value;
                    }
                    else
                    {
                        dtpNgaytrasach.Checked = false;
                    }
                    decimal tienphat;
                    if(Decimal.TryParse(selectedRow.Cells["colTienphat"].Value.ToString(), out tienphat))
                    {
                        nudTienphat.Value = tienphat;
                    }
                    cbTinhtrang.SelectedValue = selectedRow.Cells["colTinhtrang"].Value.ToString();
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnSua.Text = selectedRow.Cells["colTinhtrang"].Value.ToString() == "True" ? "Trả sách" : "Sửa";
                }
                else if (chucnanghientai == CHUCNANG.NONE)
                {
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
        }

        private void dgvChitietphieumuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvChitietphieumuon.Columns["colNgaytrasach"] != null && 
                e.ColumnIndex == dgvChitietphieumuon.Columns["colNgaytrasach"].Index && 
                e.Value != null
            )
            {
                if (e.Value is DateTime ngaySinh)
                {
                    e.Value = ngaySinh.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
                else if (e.Value == DBNull.Value)
                {
                    e.Value = "------";
                    e.FormattingApplied = true;
                }
                else
                {
                    MessageBox.Show("Giá trị không phải là kiểu DateTime.");
                }
            }
            if (dgvChitietphieumuon.Columns["colTinhtrang"] != null && 
                e.ColumnIndex == dgvChitietphieumuon.Columns["colTinhtrang"].Index && 
                e.Value != null
            )
            {
                if (e.Value is bool tinhTrang)
                {
                    e.Value = tinhTrang ? "Đang mượn" : "Đã trả";
                    e.FormattingApplied = true;
                }
                else
                {
                    MessageBox.Show("Giá trị không phải là kiểu Boolean.");
                }
            }
            if (dgvChitietphieumuon.Columns["colTennhanvien"] != null &&
                e.ColumnIndex == dgvChitietphieumuon.Columns["colTennhanvien"].Index &&
                string.IsNullOrEmpty(e.Value.ToString())
            )
            {
                e.Value = "----------------------------";
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.FormattingApplied = true;
            }
        }

        private void clearInput()
        {
            cbManhanviennhantra.SelectedIndex = 0;
            cbMasach.SelectedIndex= 0;
            cbTinhtrang.SelectedIndex = 0;
            nudTienphat.Value = 0;
        }

        private bool checkInput()
        {
            string manhanviennhantra = (string)cbManhanviennhantra.SelectedValue;
            string masach = (string)cbMasach.SelectedValue;
            string tinhtrang = (string)cbTinhtrang.SelectedValue;
            if (masach == null || cbMasach.SelectedIndex == 0 || masach.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã sách", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMasach.Focus();
                return false;
            }
            if (tinhtrang == null || cbTinhtrang.SelectedIndex == 0 || tinhtrang.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn tình trạng mượn sách", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTinhtrang.Focus();
                return false;
            }
            if(tinhtrang == "False")
            {
                if (manhanviennhantra == null || cbManhanviennhantra.SelectedIndex == 0 || manhanviennhantra.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên nhận sách trả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbManhanviennhantra.Focus();
                    return false;
                }
            }
            return true;
        }

        private void setStateInput(bool enabled)
        {
            cbMasach.Enabled = enabled;
            if (loainguoidung == "quanly")
            {
                cbManhanviennhantra.Enabled = enabled;
            }
            dtpNgaytrasach.Enabled = enabled;
            nudTienphat.Enabled = enabled;
            tbTimkiem.Enabled = !enabled;
            cbTimkiemtinhtrang.Enabled = !enabled;
            cbVipham.Enabled = !enabled;
            cbSohang.Enabled = !enabled;
        }

        private void setStateButton(bool state)
        {
            // State = true: hiển thị thêm sửa xóa, không thì hiển thị lưu hủy
            if(state)
            {
                if(selectedRow != null)
                {
                    btnSua.Text = selectedRow.Cells["colTinhtrang"].Value.ToString() == "True" ? "Trả sách" : "Sửa";
                } else
                {
                    btnSua.Text = "Sửa";
                }
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
                        cbManhanviennhantra.Enabled = false;
                        cbMasach.Focus();
                        setStateButton(false);
                        clearInput();
                        dtpNgaytrasach.Value = DateTime.Today;
                        cbTinhtrang.SelectedIndex = 2;
                        dtpNgaytrasach.Enabled = false;
                        nudTienphat.Enabled = false;
                        cbTinhtrang.Enabled = false;
                        dgvChitietphieumuon.ClearSelection();
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        cbMasach.Enabled = false;
                        cbManhanviennhantra.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.RETURNBOOK:
                    {
                        setStateInput(true);
                        dtpNgaytrasach.Value = DateTime.Today;
                        cbMasach.Enabled = false;
                        dtpNgaytrasach.Enabled = false;
                        cbTinhtrang.SelectedIndex = 1;
                        cbTinhtrang.Enabled = false;
                        nudTienphat.Enabled = false;
                        if (loainguoidung == "quanly")
                        {
                            cbManhanviennhantra.SelectedIndex = 0;
                        }
                        else if (loainguoidung == "thuthu")
                        {
                            cbManhanviennhantra.SelectedValue = manhanvien;
                        }
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvChitietphieumuon.Enabled = true;
                        dgvChitietphieumuon_SelectionChanged(dgvChitietphieumuon, EventArgs.Empty);
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
                System.Data.DataTable dataTable = Chitietphieumuon.exportToExcel(maphieu, keySearch, tinhtrangTimkiem, tienphatTimkiem);
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

        private void cbTimkiemtimtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimkiemtinhtrang.SelectedIndex != 0)
            {
                this.tinhtrangTimkiem = (string)cbTimkiemtinhtrang.SelectedValue;
            }
            else this.tinhtrangTimkiem = "";
            loadData();
        }

        private void cbVipham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVipham.SelectedIndex == 1)
            {
                this.tienphatTimkiem = 1;
            }
            else if(cbVipham.SelectedIndex == 2)
            {
                this.tienphatTimkiem = 0;
            } else
            {
                this.tienphatTimkiem = null;
            }
            loadData();
        }
    }
}
