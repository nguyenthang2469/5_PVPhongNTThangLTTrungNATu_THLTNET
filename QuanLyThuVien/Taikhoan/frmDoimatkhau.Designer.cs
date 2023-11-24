
namespace QuanLyThuVien.Taikhoan
{
    partial class frmDoimatkhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoimatkhau));
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.tbMatkhaucu = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.tbMatkhaumoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbNhaplaimatkhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDong = new Guna.UI2.WinForms.Guna2ControlBox();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.AutoRoundedCorners = true;
            this.btnLuu.BorderColor = System.Drawing.Color.Transparent;
            this.btnLuu.BorderRadius = 16;
            this.btnLuu.BorderThickness = 1;
            this.btnLuu.CheckedState.Parent = this.btnLuu;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.CustomImages.Parent = this.btnLuu;
            this.btnLuu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnLuu.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnLuu.HoverState.Parent = this.btnLuu;
            this.btnLuu.Location = new System.Drawing.Point(62, 246);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ShadowDecoration.Parent = this.btnLuu;
            this.btnLuu.Size = new System.Drawing.Size(83, 35);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // tbMatkhaucu
            // 
            this.tbMatkhaucu.Animated = true;
            this.tbMatkhaucu.AutoRoundedCorners = true;
            this.tbMatkhaucu.BorderRadius = 17;
            this.tbMatkhaucu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMatkhaucu.DefaultText = "";
            this.tbMatkhaucu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbMatkhaucu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbMatkhaucu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMatkhaucu.DisabledState.Parent = this.tbMatkhaucu;
            this.tbMatkhaucu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMatkhaucu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMatkhaucu.FocusedState.Parent = this.tbMatkhaucu;
            this.tbMatkhaucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatkhaucu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMatkhaucu.HoverState.Parent = this.tbMatkhaucu;
            this.tbMatkhaucu.Location = new System.Drawing.Point(35, 90);
            this.tbMatkhaucu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMatkhaucu.Name = "tbMatkhaucu";
            this.tbMatkhaucu.PasswordChar = '\0';
            this.tbMatkhaucu.PlaceholderText = "Mật khẩu cũ";
            this.tbMatkhaucu.SelectedText = "";
            this.tbMatkhaucu.ShadowDecoration.Parent = this.tbMatkhaucu;
            this.tbMatkhaucu.Size = new System.Drawing.Size(251, 36);
            this.tbMatkhaucu.TabIndex = 0;
            this.tbMatkhaucu.TextOffset = new System.Drawing.Point(8, 0);
            this.tbMatkhaucu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(93, 40);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(129, 27);
            this.guna2HtmlLabel1.TabIndex = 5;
            this.guna2HtmlLabel1.Text = "Đổi mật khẩu";
            // 
            // btnHuy
            // 
            this.btnHuy.AutoRoundedCorners = true;
            this.btnHuy.BorderColor = System.Drawing.Color.Transparent;
            this.btnHuy.BorderRadius = 16;
            this.btnHuy.BorderThickness = 1;
            this.btnHuy.CheckedState.Parent = this.btnHuy;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.CustomImages.Parent = this.btnHuy;
            this.btnHuy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnHuy.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnHuy.HoverState.Parent = this.btnHuy;
            this.btnHuy.Location = new System.Drawing.Point(167, 246);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.ShadowDecoration.Parent = this.btnHuy;
            this.btnHuy.Size = new System.Drawing.Size(83, 35);
            this.btnHuy.TabIndex = 101;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // tbMatkhaumoi
            // 
            this.tbMatkhaumoi.Animated = true;
            this.tbMatkhaumoi.AutoRoundedCorners = true;
            this.tbMatkhaumoi.BorderRadius = 17;
            this.tbMatkhaumoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMatkhaumoi.DefaultText = "";
            this.tbMatkhaumoi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbMatkhaumoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbMatkhaumoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMatkhaumoi.DisabledState.Parent = this.tbMatkhaumoi;
            this.tbMatkhaumoi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMatkhaumoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMatkhaumoi.FocusedState.Parent = this.tbMatkhaumoi;
            this.tbMatkhaumoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatkhaumoi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbMatkhaumoi.HoverState.Parent = this.tbMatkhaumoi;
            this.tbMatkhaumoi.Location = new System.Drawing.Point(35, 139);
            this.tbMatkhaumoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMatkhaumoi.Name = "tbMatkhaumoi";
            this.tbMatkhaumoi.PasswordChar = '\0';
            this.tbMatkhaumoi.PlaceholderText = "Mật khẩu mới";
            this.tbMatkhaumoi.SelectedText = "";
            this.tbMatkhaumoi.ShadowDecoration.Parent = this.tbMatkhaumoi;
            this.tbMatkhaumoi.Size = new System.Drawing.Size(251, 36);
            this.tbMatkhaumoi.TabIndex = 1;
            this.tbMatkhaumoi.TextOffset = new System.Drawing.Point(8, 0);
            this.tbMatkhaumoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // tbNhaplaimatkhau
            // 
            this.tbNhaplaimatkhau.Animated = true;
            this.tbNhaplaimatkhau.AutoRoundedCorners = true;
            this.tbNhaplaimatkhau.BorderRadius = 17;
            this.tbNhaplaimatkhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNhaplaimatkhau.DefaultText = "";
            this.tbNhaplaimatkhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNhaplaimatkhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNhaplaimatkhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNhaplaimatkhau.DisabledState.Parent = this.tbNhaplaimatkhau;
            this.tbNhaplaimatkhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNhaplaimatkhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNhaplaimatkhau.FocusedState.Parent = this.tbNhaplaimatkhau;
            this.tbNhaplaimatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNhaplaimatkhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNhaplaimatkhau.HoverState.Parent = this.tbNhaplaimatkhau;
            this.tbNhaplaimatkhau.Location = new System.Drawing.Point(35, 188);
            this.tbNhaplaimatkhau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbNhaplaimatkhau.Name = "tbNhaplaimatkhau";
            this.tbNhaplaimatkhau.PasswordChar = '\0';
            this.tbNhaplaimatkhau.PlaceholderText = "Nhập lại mật khẩu mới";
            this.tbNhaplaimatkhau.SelectedText = "";
            this.tbNhaplaimatkhau.ShadowDecoration.Parent = this.tbNhaplaimatkhau;
            this.tbNhaplaimatkhau.Size = new System.Drawing.Size(251, 36);
            this.tbNhaplaimatkhau.TabIndex = 2;
            this.tbNhaplaimatkhau.TextOffset = new System.Drawing.Point(8, 0);
            this.tbNhaplaimatkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FillColor = System.Drawing.Color.Transparent;
            this.btnDong.HoverState.Parent = this.btnDong;
            this.btnDong.IconColor = System.Drawing.Color.Gray;
            this.btnDong.Location = new System.Drawing.Point(273, 1);
            this.btnDong.Name = "btnDong";
            this.btnDong.ShadowDecoration.Parent = this.btnDong;
            this.btnDong.Size = new System.Drawing.Size(48, 29);
            this.btnDong.TabIndex = 102;
            // 
            // frmDoimatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(321, 311);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tbNhaplaimatkhau);
            this.Controls.Add(this.tbMatkhaumoi);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.tbMatkhaucu);
            this.Controls.Add(this.btnLuu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoimatkhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2TextBox tbMatkhaucu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2TextBox tbNhaplaimatkhau;
        private Guna.UI2.WinForms.Guna2TextBox tbMatkhaumoi;
        private Guna.UI2.WinForms.Guna2ControlBox btnDong;
    }
}