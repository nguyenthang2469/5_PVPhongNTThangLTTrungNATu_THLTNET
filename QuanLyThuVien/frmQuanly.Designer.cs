
namespace QuanLyThuVien
{
    partial class frmQuanly
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNguoidung = new System.Windows.Forms.TabPage();
            this.tabThuthu = new System.Windows.Forms.TabPage();
            this.tabDocgia = new System.Windows.Forms.TabPage();
            this.tabSach = new System.Windows.Forms.TabPage();
            this.tabTacgia = new System.Windows.Forms.TabPage();
            this.tabNhaxuatban = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNguoidung);
            this.tabControl1.Controls.Add(this.tabThuthu);
            this.tabControl1.Controls.Add(this.tabDocgia);
            this.tabControl1.Controls.Add(this.tabSach);
            this.tabControl1.Controls.Add(this.tabTacgia);
            this.tabControl1.Controls.Add(this.tabNhaxuatban);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 700);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabNguoidung
            // 
            this.tabNguoidung.AutoScroll = true;
            this.tabNguoidung.BackColor = System.Drawing.Color.White;
            this.tabNguoidung.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabNguoidung.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabNguoidung.Location = new System.Drawing.Point(4, 29);
            this.tabNguoidung.Name = "tabNguoidung";
            this.tabNguoidung.Padding = new System.Windows.Forms.Padding(3);
            this.tabNguoidung.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabNguoidung.Size = new System.Drawing.Size(892, 567);
            this.tabNguoidung.TabIndex = 0;
            this.tabNguoidung.Text = "Người dùng";
            // 
            // tabThuthu
            // 
            this.tabThuthu.AutoScroll = true;
            this.tabThuthu.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabThuthu.Location = new System.Drawing.Point(4, 29);
            this.tabThuthu.Name = "tabThuthu";
            this.tabThuthu.Size = new System.Drawing.Size(892, 570);
            this.tabThuthu.TabIndex = 5;
            this.tabThuthu.Text = "Thủ thư";
            this.tabThuthu.UseVisualStyleBackColor = true;
            // 
            // tabDocgia
            // 
            this.tabDocgia.AutoScroll = true;
            this.tabDocgia.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabDocgia.Location = new System.Drawing.Point(4, 29);
            this.tabDocgia.Name = "tabDocgia";
            this.tabDocgia.Size = new System.Drawing.Size(892, 570);
            this.tabDocgia.TabIndex = 4;
            this.tabDocgia.Text = "Độc giả";
            this.tabDocgia.UseVisualStyleBackColor = true;
            // 
            // tabSach
            // 
            this.tabSach.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabSach.Location = new System.Drawing.Point(4, 29);
            this.tabSach.Name = "tabSach";
            this.tabSach.Size = new System.Drawing.Size(892, 570);
            this.tabSach.TabIndex = 3;
            this.tabSach.Text = "Sách";
            this.tabSach.UseVisualStyleBackColor = true;
            // 
            // tabTacgia
            // 
            this.tabTacgia.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabTacgia.Location = new System.Drawing.Point(4, 29);
            this.tabTacgia.Name = "tabTacgia";
            this.tabTacgia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTacgia.Size = new System.Drawing.Size(892, 570);
            this.tabTacgia.TabIndex = 1;
            this.tabTacgia.Text = "Tác giả";
            this.tabTacgia.UseVisualStyleBackColor = true;
            // 
            // tabNhaxuatban
            // 
            this.tabNhaxuatban.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabNhaxuatban.Location = new System.Drawing.Point(4, 29);
            this.tabNhaxuatban.Name = "tabNhaxuatban";
            this.tabNhaxuatban.Size = new System.Drawing.Size(892, 570);
            this.tabNhaxuatban.TabIndex = 2;
            this.tabNhaxuatban.Text = "Nhà xuất bản";
            this.tabNhaxuatban.UseVisualStyleBackColor = true;
            // 
            // frmQuanly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmQuanly";
            this.Text = "Quản lý";
            this.Load += new System.EventHandler(this.frmQuanly_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNguoidung;
        private System.Windows.Forms.TabPage tabTacgia;
        private System.Windows.Forms.TabPage tabNhaxuatban;
        private System.Windows.Forms.TabPage tabSach;
        private System.Windows.Forms.TabPage tabDocgia;
        private System.Windows.Forms.TabPage tabThuthu;
    }
}