namespace QuanLyKhachHang.GUI
{
    partial class MainForm
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
            this.quảnTrịHệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHảngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMớiKháchHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKinhDoanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // quảnTrịHệThốngToolStripMenuItem
            // 
            this.quảnTrịHệThốngToolStripMenuItem.Name = "quảnTrịHệThốngToolStripMenuItem";
            this.quảnTrịHệThốngToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.quảnTrịHệThốngToolStripMenuItem.Text = "Quản trị hệ thống";
            // 
            // quảnLýKháchHảngToolStripMenuItem
            // 
            this.quảnLýKháchHảngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmMớiKháchHangToolStripMenuItem});
            this.quảnLýKháchHảngToolStripMenuItem.Name = "quảnLýKháchHảngToolStripMenuItem";
            this.quảnLýKháchHảngToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.quảnLýKháchHảngToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHảngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHảngToolStripMenuItem_Click);
            // 
            // thêmMớiKháchHangToolStripMenuItem
            // 
            this.thêmMớiKháchHangToolStripMenuItem.Name = "thêmMớiKháchHangToolStripMenuItem";
            this.thêmMớiKháchHangToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.thêmMớiKháchHangToolStripMenuItem.Text = "Thêm mới khách hang";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // hệThốngBáoCáoToolStripMenuItem
            // 
            this.hệThốngBáoCáoToolStripMenuItem.Name = "hệThốngBáoCáoToolStripMenuItem";
            this.hệThốngBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.hệThốngBáoCáoToolStripMenuItem.Text = "Hệ thống báo cáo";
            // 
            // quảnLýKinhDoanhToolStripMenuItem
            // 
            this.quảnLýKinhDoanhToolStripMenuItem.Name = "quảnLýKinhDoanhToolStripMenuItem";
            this.quảnLýKinhDoanhToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.quảnLýKinhDoanhToolStripMenuItem.Text = "Quản lý kinh doanh";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnTrịHệThốngToolStripMenuItem,
            this.quảnLýKháchHảngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.hệThốngBáoCáoToolStripMenuItem,
            this.quảnLýKinhDoanhToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(838, 318);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Khách Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem quảnTrịHệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHảngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiKháchHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hệThốngBáoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKinhDoanhToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;


    }
}