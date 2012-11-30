using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI
{
    public partial class QuanLyDanhMuc : Form
    {
        string StrUsername;
        public QuanLyDanhMuc(string strUsername)
        {
            StrUsername = strUsername;
            InitializeComponent();
        }

        /// <summary>
        /// Đồng hồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// trang chinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            lblTenNhanVien.Text = StrUsername;
        }

      
    }
}
