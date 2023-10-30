
namespace QuanLyThuVien
{
    partial class fDangnhap
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
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.tbMatkhau = new System.Windows.Forms.TextBox();
            this.ckbShowhidepassword = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbQuenmatkhau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // tbTendangnhap
            // 
            this.tbTendangnhap.Location = new System.Drawing.Point(164, 25);
            this.tbTendangnhap.Margin = new System.Windows.Forms.Padding(5);
            this.tbTendangnhap.Name = "tbTendangnhap";
            this.tbTendangnhap.Size = new System.Drawing.Size(301, 28);
            this.tbTendangnhap.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu";
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.Location = new System.Drawing.Point(164, 116);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(140, 40);
            this.btnDangnhap.TabIndex = 5;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(325, 116);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(140, 40);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // tbMatkhau
            // 
            this.tbMatkhau.Location = new System.Drawing.Point(164, 71);
            this.tbMatkhau.Margin = new System.Windows.Forms.Padding(5);
            this.tbMatkhau.Name = "tbMatkhau";
            this.tbMatkhau.Size = new System.Drawing.Size(301, 28);
            this.tbMatkhau.TabIndex = 3;
            this.tbMatkhau.UseSystemPasswordChar = true;
            // 
            // ckbShowhidepassword
            // 
            this.ckbShowhidepassword.AutoSize = true;
            this.ckbShowhidepassword.Location = new System.Drawing.Point(475, 81);
            this.ckbShowhidepassword.Name = "ckbShowhidepassword";
            this.ckbShowhidepassword.Size = new System.Drawing.Size(15, 14);
            this.ckbShowhidepassword.TabIndex = 4;
            this.toolTip1.SetToolTip(this.ckbShowhidepassword, "Hiển thị mật khẩu");
            this.ckbShowhidepassword.UseVisualStyleBackColor = true;
            this.ckbShowhidepassword.CheckedChanged += new System.EventHandler(this.ckbShowhidepassword_CheckedChanged);
            // 
            // lbQuenmatkhau
            // 
            this.lbQuenmatkhau.AutoSize = true;
            this.lbQuenmatkhau.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbQuenmatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuenmatkhau.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbQuenmatkhau.Location = new System.Drawing.Point(164, 165);
            this.lbQuenmatkhau.Name = "lbQuenmatkhau";
            this.lbQuenmatkhau.Size = new System.Drawing.Size(139, 24);
            this.lbQuenmatkhau.TabIndex = 7;
            this.lbQuenmatkhau.Text = "Quên mật khẩu";
            this.lbQuenmatkhau.Click += new System.EventHandler(this.lbQuenmatkhau_Click);
            // 
            // fDangnhap
            // 
            this.AcceptButton = this.btnDangnhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 208);
            this.Controls.Add(this.lbQuenmatkhau);
            this.Controls.Add(this.ckbShowhidepassword);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.tbMatkhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTendangnhap);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "fDangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fDangnhap_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTendangnhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox tbMatkhau;
        private System.Windows.Forms.CheckBox ckbShowhidepassword;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbQuenmatkhau;
    }
}

