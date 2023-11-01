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
    public partial class fDanhsachtaikhoan : Form
    {
        private int pageIndex = 1;
        private int pageSize = 10; // Số lượng mục trên mỗi trang
        private int totalPages = 0;

        Dictionary<string, string> roles = new Dictionary<string, string>
        {
            { "thuthu", "Thủ thư" },
            { "docgia", "Độc giả" }
        };

        public fDanhsachtaikhoan()
        {
            InitializeComponent();
            cbSohang.SelectedIndex = 2;
        }

        private void fDanhsachtaikhoan_Load(object sender, EventArgs e)
        {
            cbLoainguoidung.DataSource = new BindingSource(roles, null);
            cbLoainguoidung.DisplayMember = "Value";
            cbLoainguoidung.ValueMember = "Key";
        }

        private void loadData()
        {
            dgvTaikhoan.DataSource = null;
            int totalAccounts = Account.getTotalElements();
            DataTable accounts = Account.searchAccount(pageSize, pageIndex);
            totalPages = (int)Math.Ceiling((double)totalAccounts / pageSize);

            dgvTaikhoan.DataSource = accounts;
            if(dgvTaikhoan.Rows.Count > 0)
            {
                dgvTaikhoan.Rows[0].Selected = true;
            }
            UpdatePager();
            if(pageIndex == 1)
            {
                btnFirst.Enabled = false;
                btnBefore.Enabled = false;
            } else
            {
                btnFirst.Enabled = true;
                btnBefore.Enabled = true;
            }
            if(pageIndex == totalPages)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            } else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }
            tbTendangnhap.Enabled = false;
            tbMatkhau.Enabled = false;
            tbTendangnhap.Text = "";
            tbMatkhau.Text = "";
            cbLoainguoidung.SelectedIndex = -1;
            cbLoainguoidung.Enabled = false;
            dgvTaikhoan.ClearSelection();
        }

        private void UpdatePager()
        {
            lbCurrentpage.Text = pageIndex + "/" + totalPages;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if(pageIndex > 1)
            {
                pageIndex = 1;
                loadData();
                UpdatePager();
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                loadData();
                UpdatePager();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageIndex < totalPages)
            {
                pageIndex++;
                loadData();
                UpdatePager();
            }
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
                UpdatePager();
            }
        }

        private void dgvTaikhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaikhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTaikhoan.SelectedRows[0];
                tbTendangnhap.Text = selectedRow.Cells["tendangnhap"].Value.ToString();
                tbMatkhau.Text = selectedRow.Cells["matkhau"].Value.ToString();
                cbLoainguoidung.SelectedValue = selectedRow.Cells["loainguoidung"].Value.ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            } else {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            handleTextbox(true); // Cho phép sửa textbox
            switchMode(false); // Chuyển chế độ Lưu hoặc hủy
            dgvTaikhoan.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            handleTextbox(true); // Cho phép sửa textbox
            switchMode(false); // Chuyển chế độ Lưu hoặc hủy
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaikhoan.SelectedRows.Count > 0)
            {
                string tendangnhap = dgvTaikhoan.SelectedRows[0].Cells["tendangnhap"].Value.ToString();
                if (
                    MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản " + tendangnhap + "?", 
                    "Xác nhận", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes
                ) {
                    if(Account.DeleteAccount(tendangnhap) == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Xóa tài khoản " + tendangnhap + " thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                    } else
                    {
                        MessageBox.Show("Xảy ra lỗi khi xóa, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } else
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nào để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tendangnhap = tbTendangnhap.Text.Trim();
            string matkhau = tbMatkhau.Text.Trim();
            string loainguoidung = cbLoainguoidung.SelectedValue.ToString();
            string message = "";

            if (tendangnhap == "")
            {
                if (message.Length > 0)
                {
                    message += ", ";
                }
                tbTendangnhap.Focus();
                message += "tên đăng nhập";
            }
            if (matkhau == "")
            {
                if (message.Length > 0)
                {
                    message += " và ";
                }
                tbMatkhau.Focus();
                message += "mật khẩu";
            }
            if (message.Length > 0)
            {
                MessageBox.Show("Bạn chưa nhập " + message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dgvTaikhoan.SelectedRows.Count > 0) // Có dòng đang được chọn tức là chế độ chỉnh sửa
                {
                    DataRow dr = Account.getAccount(tendangnhap);
                    if(dr == null)
                    {
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        Account.UpdateAccount(tendangnhap, matkhau, loainguoidung);
                        MessageBox.Show("Cập nhật thành công", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        switchMode(true);  // Chuyển chế độ Thêm hoặc xóa
                    }
                }
                else
                {
                    DataRow dr = Account.getAccount(tendangnhap);
                    if (dr != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo thêm mới", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Account.CreateAccount(tendangnhap, matkhau, loainguoidung);
                        loadData();
                        switchMode(true);  // Chuyển chế độ Thêm hoặc xóa
                        dgvTaikhoan.Enabled = true;
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (dgvTaikhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTaikhoan.SelectedRows[0];
                tbTendangnhap.Text = selectedRow.Cells["tendangnhap"].Value.ToString();
                tbMatkhau.Text = selectedRow.Cells["matkhau"].Value.ToString();
                cbLoainguoidung.SelectedValue = selectedRow.Cells["loainguoidung"].Value.ToString();
            } else {
                dgvTaikhoan.ClearSelection();
                tbTendangnhap.Text = "";
                tbMatkhau.Text = "";
                cbLoainguoidung.SelectedIndex = -1;
            }
            handleTextbox(false); // Chặn sửa textbox
            switchMode(true);  // Chuyển chế độ Thêm hoặc xóa
            dgvTaikhoan.Enabled = true;
        }

        private void handleTextbox(bool enabled)
        {
            tbTendangnhap.Enabled = enabled;
            tbMatkhau.Enabled = enabled;
            cbLoainguoidung.Enabled = enabled;
        }

        private void switchMode(bool visible)
        {
            btnThem.Visible = visible;
            btnSua.Visible = visible;
            btnXoa.Visible = visible;
            btnLuu.Visible = !visible;
            btnHuy.Visible = !visible;
            dgvTaikhoan.Enabled = visible;
            if (visible) btnThem.Focus();
            else btnLuu.Focus();
        }
    }
}
