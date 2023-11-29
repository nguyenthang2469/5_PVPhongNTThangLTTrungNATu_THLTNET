using QuanLyThuVien.CSDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Taikhoan
{
    public partial class frmQuanlynhanvien : Form
    {
        private int chucnanghientai = CHUCNANG.NONE;
        private int pageIndex = 1;
        private int pageSize = 10; 
        private int totalPages = 0;
        private string keySearch = "";
        private DataGridViewRow selectedRow = null;
        private List<string> usernames = new List<string>();

        public frmQuanlynhanvien()
        {
            InitializeComponent();
        }

        private void frmQuanlynhanvien_Load(object sender, EventArgs e)
        {
            cbSohang.SelectedIndex = 2;
            dtpNgaysinh.CustomFormat = "dd/MM/yyyy";
            loadComboboxTendangnhap();
        }

        private void loadComboboxTendangnhap()
        {
            try
            {
                DataTable dt = DB.getData("SELECT tendangnhap FROM NguoiDung " +
                    "WHERE tendangnhap NOT IN(SELECT tendangnhap FROM NhanVien where tendangnhap IS NOT NULL) " +
                    "AND NOT tendangnhap = 'admin' AND loainguoidung = 'thuthu'"
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

        private void loadData()
        {
            Tuple<int, DataTable> result = Nhanvien.searchNhanvien(pageSize, pageIndex, keySearch);
            DataTable employees = result.Item2;
            lbSonguoidung.Text = "Tổng số nhân viên: " + result.Item1;
            totalPages = (int)Math.Ceiling((double)result.Item1 / pageSize);
            employees.Columns.Add("stt", typeof(int));
            employees.Columns["stt"].SetOrdinal(0); // Set vị trí cho cột stt làm cột đầu trong Datatable
            for (int i = 0; i < employees.Rows.Count; i++)
            {
                employees.Rows[i]["stt"] = ((pageIndex - 1) * pageSize) + i + 1;
            }
            dgvNhanvien.DataSource = employees;
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
                string manhanvien = tbManhanvien.Text.Trim();
                string tennhanvien = tbTennhanvien.Text.Trim();
                DateTime ngaysinh = dtpNgaysinh.Value;
                string gioitinh = (string)cbGioitinh.SelectedItem;
                string sdt = tbSdt.Text.Trim();
                string tendangnhap = (string)cbTendangnhap.SelectedItem;
                if (chucnanghientai == CHUCNANG.ADD)
                {
                    if (checkInput() == false)
                    {
                        return;
                    }
                    if (Nhanvien.getNhanvien(manhanvien) != null)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (Nhanvien.createNhanvien(manhanvien, tennhanvien, ngaysinh, gioitinh, sdt, tendangnhap))
                    {
                        dgvNhanvien.Enabled = true;
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
                    if (Nhanvien.updateNhanvien(manhanvien, tennhanvien, ngaysinh, gioitinh, sdt))
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
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                string manhanvien = dgvNhanvien.CurrentRow.Cells[1].Value.ToString();
                string tendangnhap = dgvNhanvien.CurrentRow.Cells[6].Value.ToString();
                if (Nhanvien.deleteNhanvien(manhanvien, tendangnhap))
                {
                    MessageBox.Show("Xóa nhân viên " + manhanvien + " thành công", "Thông bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            dgvNhanvien.Enabled = false;
        }

        private void dgvNhanvien_SelectionChanged(object sender, EventArgs e)
        {
            if (chucnanghientai == CHUCNANG.UPDATE && selectedRow != null)
            {
                dgvNhanvien.SelectionChanged -= dgvNhanvien_SelectionChanged;
                dgvNhanvien.ClearSelection();
                selectedRow.Selected = true;
                dgvNhanvien.SelectionChanged += dgvNhanvien_SelectionChanged;
                return;
            } else
            {
                this.selectedRow = null;
                if (dgvNhanvien.SelectedRows.Count > 0)
                {
                    this.selectedRow = dgvNhanvien.CurrentRow;
                    setComboboxTendangnhap(selectedRow.Cells[6].Value.ToString());
                    tbManhanvien.Text = (string)selectedRow.Cells[1].Value;
                    tbTennhanvien.Text = (string)selectedRow.Cells[2].Value;
                    dtpNgaysinh.Value = (DateTime)selectedRow.Cells[3].Value;
                    cbGioitinh.SelectedItem = selectedRow.Cells[4].Value;
                    tbSdt.Text = (string)selectedRow.Cells[5].Value;
                    cbTendangnhap.SelectedItem = selectedRow.Cells[6].Value;
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
            tbManhanvien.Text = "";
            tbTennhanvien.Text = "";
            cbGioitinh.SelectedIndex = -1;
            tbSdt.Text = "";
            cbTendangnhap.SelectedIndex = -1;
        }

        private void setStateInput(bool enabled)
        {
            tbManhanvien.Enabled = enabled;
            tbTennhanvien.Enabled = enabled;
            tbSdt.Enabled = enabled;
            dtpNgaysinh.Enabled = enabled;
            cbGioitinh.Enabled = enabled;
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
                        tbManhanvien.Focus();
                        setStateButton(false);
                        clearInput();
                        dgvNhanvien.ClearSelection();
                        break;
                    }
                case CHUCNANG.UPDATE:
                    {
                        setStateInput(true);
                        tbManhanvien.Enabled = false;
                        cbTendangnhap.Enabled = false;
                        tbTennhanvien.Focus();
                        setStateButton(false);
                        break;
                    }
                case CHUCNANG.NONE:
                    {
                        clearInput();
                        setStateInput(false);
                        setStateButton(true);
                        dgvNhanvien.Enabled = true;
                        dgvNhanvien_SelectionChanged(dgvNhanvien, EventArgs.Empty);
                        break;
                    }
            }
        }

        private bool checkInput()
        {
            string manhanvien = tbManhanvien.Text.Trim();
            string tennhanvien = tbTennhanvien.Text.Trim();
            string gioitinh = (string)cbGioitinh.SelectedItem;
            string sdt = tbSdt.Text.Trim();
            string tendangnhap = (string)cbTendangnhap.SelectedItem;
            if (manhanvien.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbManhanvien.Focus();
                return false;
            }
            if (tennhanvien.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTennhanvien.Focus();
                return false;
            }
            if (gioitinh == null || gioitinh.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGioitinh.Focus();
                return false;
            }
            if (sdt.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSdt.Focus();
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

        private void dgvNhanvien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanvien.Columns["colNgaySinh"] != null && e.ColumnIndex == dgvNhanvien.Columns["colNgaySinh"].Index && e.Value != null)
            {
                DateTime ngaySinh = (DateTime)e.Value;
                e.Value = ngaySinh.ToString("dd/MM/yyyy");
            }
        }
    }
}
