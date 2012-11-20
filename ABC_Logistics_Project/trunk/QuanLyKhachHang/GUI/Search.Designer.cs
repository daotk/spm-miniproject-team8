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
            this.lbltukhoa = new System.Windows.Forms.Label();
            this.txttukhoa = new System.Windows.Forms.TextBox();
            this.lbltimkiemtheo = new System.Windows.Forms.Label();
            this.cboxtimkiemtheo = new System.Windows.Forms.ComboBox();
            this.rdagent = new System.Windows.Forms.RadioButton();
            this.rdkhachhang = new System.Windows.Forms.RadioButton();
            this.rddoitac = new System.Windows.Forms.RadioButton();
            this.grdtimkiem = new System.Windows.Forms.DataGridView();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdtimkiem)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltukhoa
            // 
            this.lbltukhoa.AutoSize = true;
            this.lbltukhoa.Location = new System.Drawing.Point(63, 41);
            this.lbltukhoa.Name = "lbltukhoa";
            this.lbltukhoa.Size = new System.Drawing.Size(48, 13);
            this.lbltukhoa.TabIndex = 0;
            this.lbltukhoa.Text = "&Từ Khoá";
            // 
            // txttukhoa
            // 
            this.txttukhoa.Location = new System.Drawing.Point(134, 38);
            this.txttukhoa.Name = "txttukhoa";
            this.txttukhoa.Size = new System.Drawing.Size(220, 20);
            this.txttukhoa.TabIndex = 1;
            this.txttukhoa.Text = "nhập từ khoá tìm kiếm";
            // 
            // lbltimkiemtheo
            // 
            this.lbltimkiemtheo.AutoSize = true;
            this.lbltimkiemtheo.Location = new System.Drawing.Point(420, 41);
            this.lbltimkiemtheo.Name = "lbltimkiemtheo";
            this.lbltimkiemtheo.Size = new System.Drawing.Size(73, 13);
            this.lbltimkiemtheo.TabIndex = 2;
            this.lbltimkiemtheo.Text = "Tìm kiếm theo";
            // 
            // cboxtimkiemtheo
            // 
            this.cboxtimkiemtheo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxtimkiemtheo.FormattingEnabled = true;
            this.cboxtimkiemtheo.Items.AddRange(new object[] {
            "mã khách hàng",
            "tên công ty"});
            this.cboxtimkiemtheo.Location = new System.Drawing.Point(518, 37);
            this.cboxtimkiemtheo.Name = "cboxtimkiemtheo";
            this.cboxtimkiemtheo.Size = new System.Drawing.Size(184, 21);
            this.cboxtimkiemtheo.TabIndex = 3;
            // 
            // rdagent
            // 
            this.rdagent.AutoSize = true;
            this.rdagent.Location = new System.Drawing.Point(165, 104);
            this.rdagent.Name = "rdagent";
            this.rdagent.Size = new System.Drawing.Size(52, 17);
            this.rdagent.TabIndex = 4;
            this.rdagent.TabStop = true;
            this.rdagent.Text = "agent";
            this.rdagent.UseVisualStyleBackColor = true;
            // 
            // rdkhachhang
            // 
            this.rdkhachhang.AutoSize = true;
            this.rdkhachhang.Location = new System.Drawing.Point(324, 104);
            this.rdkhachhang.Name = "rdkhachhang";
            this.rdkhachhang.Size = new System.Drawing.Size(82, 17);
            this.rdkhachhang.TabIndex = 5;
            this.rdkhachhang.TabStop = true;
            this.rdkhachhang.Text = "khách hàng";
            this.rdkhachhang.UseVisualStyleBackColor = true;
            // 
            // rddoitac
            // 
            this.rddoitac.AutoSize = true;
            this.rddoitac.Location = new System.Drawing.Point(506, 104);
            this.rddoitac.Name = "rddoitac";
            this.rddoitac.Size = new System.Drawing.Size(118, 17);
            this.rddoitac.TabIndex = 6;
            this.rddoitac.TabStop = true;
            this.rddoitac.Text = "đối tác khách hàng";
            this.rddoitac.UseVisualStyleBackColor = true;
            // 
            // grdtimkiem
            // 
            this.grdtimkiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdtimkiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1,
            this.column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.grdtimkiem.Location = new System.Drawing.Point(12, 154);
            this.grdtimkiem.Name = "grdtimkiem";
            this.grdtimkiem.Size = new System.Drawing.Size(837, 252);
            this.grdtimkiem.TabIndex = 7;
            // 
            // column1
            // 
            this.column1.HeaderText = "Mã công ty";
            this.column1.Name = "column1";
            // 
            // column2
            // 
            this.column2.HeaderText = "Tên giao dịch (V)";
            this.column2.Name = "column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên giao dịch (E)";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Địa chỉ";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Số điện thoại";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Số Fax";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Lĩnh vực kinh doanh";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Nhân viên quản lí";
            this.Column8.Name = "Column8";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 418);
            this.Controls.Add(this.grdtimkiem);
            this.Controls.Add(this.rddoitac);
            this.Controls.Add(this.rdkhachhang);
            this.Controls.Add(this.rdagent);
            this.Controls.Add(this.cboxtimkiemtheo);
            this.Controls.Add(this.lbltimkiemtheo);
            this.Controls.Add(this.txttukhoa);
            this.Controls.Add(this.lbltukhoa);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.grdtimkiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltukhoa;
        private System.Windows.Forms.TextBox txttukhoa;
        private System.Windows.Forms.Label lbltimkiemtheo;
        private System.Windows.Forms.ComboBox cboxtimkiemtheo;
        private System.Windows.Forms.RadioButton rdagent;
        private System.Windows.Forms.RadioButton rdkhachhang;
        private System.Windows.Forms.RadioButton rddoitac;
        private System.Windows.Forms.DataGridView grdtimkiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}