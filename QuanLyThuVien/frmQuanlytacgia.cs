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
    public partial class frmQuanlytacgia : Form
    {
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private DataGridViewRow selectedRow = null;

        public frmQuanlytacgia()
        {
            InitializeComponent();
        }

        private void frmQuanlytacgia_Load(object sender, EventArgs e)
        {
            cbSohang.SelectedIndex = 2;
        }

        private void loadData()
        {
            Tuple<int, System.Data.DataTable> result = TacGia.searchTacgia(pageSize, pageIndex, keySearch);
            System.Data.DataTable dt = result.Item2;
            lbSonguoidung.Text = "Tổng số tác giả: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            dt.Columns.Add("stt", typeof(int));
            dt.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvTacgia.DataSource = dt;
            UpdatePager();
            showButtonPage();
            if (keySearch != "" && result.Item1 == 0) MessageBox.Show("Không tìm thấy bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void showButtonPage(bool isShow = true)
        {
            if(isShow)
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
            } else
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
            dgvTacgia.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.NONE)
            {
                SwitchMode(CHUCNANG.UPDATE);
            }
            else
            {
                string matacgia = tbMatacgia.Text.Trim();
                string tentacgia = tbTentacgia.Text.Trim();
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (TacGia.getTacgia(matacgia) != null)
                    {
                        MessageBox.Show("Mã tác giả đã tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (TacGia.createTacgia(matacgia, tentacgia))
                    {
                        dgvTacgia.Enabled = true;
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
                    if (TacGia.updateTacgia(matacgia, tentacgia))
                    {
                        SwitchMode(CHUCNANG.NONE);
                        loadData();
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
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa tác giả này?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string matacgia = dgvTacgia.CurrentRow.Cells[1].Value.ToString();
                if(Sach.searchSach(1, 1, "", matacgia).Item2.Rows.Count > 0)
                {
                    MessageBox.Show("Hiện đang có sách của tác giả này trong thư viện, không thể xóa", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (TacGia.deleteTacgia(matacgia))
                {
                    MessageBox.Show("Xóa tác giả thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvTacgia_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvTacgia.SelectionChanged -= dgvTacgia_SelectionChanged;
                dgvTacgia.ClearSelection();
                selectedRow.Selected = true;
                dgvTacgia.SelectionChanged += dgvTacgia_SelectionChanged;
                return;
            } else
            {
                this.selectedRow = null;
                if (dgvTacgia.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvTacgia.CurrentRow;
                    tbMatacgia.Text = (string)selectedRow.Cells[1].Value;
                    tbTentacgia.Text = (string)selectedRow.Cells[2].Value;
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
            tbMatacgia.Text = "";
            tbTentacgia.Text = "";
        }

        private bool checkInput()
        {
            string matacgia = tbMatacgia.Text.Trim();
            string tentacgia = tbTentacgia.Text.Trim();
            if (matacgia.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã tác giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMatacgia.Focus();
                return false;
            }
            if (tentacgia.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên tác giả", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTentacgia.Focus();
                return false;
            }
            return true;
        }

        private void setStateInput(bool enabled)
        {
            tbMatacgia.Enabled = enabled;
            tbTentacgia.Enabled = enabled;
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
                        tbMatacgia.Focus();
                        setStateButton(false);
                        clearInput();
                        dgvTacgia.ClearSelection();
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        tbMatacgia.Enabled = false;
                        tbTentacgia.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvTacgia.Enabled = true;
                        dgvTacgia_SelectionChanged(dgvTacgia, EventArgs.Empty);
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
                System.Data.DataTable dataTable = TacGia.exportToExcel(keySearch);
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
                worksheet.Name = "Danh sách tác giả";

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
