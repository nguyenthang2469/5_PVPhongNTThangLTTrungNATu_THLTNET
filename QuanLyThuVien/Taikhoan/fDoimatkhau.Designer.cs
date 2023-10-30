
namespace QuanLyThuVien.Taikhoan
{
    partial class fDoimatkhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbTendangnhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXacnhan = new System.Windows.Forms.Button();
            this.btnTrolai = new System.Windows.Forms.Button();
            this.tbMatkhaucu = new System.Windows.Forms.TextBox();
            this.ckbShowhideoldpassword = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckbShowhidenewpassword = new System.Windows.Forms.CheckBox();
            this.ckbShowhideconfirmpassword = new System.Windows.Forms.CheckBox();
            this.tbMatkhaumoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbXacnhanmatkhau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // tbTendangnhap
            // 
            this.tbTendangnhap.BackColor = System.Drawing.Color.White;
            this.tbTendangnhap.Enabled = false;
            this.tbTendangnhap.Location = new System.Drawing.Point(258, 29);
            this.tbTendangnhap.Margin = new System.Windows.Forms.Padding(5);
            this.tbTendangnhap.Name = "tbTendangnhap";
            this.tbTendangnhap.Size = new System.Drawing.Size(301, 34);
            this.tbTendangnhap.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu cũ";
            // 
            // btnXacnhan
            // 
            this.btnXacnhan.Location = new System.Drawing.Point(258, 253);
            this.btnXacnhan.Name = "btnXacnhan";
            this.btnXacnhan.Size = new System.Drawing.Size(140, 35);
            this.btnXacnhan.TabIndex = 11;
            this.btnXacnhan.Text = "Xác nhận";
            this.btnXacnhan.UseVisualStyleBackColor = true;
            this.btnXacnhan.Click += new System.EventHandler(this.btnXacnhan_Click);
            // 
            // btnTrolai
            // 
            this.btnTrolai.Location = new System.Drawing.Point(419, 253);
            this.btnTrolai.Name = "btnTrolai";
            this.btnTrolai.Size = new System.Drawing.Size(140, 35);
            this.btnTrolai.TabIndex = 12;
            this.btnTrolai.Text = "Trở lại";
            this.btnTrolai.UseVisualStyleBackColor = true;
            this.btnTrolai.Click += new System.EventHandler(this.btnTrolai_Click);
            // 
            // tbMatkhaucu
            // 
            this.tbMatkhaucu.Location = new System.Drawing.Point(258, 86);
            this.tbMatkhaucu.Margin = new System.Windows.Forms.Padding(5);
            this.tbMatkhaucu.Name = "tbMatkhaucu";
            this.tbMatkhaucu.Size = new System.Drawing.Size(301, 34);
            this.tbMatkhaucu.TabIndex = 3;
            this.tbMatkhaucu.UseSystemPasswordChar = true;
            // 
            // ckbShowhideoldpassword
            // 
            this.ckbShowhideoldpassword.AutoSize = true;
            this.ckbShowhideoldpassword.Location = new System.Drawing.Point(569, 95);
            this.ckbShowhideoldpassword.Name = "ckbShowhideoldpassword";
            this.ckbShowhideoldpassword.Size = new System.Drawing.Size(18, 17);
            this.ckbShowhideoldpassword.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ckbShowhideoldpassword, "Hiển thị mật khẩu");
            this.ckbShowhideoldpassword.UseVisualStyleBackColor = true;
            this.ckbShowhideoldpassword.CheckedChanged += new System.EventHandler(this.ckbShowhideoldpassword_CheckedChanged);
            // 
            // ckbShowhidenewpassword
            // 
            this.ckbShowhidenewpassword.AutoSize = true;
            this.ckbShowhidenewpassword.Location = new System.Drawing.Point(569, 152);
            this.ckbShowhidenewpassword.Name = "ckbShowhidenewpassword";
            this.ckbShowhidenewpassword.Size = new System.Drawing.Size(18, 17);
            this.ckbShowhidenewpassword.TabIndex = 7;
            this.toolTip1.SetToolTip(this.ckbShowhidenewpassword, "Hiển thị mật khẩu");
            this.ckbShowhidenewpassword.UseVisualStyleBackColor = true;
            this.ckbShowhidenewpassword.CheckedChanged += new System.EventHandler(this.ckbShowhidenewpassword_CheckedChanged);
            // 
            // ckbShowhideconfirmpassword
            // 
            this.ckbShowhideconfirmpassword.AutoSize = true;
            this.ckbShowhideconfirmpassword.Location = new System.Drawing.Point(569, 209);
            this.ckbShowhideconfirmpassword.Name = "ckbShowhideconfirmpassword";
            this.ckbShowhideconfirmpassword.Size = new System.Drawing.Size(18, 17);
            this.ckbShowhideconfirmpassword.TabIndex = 10;
            this.toolTip1.SetToolTip(this.ckbShowhideconfirmpassword, "Hiển thị mật khẩu");
            this.ckbShowhideconfirmpassword.UseVisualStyleBackColor = true;
            this.ckbShowhideconfirmpassword.CheckedChanged += new System.EventHandler(this.ckbShowhideconfirmpassword_CheckedChanged);
            // 
            // tbMatkhaumoi
            // 
            this.tbMatkhaumoi.Location = new System.Drawing.Point(258, 143);
            this.tbMatkhaumoi.Margin = new System.Windows.Forms.Padding(5);
            this.tbMatkhaumoi.Name = "tbMatkhaumoi";
            this.tbMatkhaumoi.Size = new System.Drawing.Size(301, 34);
            this.tbMatkhaumoi.TabIndex = 6;
            this.tbMatkhaumoi.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mật khẩu mới";
            // 
            // tbXacnhanmatkhau
            // 
            this.tbXacnhanmatkhau.Location = new System.Drawing.Point(258, 200);
            this.tbXacnhanmatkhau.Margin = new System.Windows.Forms.Padding(5);
            this.tbXacnhanmatkhau.Name = "tbXacnhanmatkhau";
            this.tbXacnhanmatkhau.Size = new System.Drawing.Size(301, 34);
            this.tbXacnhanmatkhau.TabIndex = 9;
            this.tbXacnhanmatkhau.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Xác nhận mật khẩu";
            // 
            // fDoimatkhau
            // 
            this.AcceptButton = this.btnXacnhan;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 308);
            this.Controls.Add(this.ckbShowhideconfirmpassword);
            this.Controls.Add(this.tbXacnhanmatkhau);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckbShowhidenewpassword);
            this.Controls.Add(this.tbMatkhaumoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckbShowhideoldpassword);
            this.Controls.Add(this.btnTrolai);
            this.Controls.Add(this.btnXacnhan);
            this.Controls.Add(this.tbMatkhaucu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTendangnhap);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "fDoimatkhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTendangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXacnhan;
        private System.Windows.Forms.Button btnTrolai;
        private System.Windows.Forms.TextBox tbMatkhaucu;
        private System.Windows.Forms.CheckBox ckbShowhideoldpassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ckbShowhidenewpassword;
        private System.Windows.Forms.TextBox tbMatkhaumoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckbShowhideconfirmpassword;
        private System.Windows.Forms.TextBox tbXacnhanmatkhau;
        private System.Windows.Forms.Label label4;
    }
}