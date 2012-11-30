namespace QuanLyKhachHang.GUI
{
    partial class QuanLyDanhMuc
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDongHo = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnTrangChinh = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblDongHo);
            this.panel1.Controls.Add(this.lblTenNhanVien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1275, 30);
            this.panel1.TabIndex = 5;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button14.Enabled = false;
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(-1, -1);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(883, 30);
            this.button14.TabIndex = 15;
            this.button14.Text = "Quản lý bán hàng/Quản lý danh mục";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(895, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nhân viên:";
            // 
            // lblDongHo
            // 
            this.lblDongHo.AutoSize = true;
            this.lblDongHo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDongHo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDongHo.Location = new System.Drawing.Point(1180, 7);
            this.lblDongHo.Name = "lblDongHo";
            this.lblDongHo.Size = new System.Drawing.Size(70, 20);
            this.lblDongHo.TabIndex = 14;
            this.lblDongHo.Text = "Đồng hồ";
            this.lblDongHo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhanVien.Location = new System.Drawing.Point(975, 7);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(111, 20);
            this.lblTenNhanVien.TabIndex = 17;
            this.lblTenNhanVien.Text = "Nguyễn Văn A";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnTrangChinh
            // 
            this.btnTrangChinh.Image = global::QuanLyKhachHang.Properties.Resources.home_icon;
            this.btnTrangChinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTrangChinh.Location = new System.Drawing.Point(12, 12);
            this.btnTrangChinh.Name = "btnTrangChinh";
            this.btnTrangChinh.Size = new System.Drawing.Size(150, 40);
            this.btnTrangChinh.TabIndex = 6;
            this.btnTrangChinh.Text = "Trang chính";
            this.btnTrangChinh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTrangChinh.UseVisualStyleBackColor = true;
            this.btnTrangChinh.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Image = global::QuanLyKhachHang.Properties.Resources.Actions_application_exit_icon;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(530, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 40);
            this.button4.TabIndex = 7;
            this.button4.Text = "Thoát";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btnTrangChinh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1275, 65);
            this.panel2.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1275, 298);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1267, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh mục quốc gia";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1267, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Danh mục cảng vận chuyển";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1267, 272);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Danh mục các loại container";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1267, 272);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Danh mục các loại phí";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1267, 272);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Danh mục ngoại tệ";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // QuanLyDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1275, 393);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "QuanLyDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý danh mục";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuanLyDanhMuc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDongHo;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnTrangChinh;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
    }
}