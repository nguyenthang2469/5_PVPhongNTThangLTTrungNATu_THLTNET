
namespace QuanLyThuVien.Taikhoan
{
    partial class frmThongtinnhanvien
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongtinnhanvien));
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.tbSodienthoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpNgaysinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTennhanvien = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbManhanvien = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnDong = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.cbGioitinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(341, 25);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(193, 31);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "Thông tin cá nhân";
            // 
            // tbSodienthoai
            // 
            this.tbSodienthoai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbSodienthoai.Animated = true;
            this.tbSodienthoai.AutoRoundedCorners = true;
            this.tbSodienthoai.BorderRadius = 17;
            this.tbSodienthoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSodienthoai.DefaultText = "";
            this.tbSodienthoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbSodienthoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSodienthoai.DisabledState.Parent = this.tbSodienthoai;
            this.tbSodienthoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSodienthoai.Enabled = false;
            this.tbSodienthoai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbSodienthoai.FocusedState.Parent = this.tbSodienthoai;
            this.tbSodienthoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSodienthoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbSodienthoai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbSodienthoai.HoverState.Parent = this.tbSodienthoai;
            this.tbSodienthoai.Location = new System.Drawing.Point(525, 74);
            this.tbSodienthoai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSodienthoai.Name = "tbSodienthoai";
            this.tbSodienthoai.PasswordChar = '\0';
            this.tbSodienthoai.PlaceholderText = "";
            this.tbSodienthoai.SelectedText = "";
            this.tbSodienthoai.ShadowDecoration.BorderRadius = 4;
            this.tbSodienthoai.ShadowDecoration.Parent = this.tbSodienthoai;
            this.tbSodienthoai.Size = new System.Drawing.Size(259, 36);
            this.tbSodienthoai.TabIndex = 4;
            this.tbSodienthoai.TextOffset = new System.Drawing.Point(8, 0);
            this.tbSodienthoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(412, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 20);
            this.label8.TabIndex = 118;
            this.label8.Text = "Số điện thoại";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpNgaysinh
            // 
            this.dtpNgaysinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNgaysinh.AutoRoundedCorners = true;
            this.dtpNgaysinh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpNgaysinh.BorderRadius = 17;
            this.dtpNgaysinh.BorderThickness = 1;
            this.dtpNgaysinh.CheckedState.Parent = this.dtpNgaysinh;
            this.dtpNgaysinh.Enabled = false;
            this.dtpNgaysinh.FillColor = System.Drawing.Color.White;
            this.dtpNgaysinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpNgaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaysinh.HoverState.Parent = this.dtpNgaysinh;
            this.dtpNgaysinh.Location = new System.Drawing.Point(154, 125);
            this.dtpNgaysinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaysinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaysinh.Name = "dtpNgaysinh";
            this.dtpNgaysinh.ShadowDecoration.Parent = this.dtpNgaysinh;
            this.dtpNgaysinh.Size = new System.Drawing.Size(232, 36);
            this.dtpNgaysinh.TabIndex = 2;
            this.dtpNgaysinh.Value = new System.DateTime(2023, 11, 24, 0, 0, 0, 0);
            this.dtpNgaysinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 117;
            this.label5.Text = "Ngày sinh";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbTennhanvien
            // 
            this.tbTennhanvien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTennhanvien.Animated = true;
            this.tbTennhanvien.AutoRoundedCorners = true;
            this.tbTennhanvien.BorderRadius = 17;
            this.tbTennhanvien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTennhanvien.DefaultText = "";
            this.tbTennhanvien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbTennhanvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTennhanvien.DisabledState.Parent = this.tbTennhanvien;
            this.tbTennhanvien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTennhanvien.Enabled = false;
            this.tbTennhanvien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTennhanvien.FocusedState.Parent = this.tbTennhanvien;
            this.tbTennhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTennhanvien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTennhanvien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTennhanvien.HoverState.Parent = this.tbTennhanvien;
            this.tbTennhanvien.Location = new System.Drawing.Point(154, 74);
            this.tbTennhanvien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTennhanvien.Name = "tbTennhanvien";
            this.tbTennhanvien.PasswordChar = '\0';
            this.tbTennhanvien.PlaceholderText = "";
            this.tbTennhanvien.SelectedText = "";
            this.tbTennhanvien.ShadowDecoration.BorderRadius = 4;
            this.tbTennhanvien.ShadowDecoration.Parent = this.tbTennhanvien;
            this.tbTennhanvien.Size = new System.Drawing.Size(232, 36);
            this.tbTennhanvien.TabIndex = 1;
            this.tbTennhanvien.TextOffset = new System.Drawing.Point(8, 0);
            this.tbTennhanvien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // tbManhanvien
            // 
            this.tbManhanvien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbManhanvien.AutoRoundedCorners = true;
            this.tbManhanvien.BorderRadius = 17;
            this.tbManhanvien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbManhanvien.DefaultText = "";
            this.tbManhanvien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbManhanvien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbManhanvien.DisabledState.Parent = this.tbManhanvien;
            this.tbManhanvien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbManhanvien.Enabled = false;
            this.tbManhanvien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbManhanvien.FocusedState.Parent = this.tbManhanvien;
            this.tbManhanvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbManhanvien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbManhanvien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbManhanvien.HoverState.Parent = this.tbManhanvien;
            this.tbManhanvien.Location = new System.Drawing.Point(154, 23);
            this.tbManhanvien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbManhanvien.Name = "tbManhanvien";
            this.tbManhanvien.PasswordChar = '\0';
            this.tbManhanvien.PlaceholderText = "";
            this.tbManhanvien.SelectedText = "";
            this.tbManhanvien.ShadowDecoration.BorderRadius = 4;
            this.tbManhanvien.ShadowDecoration.Parent = this.tbManhanvien;
            this.tbManhanvien.Size = new System.Drawing.Size(232, 36);
            this.tbManhanvien.TabIndex = 0;
            this.tbManhanvien.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 112;
            this.label2.Text = "Tên nhân viên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.tbManhanvien);
            this.guna2Panel1.Controls.Add(this.tbTennhanvien);
            this.guna2Panel1.Controls.Add(this.tbSodienthoai);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.label8);
            this.guna2Panel1.Controls.Add(this.dtpNgaysinh);
            this.guna2Panel1.Controls.Add(this.cbGioitinh);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 74);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(855, 184);
            this.guna2Panel1.TabIndex = 123;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLuu.Animated = true;
            this.btnLuu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnLuu.BorderRadius = 5;
            this.btnLuu.BorderThickness = 1;
            this.btnLuu.CheckedState.Parent = this.btnLuu;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.CustomImages.Parent = this.btnLuu;
            this.btnLuu.FillColor = System.Drawing.Color.Transparent;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnLuu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnLuu.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnLuu.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.Parent = this.btnLuu;
            this.btnLuu.Location = new System.Drawing.Point(332, 278);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShadowDecoration.Parent = this.btnLuu;
            this.btnLuu.Size = new System.Drawing.Size(97, 30);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Chỉnh sửa";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FillColor = System.Drawing.Color.Transparent;
            this.btnDong.HoverState.Parent = this.btnDong;
            this.btnDong.IconColor = System.Drawing.Color.Gray;
            this.btnDong.Location = new System.Drawing.Point(830, 2);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShadowDecoration.Parent = this.btnDong;
            this.btnDong.Size = new System.Drawing.Size(48, 29);
            this.btnDong.TabIndex = 125;
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHuy.Animated = true;
            this.btnHuy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHuy.BorderRadius = 5;
            this.btnHuy.BorderThickness = 1;
            this.btnHuy.CheckedState.Parent = this.btnHuy;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.CustomImages.Parent = this.btnHuy;
            this.btnHuy.FillColor = System.Drawing.Color.Transparent;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHuy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnHuy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnHuy.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnHuy.HoverState.Parent = this.btnHuy;
            this.btnHuy.Location = new System.Drawing.Point(451, 278);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ShadowDecoration.Parent = this.btnHuy;
            this.btnHuy.Size = new System.Drawing.Size(97, 30);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // cbGioitinh
            // 
            this.cbGioitinh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbGioitinh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGioitinh.AutoRoundedCorners = true;
            this.cbGioitinh.BackColor = System.Drawing.Color.Transparent;
            this.cbGioitinh.BorderRadius = 18;
            this.cbGioitinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGioitinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGioitinh.Enabled = false;
            this.cbGioitinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbGioitinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbGioitinh.FocusedState.FillColor = System.Drawing.Color.White;
            this.cbGioitinh.FocusedState.Parent = this.cbGioitinh;
            this.cbGioitinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGioitinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbGioitinh.FormattingEnabled = true;
            this.cbGioitinh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.cbGioitinh.HoverState.Parent = this.cbGioitinh;
            this.cbGioitinh.ItemHeight = 32;
            this.cbGioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbGioitinh.ItemsAppearance.Parent = this.cbGioitinh;
            this.cbGioitinh.Location = new System.Drawing.Point(525, 22);
            this.cbGioitinh.Name = "cbGioitinh";
            this.cbGioitinh.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.cbGioitinh.ShadowDecoration.Parent = this.cbGioitinh;
            this.cbGioitinh.Size = new System.Drawing.Size(259, 38);
            this.cbGioitinh.TabIndex = 3;
            this.cbGioitinh.TextOffset = new System.Drawing.Point(8, 0);
            this.cbGioitinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 115;
            this.label3.Text = "Giới tính";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmThongtinnhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(879, 344);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongtinnhanvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin nhân viên";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.frmThongtinnhanvien_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2TextBox tbSodienthoai;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaysinh;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox tbTennhanvien;
        private Guna.UI2.WinForms.Guna2TextBox tbManhanvien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2ControlBox btnDong;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbGioitinh;
    }
}