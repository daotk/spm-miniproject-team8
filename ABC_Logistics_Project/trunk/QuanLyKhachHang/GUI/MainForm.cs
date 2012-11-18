using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace QuanLyKhachHang.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void quảnLýKháchHảngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagement cusManagement = new CustomerManagement();
           // cusManagement.MdiParent=this;
            cusManagement.ShowDialog();


        }
        /// <summary>
        /// xử lý khi load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //hide Button khi load form
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();

           
        }
        /// <summary>
        /// Xử lý sự kiện khi nhấp button Quản lý khách hàng trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuanLyKhachHang(object sender, EventArgs e)
        {
            //show button
            button5.Show();
            button5.Image = global::QuanLyKhachHang.Properties.Resources.boss_icon;
            button5.Text = "Quản lý thông tin khách hàng";
            
            button6.Show();
            button6.Image = global::QuanLyKhachHang.Properties.Resources.boss_icon;
            button6.Text = "Xem thông tin đối tác của khách hàng";
            
            button7.Show();
            button7.Image = global::QuanLyKhachHang.Properties.Resources.boss_icon;
            button7.Text = "Xem thông tin Agent";
            button8.Hide();
            button9.Hide();
            button10.Hide();
     

        }
        /// <summary>
        /// Xử lý sự kiện khi nhấp button Giao dich trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDanhMuc(object sender, EventArgs e)
        {
            //button  
            button5.Image = global::QuanLyKhachHang.Properties.Resources.Web_icon;
            button5.Text = "Danh mục quốc gia";
            button5.Show();
            
            button6.Image = global::QuanLyKhachHang.Properties.Resources.yellow_submarine_icon;
            button6.Text = "Danh mục cảng vận chuyển";
            button6.Show();

            button7.Image = global::QuanLyKhachHang.Properties.Resources.Lorry_icon;
            button7.Text = "Danh mục các loại container/ các quy chuẩn tính phí";
            button7.Show();

            button8.Image = global::QuanLyKhachHang.Properties.Resources.Money_icon;
            button8.Text = "Danh mục các loại phí";
            button8.Show();

            button9.Image = global::QuanLyKhachHang.Properties.Resources.currency_dollar_icon;
            button9.Text = "Danh mục ngoại tệ";
            button9.Show();
       
        }

        private void btnHeThongBaoCao(object sender, EventArgs e)
        {
            //button
            button5.Image = global::QuanLyKhachHang.Properties.Resources.statistics_icon;
            button5.Text = "Báo cáo tổng doanh thu theo thời kỳ";
            button5.Show();

            button6.Image = global::QuanLyKhachHang.Properties.Resources.statistics_icon;
            button6.Text = "Báo cáo tổng doanh thu theo tuyến vận chuyển";
            button6.Show();

            button7.Image = global::QuanLyKhachHang.Properties.Resources.statistics_icon;      
            button7.Text = "Báo cáo tổng doanh thu theo khách hàng";
            button7.Show();

            button8.Image = global::QuanLyKhachHang.Properties.Resources.statistics_icon;
            button8.Text = "Báo cáo thống kê";
            button8.Show();

            button5.Image = global::QuanLyKhachHang.Properties.Resources.statistics_icon;
            button9.Text = "Báo cáo thông ke doanh thu theo cước phí";
            button9.Show();

            button10.Hide();

          
        }
        /// <summary>
        /// xử lý sự kiện khi nhấn nút thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// xử lý khi đóng chương trình
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban muon thoat?", "Canh bao", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Quản lý thông tin khách hàng")
            {
                CustomerManagement FCustomerManagement = new CustomerManagement();
                FCustomerManagement.ShowDialog();
            }
        }
        /// <summary>
        /// sử lý sự kiện khi nhấn nút Quản lý Công nợ trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuanLyCongNo(object sender, EventArgs e)
        {
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
        }
        /// <summary>
        /// sử lý sự kiện khi nhấn nút Quản lý giao dich trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuanLyGiaoDich(object sender, EventArgs e)
        {
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
      

      

     
    }
}
