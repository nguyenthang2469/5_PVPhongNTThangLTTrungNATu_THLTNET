
namespace QuanLyThuVien.Taikhoan
{
    partial class frmQuanlytaikhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanlytaikhoan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbSonguoidung = new System.Windows.Forms.Label();
            this.btnTimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.tbTimkiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLast = new Guna.UI2.WinForms.Guna2Button();
            this.dgvNguoidung = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colTendangnhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatkhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoainguoidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAfter = new Guna.UI2.WinForms.Guna2Button();
            this.cbSohang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbChimuc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBefore = new Guna.UI2.WinForms.Guna2Button();
            this.btnFirst = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cbTimkiemloainguoidung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbLoainguoidung = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.tbMatkhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbTendangnhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoidung)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSonguoidung
            // 
            this.lbSonguoidung.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbSonguoidung.AutoSize = true;
            this.lbSonguoidung.BackColor = System.Drawing.Color.Transparent;
            this.lbSonguoidung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbSonguoidung.Location = new System.Drawing.Point(25, 18);
            this.lbSonguoidung.Name = "lbSonguoidung";
            this.lbSonguoidung.Size = new System.Drawing.Size(0, 20);
            this.lbSonguoidung.TabIndex = 19;
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimkiem.Animated = true;
            this.btnTimkiem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnTimkiem.BorderRadius = 5;
            this.btnTimkiem.BorderThickness = 1;
            this.btnTimkiem.CheckedState.Parent = this.btnTimkiem;
            this.btnTimkiem.CustomImages.Parent = this.btnTimkiem;
            this.btnTimkiem.FillColor = System.Drawing.Color.Transparent;
            this.btnTimkiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimkiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnTimkiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnTimkiem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnTimkiem.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnTimkiem.HoverState.Parent = this.btnTimkiem;
            this.btnTimkiem.Location = new System.Drawing.Point(750, 128);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.ShadowDecoration.Parent = this.btnTimkiem;
            this.btnTimkiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimkiem.TabIndex = 12;
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // tbTimkiem
            // 
            this.tbTimkiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTimkiem.Animated = true;
            this.tbTimkiem.AutoRoundedCorners = true;
            this.tbTimkiem.BackColor = System.Drawing.Color.Transparent;
            this.tbTimkiem.BorderRadius = 17;
            this.tbTimkiem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTimkiem.DefaultText = "";
            this.tbTimkiem.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbTimkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbTimkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTimkiem.DisabledState.Parent = this.tbTimkiem;
            this.tbTimkiem.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTimkiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbTimkiem.FocusedState.Parent = this.tbTimkiem;
            this.tbTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimkiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTimkiem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTimkiem.HoverState.Parent = this.tbTimkiem;
            this.tbTimkiem.IconLeft = ((System.Drawing.Image)(resources.GetObject("tbTimkiem.IconLeft")));
            this.tbTimkiem.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.tbTimkiem.Location = new System.Drawing.Point(539, 125);
            this.tbTimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTimkiem.Name = "tbTimkiem";
            this.tbTimkiem.PasswordChar = '\0';
            this.tbTimkiem.PlaceholderText = "Nhập từ khóa";
            this.tbTimkiem.SelectedText = "";
            this.tbTimkiem.ShadowDecoration.BorderRadius = 4;
            this.tbTimkiem.ShadowDecoration.Parent = this.tbTimkiem;
            this.tbTimkiem.Size = new System.Drawing.Size(201, 36);
            this.tbTimkiem.TabIndex = 11;
            this.tbTimkiem.TextOffset = new System.Drawing.Point(2, 0);
            this.tbTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTimkiem_KeyDown);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLast.Animated = true;
            this.btnLast.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnLast.BorderRadius = 5;
            this.btnLast.BorderThickness = 1;
            this.btnLast.CheckedState.Parent = this.btnLast;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.CustomImages.Parent = this.btnLast;
            this.btnLast.FillColor = System.Drawing.Color.Transparent;
            this.btnLast.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnLast.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnLast.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnLast.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLast.HoverState.Parent = this.btnLast;
            this.btnLast.Location = new System.Drawing.Point(784, 12);
            this.btnLast.Name = "btnLast";
            this.btnLast.ShadowDecoration.Parent = this.btnLast;
            this.btnLast.Size = new System.Drawing.Size(46, 30);
            this.btnLast.TabIndex = 18;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // dgvNguoidung
            // 
            this.dgvNguoidung.AllowUserToAddRows = false;
            this.dgvNguoidung.AllowUserToDeleteRows = false;
            this.dgvNguoidung.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvNguoidung.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNguoidung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvNguoidung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoidung.BackgroundColor = System.Drawing.Color.White;
            this.dgvNguoidung.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNguoidung.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoidung.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNguoidung.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNguoidung.ColumnHeadersHeight = 40;
            this.dgvNguoidung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTendangnhap,
            this.colMatkhau,
            this.colLoainguoidung});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNguoidung.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvNguoidung.EnableHeadersVisualStyles = false;
            this.dgvNguoidung.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoidung.Location = new System.Drawing.Point(30, 0);
            this.dgvNguoidung.MultiSelect = false;
            this.dgvNguoidung.Name = "dgvNguoidung";
            this.dgvNguoidung.ReadOnly = true;
            this.dgvNguoidung.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvNguoidung.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvNguoidung.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvNguoidung.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvNguoidung.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvNguoidung.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dgvNguoidung.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoidung.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvNguoidung.RowTemplate.Height = 38;
            this.dgvNguoidung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoidung.Size = new System.Drawing.Size(800, 336);
            this.dgvNguoidung.TabIndex = 13;
            this.dgvNguoidung.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvNguoidung.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoidung.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvNguoidung.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvNguoidung.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvNguoidung.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvNguoidung.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoidung.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoidung.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.dgvNguoidung.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvNguoidung.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNguoidung.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvNguoidung.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvNguoidung.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvNguoidung.ThemeStyle.ReadOnly = true;
            this.dgvNguoidung.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvNguoidung.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvNguoidung.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvNguoidung.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvNguoidung.ThemeStyle.RowsStyle.Height = 38;
            this.dgvNguoidung.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvNguoidung.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvNguoidung.SelectionChanged += new System.EventHandler(this.dgvNguoidung_SelectionChanged);
            // 
            // colTendangnhap
            // 
            this.colTendangnhap.DataPropertyName = "tendangnhap";
            this.colTendangnhap.HeaderText = "Tên đăng nhập";
            this.colTendangnhap.Name = "colTendangnhap";
            this.colTendangnhap.ReadOnly = true;
            // 
            // colMatkhau
            // 
            this.colMatkhau.DataPropertyName = "matkhau";
            this.colMatkhau.HeaderText = "Mật khẩu";
            this.colMatkhau.Name = "colMatkhau";
            this.colMatkhau.ReadOnly = true;
            // 
            // colLoainguoidung
            // 
            this.colLoainguoidung.DataPropertyName = "loainguoidung";
            this.colLoainguoidung.HeaderText = "Loại người dùng";
            this.colLoainguoidung.Name = "colLoainguoidung";
            this.colLoainguoidung.ReadOnly = true;
            // 
            // btnAfter
            // 
            this.btnAfter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAfter.Animated = true;
            this.btnAfter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnAfter.BorderRadius = 5;
            this.btnAfter.BorderThickness = 1;
            this.btnAfter.CheckedState.Parent = this.btnAfter;
            this.btnAfter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAfter.CustomImages.Parent = this.btnAfter;
            this.btnAfter.FillColor = System.Drawing.Color.Transparent;
            this.btnAfter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnAfter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnAfter.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnAfter.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAfter.HoverState.Parent = this.btnAfter;
            this.btnAfter.Location = new System.Drawing.Point(724, 12);
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.ShadowDecoration.Parent = this.btnAfter;
            this.btnAfter.Size = new System.Drawing.Size(46, 30);
            this.btnAfter.TabIndex = 17;
            this.btnAfter.Text = ">";
            this.btnAfter.Click += new System.EventHandler(this.btnAfter_Click);
            // 
            // cbSohang
            // 
            this.cbSohang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbSohang.BackColor = System.Drawing.Color.Transparent;
            this.cbSohang.BorderRadius = 5;
            this.cbSohang.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbSohang.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSohang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSohang.FocusedColor = System.Drawing.Color.Empty;
            this.cbSohang.FocusedState.Parent = this.cbSohang;
            this.cbSohang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSohang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSohang.FormattingEnabled = true;
            this.cbSohang.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbSohang.HoverState.Parent = this.cbSohang;
            this.cbSohang.ItemHeight = 30;
            this.cbSohang.Items.AddRange(new object[] {
            "3",
            "5",
            "10",
            "20",
            "50"});
            this.cbSohang.ItemsAppearance.Parent = this.cbSohang;
            this.cbSohang.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbSohang.ItemsAppearance.SelectedForeColor = System.Drawing.Color.White;
            this.cbSohang.Location = new System.Drawing.Point(458, 10);
            this.cbSohang.Name = "cbSohang";
            this.cbSohang.ShadowDecoration.Parent = this.cbSohang;
            this.cbSohang.Size = new System.Drawing.Size(85, 36);
            this.cbSohang.TabIndex = 14;
            this.cbSohang.SelectedIndexChanged += new System.EventHandler(this.cbSohang_SelectedIndexChanged);
            // 
            // lbChimuc
            // 
            this.lbChimuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbChimuc.AutoSize = true;
            this.lbChimuc.BackColor = System.Drawing.Color.Transparent;
            this.lbChimuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbChimuc.Location = new System.Drawing.Point(679, 17);
            this.lbChimuc.Name = "lbChimuc";
            this.lbChimuc.Size = new System.Drawing.Size(31, 20);
            this.lbChimuc.TabIndex = 15;
            this.lbChimuc.Text = "0/0";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(374, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số hàng";
            // 
            // btnBefore
            // 
            this.btnBefore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBefore.Animated = true;
            this.btnBefore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnBefore.BorderRadius = 5;
            this.btnBefore.BorderThickness = 1;
            this.btnBefore.CheckedState.Parent = this.btnBefore;
            this.btnBefore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBefore.CustomImages.Parent = this.btnBefore;
            this.btnBefore.FillColor = System.Drawing.Color.Transparent;
            this.btnBefore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBefore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnBefore.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnBefore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnBefore.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnBefore.HoverState.Parent = this.btnBefore;
            this.btnBefore.Location = new System.Drawing.Point(619, 13);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.ShadowDecoration.Parent = this.btnBefore;
            this.btnBefore.Size = new System.Drawing.Size(46, 30);
            this.btnBefore.TabIndex = 16;
            this.btnBefore.Text = "<";
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFirst.Animated = true;
            this.btnFirst.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnFirst.BorderRadius = 5;
            this.btnFirst.BorderThickness = 1;
            this.btnFirst.CheckedState.Parent = this.btnFirst;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.CustomImages.Parent = this.btnFirst;
            this.btnFirst.FillColor = System.Drawing.Color.Transparent;
            this.btnFirst.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnFirst.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnFirst.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnFirst.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnFirst.HoverState.Parent = this.btnFirst;
            this.btnFirst.Location = new System.Drawing.Point(559, 13);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.ShadowDecoration.Parent = this.btnFirst;
            this.btnFirst.Size = new System.Drawing.Size(46, 30);
            this.btnFirst.TabIndex = 15;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFist_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.cbTimkiemloainguoidung);
            this.guna2Panel1.Controls.Add(this.btnTimkiem);
            this.guna2Panel1.Controls.Add(this.cbLoainguoidung);
            this.guna2Panel1.Controls.Add(this.tbTimkiem);
            this.guna2Panel1.Controls.Add(this.btnSua);
            this.guna2Panel1.Controls.Add(this.tbMatkhau);
            this.guna2Panel1.Controls.Add(this.tbTendangnhap);
            this.guna2Panel1.Controls.Add(this.btnXoa);
            this.guna2Panel1.Controls.Add(this.btnThem);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(866, 171);
            this.guna2Panel1.TabIndex = 2;
            // 
            // cbTimkiemloainguoidung
            // 
            this.cbTimkiemloainguoidung.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTimkiemloainguoidung.AutoRoundedCorners = true;
            this.cbTimkiemloainguoidung.BackColor = System.Drawing.Color.White;
            this.cbTimkiemloainguoidung.BorderRadius = 17;
            this.cbTimkiemloainguoidung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTimkiemloainguoidung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimkiemloainguoidung.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbTimkiemloainguoidung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbTimkiemloainguoidung.FocusedState.FillColor = System.Drawing.Color.White;
            this.cbTimkiemloainguoidung.FocusedState.Parent = this.cbTimkiemloainguoidung;
            this.cbTimkiemloainguoidung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimkiemloainguoidung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbTimkiemloainguoidung.FormattingEnabled = true;
            this.cbTimkiemloainguoidung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbTimkiemloainguoidung.HoverState.Parent = this.cbTimkiemloainguoidung;
            this.cbTimkiemloainguoidung.ItemHeight = 30;
            this.cbTimkiemloainguoidung.ItemsAppearance.Parent = this.cbTimkiemloainguoidung;
            this.cbTimkiemloainguoidung.Location = new System.Drawing.Point(355, 125);
            this.cbTimkiemloainguoidung.Name = "cbTimkiemloainguoidung";
            this.cbTimkiemloainguoidung.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.cbTimkiemloainguoidung.ShadowDecoration.Parent = this.cbTimkiemloainguoidung;
            this.cbTimkiemloainguoidung.Size = new System.Drawing.Size(177, 36);
            this.cbTimkiemloainguoidung.TabIndex = 13;
            this.cbTimkiemloainguoidung.TextOffset = new System.Drawing.Point(8, 0);
            this.cbTimkiemloainguoidung.SelectedIndexChanged += new System.EventHandler(this.cbTimkiemloainguoidung_SelectedIndexChanged);
            // 
            // cbLoainguoidung
            // 
            this.cbLoainguoidung.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbLoainguoidung.AutoRoundedCorners = true;
            this.cbLoainguoidung.BackColor = System.Drawing.Color.White;
            this.cbLoainguoidung.BorderRadius = 17;
            this.cbLoainguoidung.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLoainguoidung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoainguoidung.Enabled = false;
            this.cbLoainguoidung.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbLoainguoidung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbLoainguoidung.FocusedState.FillColor = System.Drawing.Color.White;
            this.cbLoainguoidung.FocusedState.Parent = this.cbLoainguoidung;
            this.cbLoainguoidung.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoainguoidung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbLoainguoidung.FormattingEnabled = true;
            this.cbLoainguoidung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbLoainguoidung.HoverState.Parent = this.cbLoainguoidung;
            this.cbLoainguoidung.ItemHeight = 30;
            this.cbLoainguoidung.ItemsAppearance.Parent = this.cbLoainguoidung;
            this.cbLoainguoidung.Location = new System.Drawing.Point(595, 26);
            this.cbLoainguoidung.Name = "cbLoainguoidung";
            this.cbLoainguoidung.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.cbLoainguoidung.ShadowDecoration.Parent = this.cbLoainguoidung;
            this.cbLoainguoidung.Size = new System.Drawing.Size(235, 36);
            this.cbLoainguoidung.TabIndex = 2;
            this.cbLoainguoidung.TextOffset = new System.Drawing.Point(8, 0);
            this.cbLoainguoidung.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSua.Animated = true;
            this.btnSua.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnSua.BorderRadius = 5;
            this.btnSua.BorderThickness = 1;
            this.btnSua.CheckedState.Parent = this.btnSua;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.CustomImages.Parent = this.btnSua;
            this.btnSua.Enabled = false;
            this.btnSua.FillColor = System.Drawing.Color.Transparent;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnSua.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnSua.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnSua.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSua.HoverState.Parent = this.btnSua;
            this.btnSua.Location = new System.Drawing.Point(644, 84);
            this.btnSua.Name = "btnSua";
            this.btnSua.ShadowDecoration.Parent = this.btnSua;
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // tbMatkhau
            // 
            this.tbMatkhau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMatkhau.Animated = true;
            this.tbMatkhau.AutoRoundedCorners = true;
            this.tbMatkhau.BorderRadius = 17;
            this.tbMatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMatkhau.DefaultText = "";
            this.tbMatkhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbMatkhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMatkhau.DisabledState.Parent = this.tbMatkhau;
            this.tbMatkhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMatkhau.Enabled = false;
            this.tbMatkhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbMatkhau.FocusedState.Parent = this.tbMatkhau;
            this.tbMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMatkhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbMatkhau.HoverState.Parent = this.tbMatkhau;
            this.tbMatkhau.Location = new System.Drawing.Point(160, 76);
            this.tbMatkhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMatkhau.Name = "tbMatkhau";
            this.tbMatkhau.PasswordChar = '\0';
            this.tbMatkhau.PlaceholderText = "";
            this.tbMatkhau.SelectedText = "";
            this.tbMatkhau.ShadowDecoration.BorderRadius = 4;
            this.tbMatkhau.ShadowDecoration.Parent = this.tbMatkhau;
            this.tbMatkhau.Size = new System.Drawing.Size(235, 36);
            this.tbMatkhau.TabIndex = 1;
            this.tbMatkhau.TextOffset = new System.Drawing.Point(8, 0);
            this.tbMatkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // tbTendangnhap
            // 
            this.tbTendangnhap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTendangnhap.AutoRoundedCorners = true;
            this.tbTendangnhap.BorderRadius = 17;
            this.tbTendangnhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTendangnhap.DefaultText = "";
            this.tbTendangnhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbTendangnhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTendangnhap.DisabledState.Parent = this.tbTendangnhap;
            this.tbTendangnhap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTendangnhap.Enabled = false;
            this.tbTendangnhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTendangnhap.FocusedState.Parent = this.tbTendangnhap;
            this.tbTendangnhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTendangnhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTendangnhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTendangnhap.HoverState.Parent = this.tbTendangnhap;
            this.tbTendangnhap.Location = new System.Drawing.Point(160, 26);
            this.tbTendangnhap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTendangnhap.Name = "tbTendangnhap";
            this.tbTendangnhap.PasswordChar = '\0';
            this.tbTendangnhap.PlaceholderText = "";
            this.tbTendangnhap.SelectedText = "";
            this.tbTendangnhap.ShadowDecoration.BorderRadius = 4;
            this.tbTendangnhap.ShadowDecoration.Parent = this.tbTendangnhap;
            this.tbTendangnhap.Size = new System.Drawing.Size(235, 36);
            this.tbTendangnhap.TabIndex = 0;
            this.tbTendangnhap.TextOffset = new System.Drawing.Point(8, 0);
            this.tbTendangnhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.Animated = true;
            this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.BorderRadius = 5;
            this.btnXoa.BorderThickness = 1;
            this.btnXoa.CheckedState.Parent = this.btnXoa;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.CustomImages.Parent = this.btnXoa;
            this.btnXoa.Enabled = false;
            this.btnXoa.FillColor = System.Drawing.Color.Transparent;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnXoa.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnXoa.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnXoa.HoverState.Parent = this.btnXoa;
            this.btnXoa.Location = new System.Drawing.Point(749, 84);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ShadowDecoration.Parent = this.btnXoa;
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThem.Animated = true;
            this.btnThem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnThem.BorderRadius = 5;
            this.btnThem.BorderThickness = 1;
            this.btnThem.CheckedState.Parent = this.btnThem;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.CustomImages.Parent = this.btnThem;
            this.btnThem.FillColor = System.Drawing.Color.Transparent;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnThem.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnThem.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnThem.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnThem.HoverState.Parent = this.btnThem;
            this.btnThem.Location = new System.Drawing.Point(539, 84);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShadowDecoration.Parent = this.btnThem;
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại người dùng";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.lbSonguoidung);
            this.guna2Panel2.Controls.Add(this.btnLast);
            this.guna2Panel2.Controls.Add(this.btnFirst);
            this.guna2Panel2.Controls.Add(this.btnBefore);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.lbChimuc);
            this.guna2Panel2.Controls.Add(this.btnAfter);
            this.guna2Panel2.Controls.Add(this.cbSohang);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 513);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(866, 57);
            this.guna2Panel2.TabIndex = 4;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.dgvNguoidung);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 171);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(866, 342);
            this.guna2Panel3.TabIndex = 14;
            // 
            // frmQuanlytaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(866, 570);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuanlytaikhoan";
            this.Text = "frmQuanlytaikhoan";
            this.Load += new System.EventHandler(this.frmQuanlytaikhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoidung)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnTimkiem;
        private Guna.UI2.WinForms.Guna2TextBox tbTimkiem;
        private Guna.UI2.WinForms.Guna2Button btnLast;
        private Guna.UI2.WinForms.Guna2DataGridView dgvNguoidung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTendangnhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatkhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoainguoidung;
        private Guna.UI2.WinForms.Guna2Button btnAfter;
        private Guna.UI2.WinForms.Guna2ComboBox cbSohang;
        private System.Windows.Forms.Label lbChimuc;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnBefore;
        private Guna.UI2.WinForms.Guna2Button btnFirst;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cbLoainguoidung;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2TextBox tbMatkhau;
        private Guna.UI2.WinForms.Guna2TextBox tbTendangnhap;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSonguoidung;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2ComboBox cbTimkiemloainguoidung;
    }
}