namespace QuanLyKhachHang.GUI
{
    partial class Search
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.lbltukhoa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lbltimkiemtheo = new System.Windows.Forms.Label();
            this.cboTimKiemTheo = new System.Windows.Forms.ComboBox();
            this.rdAgent = new System.Windows.Forms.RadioButton();
            this.rdKhachHang = new System.Windows.Forms.RadioButton();
            this.rdDoiTacKhachHang = new System.Windows.Forms.RadioButton();
            this.grdtimkiem = new System.Windows.Forms.DataGridView();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhThanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdtimkiem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltukhoa
            // 
            this.lbltukhoa.AutoSize = true;
            this.lbltukhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltukhoa.Location = new System.Drawing.Point(261, 41);
            this.lbltukhoa.Name = "lbltukhoa";
            this.lbltukhoa.Size = new System.Drawing.Size(58, 16);
            this.lbltukhoa.TabIndex = 0;
            this.lbltukhoa.Text = "Từ Khoá";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(364, 38);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(220, 22);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.Text = "Nhập từ khoá tìm kiếm";
            this.txtTimKiem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txttukhoa_TextChanged);
            // 
            // lbltimkiemtheo
            // 
            this.lbltimkiemtheo.AutoSize = true;
            this.lbltimkiemtheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimkiemtheo.Location = new System.Drawing.Point(629, 41);
            this.lbltimkiemtheo.Name = "lbltimkiemtheo";
            this.lbltimkiemtheo.Size = new System.Drawing.Size(92, 16);
            this.lbltimkiemtheo.TabIndex = 2;
            this.lbltimkiemtheo.Text = "Tìm kiếm theo";
            // 
            // cboTimKiemTheo
            // 
            this.cboTimKiemTheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimKiemTheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTimKiemTheo.FormattingEnabled = true;
            this.cboTimKiemTheo.Items.AddRange(new object[] {
            "Mã Khách hàng",
            "Tên khách hàng"});
            this.cboTimKiemTheo.Location = new System.Drawing.Point(766, 36);
            this.cboTimKiemTheo.Name = "cboTimKiemTheo";
            this.cboTimKiemTheo.Size = new System.Drawing.Size(184, 24);
            this.cboTimKiemTheo.TabIndex = 3;
            // 
            // rdAgent
            // 
            this.rdAgent.AutoSize = true;
            this.rdAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAgent.Location = new System.Drawing.Point(553, 104);
            this.rdAgent.Name = "rdAgent";
            this.rdAgent.Size = new System.Drawing.Size(61, 20);
            this.rdAgent.TabIndex = 4;
            this.rdAgent.TabStop = true;
            this.rdAgent.Text = "Agent";
            this.rdAgent.UseVisualStyleBackColor = true;
            this.rdAgent.CheckedChanged += new System.EventHandler(this.rdAgent_CheckedChanged);
            // 
            // rdKhachHang
            // 
            this.rdKhachHang.AutoSize = true;
            this.rdKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdKhachHang.Location = new System.Drawing.Point(373, 104);
            this.rdKhachHang.Name = "rdKhachHang";
            this.rdKhachHang.Size = new System.Drawing.Size(96, 20);
            this.rdKhachHang.TabIndex = 5;
            this.rdKhachHang.TabStop = true;
            this.rdKhachHang.Text = "Khách hàng";
            this.rdKhachHang.UseVisualStyleBackColor = true;
            this.rdKhachHang.CheckedChanged += new System.EventHandler(this.rdKhachHang_CheckedChanged);
            // 
            // rdDoiTacKhachHang
            // 
            this.rdDoiTacKhachHang.AutoSize = true;
            this.rdDoiTacKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdDoiTacKhachHang.Location = new System.Drawing.Point(698, 104);
            this.rdDoiTacKhachHang.Name = "rdDoiTacKhachHang";
            this.rdDoiTacKhachHang.Size = new System.Drawing.Size(139, 20);
            this.rdDoiTacKhachHang.TabIndex = 6;
            this.rdDoiTacKhachHang.TabStop = true;
            this.rdDoiTacKhachHang.Text = "Đối tác khách hàng";
            this.rdDoiTacKhachHang.UseVisualStyleBackColor = true;
            this.rdDoiTacKhachHang.CheckedChanged += new System.EventHandler(this.rdDoiTacKhachHang_CheckedChanged);
            // 
            // grdtimkiem
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdtimkiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdtimkiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdtimkiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1,
            this.column2,
            this.Column4,
            this.TinhThanh,
            this.QuocGia,
            this.Column5,
            this.Column7,
            this.Column8});
            this.grdtimkiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grdtimkiem.Location = new System.Drawing.Point(0, 139);
            this.grdtimkiem.MultiSelect = false;
            this.grdtimkiem.Name = "grdtimkiem";
            this.grdtimkiem.ReadOnly = true;
            this.grdtimkiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdtimkiem.Size = new System.Drawing.Size(1211, 298);
            this.grdtimkiem.TabIndex = 7;
            this.grdtimkiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // column1
            // 
            this.column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column1.DataPropertyName = "MaCongTy";
            this.column1.HeaderText = "Mã khách hàng";
            this.column1.Name = "column1";
            this.column1.ReadOnly = true;
            // 
            // column2
            // 
            this.column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column2.DataPropertyName = "TenCTyV";
            this.column2.HeaderText = "Tên giao dịch (V)";
            this.column2.Name = "column2";
            this.column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "DiaChi";
            this.Column4.HeaderText = "Địa chỉ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // TinhThanh
            // 
            this.TinhThanh.DataPropertyName = "TenTinhThanh";
            this.TinhThanh.HeaderText = "Tỉnh Thành";
            this.TinhThanh.Name = "TinhThanh";
            this.TinhThanh.ReadOnly = true;
            // 
            // QuocGia
            // 
            this.QuocGia.DataPropertyName = "TenQuocGia";
            this.QuocGia.HeaderText = "Quốc Gia";
            this.QuocGia.Name = "QuocGia";
            this.QuocGia.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Sdt";
            this.Column5.HeaderText = "Số điện thoại";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "TenLVKD";
            this.Column7.HeaderText = "Lĩnh vực kinh doanh";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.DataPropertyName = "HovTen";
            this.Column8.HeaderText = "Nhân viên quản lí";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1211, 437);
            this.Controls.Add(this.grdtimkiem);
            this.Controls.Add(this.rdDoiTacKhachHang);
            this.Controls.Add(this.rdKhachHang);
            this.Controls.Add(this.rdAgent);
            this.Controls.Add(this.cboTimKiemTheo);
            this.Controls.Add(this.lbltimkiemtheo);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lbltukhoa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdtimkiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltukhoa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lbltimkiemtheo;
        private System.Windows.Forms.ComboBox cboTimKiemTheo;
        private System.Windows.Forms.RadioButton rdAgent;
        private System.Windows.Forms.RadioButton rdKhachHang;
        private System.Windows.Forms.RadioButton rdDoiTacKhachHang;
        private System.Windows.Forms.DataGridView grdtimkiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhThanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}