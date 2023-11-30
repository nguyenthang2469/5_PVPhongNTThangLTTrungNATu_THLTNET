
namespace QuanLyThuVien.Taikhoan
{
    partial class frmQuanlytacgia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanlytacgia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbSonguoidung = new System.Windows.Forms.Label();
            this.btnTimkiem = new Guna.UI2.WinForms.Guna2Button();
            this.tbTimkiem = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnLast = new Guna.UI2.WinForms.Guna2Button();
            this.dgvTacgia = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatacgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTentacgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFirst = new Guna.UI2.WinForms.Guna2Button();
            this.btnAfter = new Guna.UI2.WinForms.Guna2Button();
            this.btnBefore = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSohang = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbChimuc = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.tbTentacgia = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbMatacgia = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnXuatexcel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacgia)).BeginInit();
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
            this.lbSonguoidung.Location = new System.Drawing.Point(23, 14);
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
            this.btnTimkiem.Location = new System.Drawing.Point(649, 127);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.ShadowDecoration.Parent = this.btnTimkiem;
            this.btnTimkiem.Size = new System.Drawing.Size(80, 30);
            this.btnTimkiem.TabIndex = 11;
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
            this.tbTimkiem.Location = new System.Drawing.Point(356, 124);
            this.tbTimkiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTimkiem.Name = "tbTimkiem";
            this.tbTimkiem.PasswordChar = '\0';
            this.tbTimkiem.PlaceholderText = "Nhập từ khóa";
            this.tbTimkiem.SelectedText = "";
            this.tbTimkiem.ShadowDecoration.BorderRadius = 4;
            this.tbTimkiem.ShadowDecoration.Parent = this.tbTimkiem;
            this.tbTimkiem.Size = new System.Drawing.Size(283, 36);
            this.tbTimkiem.TabIndex = 10;
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
            this.btnLast.Location = new System.Drawing.Point(682, 8);
            this.btnLast.Name = "btnLast";
            this.btnLast.ShadowDecoration.Parent = this.btnLast;
            this.btnLast.Size = new System.Drawing.Size(46, 30);
            this.btnLast.TabIndex = 17;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // dgvTacgia
            // 
            this.dgvTacgia.AllowUserToAddRows = false;
            this.dgvTacgia.AllowUserToDeleteRows = false;
            this.dgvTacgia.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvTacgia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTacgia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dgvTacgia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTacgia.BackgroundColor = System.Drawing.Color.White;
            this.dgvTacgia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTacgia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTacgia.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2, 6, 2, 6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTacgia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTacgia.ColumnHeadersHeight = 40;
            this.dgvTacgia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMatacgia,
            this.colTentacgia});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTacgia.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTacgia.EnableHeadersVisualStyles = false;
            this.dgvTacgia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacgia.Location = new System.Drawing.Point(27, 6);
            this.dgvTacgia.Margin = new System.Windows.Forms.Padding(3, 3, 3, 50);
            this.dgvTacgia.MultiSelect = false;
            this.dgvTacgia.Name = "dgvTacgia";
            this.dgvTacgia.ReadOnly = true;
            this.dgvTacgia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTacgia.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTacgia.RowHeadersVisible = false;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTacgia.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTacgia.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dgvTacgia.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 6, 2, 6);
            this.dgvTacgia.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacgia.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvTacgia.RowTemplate.Height = 38;
            this.dgvTacgia.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTacgia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTacgia.Size = new System.Drawing.Size(701, 333);
            this.dgvTacgia.TabIndex = 12;
            this.dgvTacgia.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvTacgia.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTacgia.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvTacgia.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvTacgia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvTacgia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvTacgia.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvTacgia.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacgia.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.dgvTacgia.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTacgia.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTacgia.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTacgia.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvTacgia.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvTacgia.ThemeStyle.ReadOnly = true;
            this.dgvTacgia.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvTacgia.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTacgia.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTacgia.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvTacgia.ThemeStyle.RowsStyle.Height = 38;
            this.dgvTacgia.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTacgia.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvTacgia.SelectionChanged += new System.EventHandler(this.dgvTacgia_SelectionChanged);
            // 
            // colSTT
            // 
            this.colSTT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSTT.DataPropertyName = "stt";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSTT.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSTT.Width = 66;
            // 
            // colMatacgia
            // 
            this.colMatacgia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMatacgia.DataPropertyName = "matacgia";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colMatacgia.DefaultCellStyle = dataGridViewCellStyle4;
            this.colMatacgia.HeaderText = "Mã tác giả";
            this.colMatacgia.MinimumWidth = 80;
            this.colMatacgia.Name = "colMatacgia";
            this.colMatacgia.ReadOnly = true;
            this.colMatacgia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTentacgia
            // 
            this.colTentacgia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTentacgia.DataPropertyName = "tentacgia";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colTentacgia.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTentacgia.HeaderText = "Tên tác giả";
            this.colTentacgia.Name = "colTentacgia";
            this.colTentacgia.ReadOnly = true;
            this.colTentacgia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.btnFirst.Location = new System.Drawing.Point(457, 9);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.ShadowDecoration.Parent = this.btnFirst;
            this.btnFirst.Size = new System.Drawing.Size(46, 30);
            this.btnFirst.TabIndex = 14;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFist_Click);
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
            this.btnAfter.Location = new System.Drawing.Point(622, 8);
            this.btnAfter.Name = "btnAfter";
            this.btnAfter.ShadowDecoration.Parent = this.btnAfter;
            this.btnAfter.Size = new System.Drawing.Size(46, 30);
            this.btnAfter.TabIndex = 16;
            this.btnAfter.Text = ">";
            this.btnAfter.Click += new System.EventHandler(this.btnAfter_Click);
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
            this.btnBefore.Location = new System.Drawing.Point(517, 9);
            this.btnBefore.Name = "btnBefore";
            this.btnBefore.ShadowDecoration.Parent = this.btnBefore;
            this.btnBefore.Size = new System.Drawing.Size(46, 30);
            this.btnBefore.TabIndex = 15;
            this.btnBefore.Text = "<";
            this.btnBefore.Click += new System.EventHandler(this.btnBefore_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(272, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số hàng";
            // 
            // cbSohang
            // 
            this.cbSohang.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbSohang.Animated = true;
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
            this.cbSohang.Location = new System.Drawing.Point(356, 6);
            this.cbSohang.Name = "cbSohang";
            this.cbSohang.ShadowDecoration.Parent = this.cbSohang;
            this.cbSohang.Size = new System.Drawing.Size(85, 36);
            this.cbSohang.TabIndex = 13;
            this.cbSohang.SelectedIndexChanged += new System.EventHandler(this.cbSohang_SelectedIndexChanged);
            // 
            // lbChimuc
            // 
            this.lbChimuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbChimuc.AutoSize = true;
            this.lbChimuc.BackColor = System.Drawing.Color.Transparent;
            this.lbChimuc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbChimuc.Location = new System.Drawing.Point(577, 13);
            this.lbChimuc.Name = "lbChimuc";
            this.lbChimuc.Size = new System.Drawing.Size(31, 20);
            this.lbChimuc.TabIndex = 15;
            this.lbChimuc.Text = "0/0";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.btnXuatexcel);
            this.guna2Panel1.Controls.Add(this.tbTimkiem);
            this.guna2Panel1.Controls.Add(this.btnTimkiem);
            this.guna2Panel1.Controls.Add(this.btnSua);
            this.guna2Panel1.Controls.Add(this.tbTentacgia);
            this.guna2Panel1.Controls.Add(this.tbMatacgia);
            this.guna2Panel1.Controls.Add(this.btnXoa);
            this.guna2Panel1.Controls.Add(this.btnThem);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(750, 175);
            this.guna2Panel1.TabIndex = 2;
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
            this.btnSua.Location = new System.Drawing.Point(543, 82);
            this.btnSua.Name = "btnSua";
            this.btnSua.ShadowDecoration.Parent = this.btnSua;
            this.btnSua.Size = new System.Drawing.Size(80, 30);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // tbTentacgia
            // 
            this.tbTentacgia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbTentacgia.Animated = true;
            this.tbTentacgia.AutoRoundedCorners = true;
            this.tbTentacgia.BorderRadius = 17;
            this.tbTentacgia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTentacgia.DefaultText = "";
            this.tbTentacgia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbTentacgia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTentacgia.DisabledState.Parent = this.tbTentacgia;
            this.tbTentacgia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbTentacgia.Enabled = false;
            this.tbTentacgia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTentacgia.FocusedState.Parent = this.tbTentacgia;
            this.tbTentacgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTentacgia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbTentacgia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbTentacgia.HoverState.Parent = this.tbTentacgia;
            this.tbTentacgia.Location = new System.Drawing.Point(400, 29);
            this.tbTentacgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTentacgia.Name = "tbTentacgia";
            this.tbTentacgia.PasswordChar = '\0';
            this.tbTentacgia.PlaceholderText = "";
            this.tbTentacgia.SelectedText = "";
            this.tbTentacgia.ShadowDecoration.BorderRadius = 4;
            this.tbTentacgia.ShadowDecoration.Parent = this.tbTentacgia;
            this.tbTentacgia.Size = new System.Drawing.Size(328, 36);
            this.tbTentacgia.TabIndex = 1;
            this.tbTentacgia.TextOffset = new System.Drawing.Point(8, 0);
            this.tbTentacgia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
            // 
            // tbMatacgia
            // 
            this.tbMatacgia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbMatacgia.AutoRoundedCorners = true;
            this.tbMatacgia.BorderRadius = 17;
            this.tbMatacgia.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMatacgia.DefaultText = "";
            this.tbMatacgia.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.tbMatacgia.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMatacgia.DisabledState.Parent = this.tbMatacgia;
            this.tbMatacgia.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbMatacgia.Enabled = false;
            this.tbMatacgia.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbMatacgia.FocusedState.Parent = this.tbMatacgia;
            this.tbMatacgia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatacgia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbMatacgia.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.tbMatacgia.HoverState.Parent = this.tbMatacgia;
            this.tbMatacgia.Location = new System.Drawing.Point(112, 29);
            this.tbMatacgia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbMatacgia.Name = "tbMatacgia";
            this.tbMatacgia.PasswordChar = '\0';
            this.tbMatacgia.PlaceholderText = "";
            this.tbMatacgia.SelectedText = "";
            this.tbMatacgia.ShadowDecoration.BorderRadius = 4;
            this.tbMatacgia.ShadowDecoration.Parent = this.tbMatacgia;
            this.tbMatacgia.Size = new System.Drawing.Size(167, 36);
            this.tbMatacgia.TabIndex = 0;
            this.tbMatacgia.TextOffset = new System.Drawing.Point(8, 0);
            this.tbMatacgia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter);
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
            this.btnXoa.Location = new System.Drawing.Point(648, 82);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ShadowDecoration.Parent = this.btnXoa;
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 9;
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
            this.btnThem.Location = new System.Drawing.Point(438, 82);
            this.btnThem.Name = "btnThem";
            this.btnThem.ShadowDecoration.Parent = this.btnThem;
            this.btnThem.Size = new System.Drawing.Size(80, 30);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên tác giả";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã tác giả";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.lbSonguoidung);
            this.guna2Panel2.Controls.Add(this.btnLast);
            this.guna2Panel2.Controls.Add(this.cbSohang);
            this.guna2Panel2.Controls.Add(this.btnAfter);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.btnBefore);
            this.guna2Panel2.Controls.Add(this.btnFirst);
            this.guna2Panel2.Controls.Add(this.lbChimuc);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 520);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(750, 50);
            this.guna2Panel2.TabIndex = 21;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.dgvTacgia);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 175);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(750, 345);
            this.guna2Panel3.TabIndex = 20;
            // 
            // btnXuatexcel
            // 
            this.btnXuatexcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuatexcel.Animated = true;
            this.btnXuatexcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnXuatexcel.BorderRadius = 5;
            this.btnXuatexcel.BorderThickness = 1;
            this.btnXuatexcel.CheckedState.Parent = this.btnXuatexcel;
            this.btnXuatexcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuatexcel.CustomImages.Parent = this.btnXuatexcel;
            this.btnXuatexcel.FillColor = System.Drawing.Color.Transparent;
            this.btnXuatexcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatexcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(103)))), ((int)(((byte)(239)))));
            this.btnXuatexcel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnXuatexcel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(72)))), ((int)(((byte)(167)))));
            this.btnXuatexcel.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnXuatexcel.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatexcel.HoverState.Image")));
            this.btnXuatexcel.HoverState.Parent = this.btnXuatexcel;
            this.btnXuatexcel.Image = ((System.Drawing.Image)(resources.GetObject("btnXuatexcel.Image")));
            this.btnXuatexcel.ImageSize = new System.Drawing.Size(25, 25);
            this.btnXuatexcel.Location = new System.Drawing.Point(27, 127);
            this.btnXuatexcel.Name = "btnXuatexcel";
            this.btnXuatexcel.ShadowDecoration.Parent = this.btnXuatexcel;
            this.btnXuatexcel.Size = new System.Drawing.Size(80, 30);
            this.btnXuatexcel.TabIndex = 26;
            this.btnXuatexcel.Click += new System.EventHandler(this.btnXuatexcel_Click);
            // 
            // frmQuanlytacgia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 570);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmQuanlytacgia";
            this.Text = "frmQuanlysach";
            this.Load += new System.EventHandler(this.frmQuanlytacgia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacgia)).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvTacgia;
        private Guna.UI2.WinForms.Guna2Button btnAfter;
        private Guna.UI2.WinForms.Guna2ComboBox cbSohang;
        private System.Windows.Forms.Label lbChimuc;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnBefore;
        private Guna.UI2.WinForms.Guna2Button btnFirst;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2TextBox tbTentacgia;
        private Guna.UI2.WinForms.Guna2TextBox tbMatacgia;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSonguoidung;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMatacgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTentacgia;
        private Guna.UI2.WinForms.Guna2Button btnXuatexcel;
    }
}