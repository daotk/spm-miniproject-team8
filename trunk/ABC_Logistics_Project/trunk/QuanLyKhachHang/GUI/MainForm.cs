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
            //button5.Show();
            //button5.Image = global::QuanLyKhachHang.Properties.Resources.boss_icon;
            //button5.Text = "Quản lý thông tin khách hàng";
            
            //button6.Show();
            //button6.Image = global::QuanLyKhachHang.Properties.Resources.boss_icon;
            //button6.Text = "Xem thông tin đối tác của khách hàng";
            
            //button7.Show();
            //button7.Image = global::QuanLyKhachHang.Properties.Resources.boss_icon;
            //button7.Text = "Xem thông tin Agent";

            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();

            CustomerManagement Cus = new CustomerManagement();
            Cus.Show();

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
        /// <summary>
        /// xử lý sự kiện khi nhấn nút hệ thống báo cáo trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            button9.Image = global::QuanLyKhachHang.Properties.Resources.statistics_icon;
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
        /// <summary>
        /// xử lý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Quản lý thông tin khách hàng")
            {
                CustomerManagement FCustomerManagement = new CustomerManagement();
                FCustomerManagement.ShowDialog();
            }
            else
            { 
                
            }
        }
        /// <summary>
        /// sử lý sự kiện khi nhấn nút Quản lý Công nợ trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuanLyCongNo(object sender, EventArgs e)
        {
            //
            button5.Image = global::QuanLyKhachHang.Properties.Resources.license_management_icon;
            button5.Text = "Quản lý Billing Costing";
            button5.Show();

            button6.Image = global::QuanLyKhachHang.Properties.Resources.card_debit_icon;
            button6.Text = "Debit note";
            button6.Show();

            button7.Image = global::QuanLyKhachHang.Properties.Resources.personal_loan_icon;
            button7.Text = "Quản lý Proposal of Rebate";
            button7.Show();
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
            //
            button5.Image = global::QuanLyKhachHang.Properties.Resources.document_quote_icon;
            button5.Text = "Quản lý báo giá";
            button5.Show();

            button6.Image = global::QuanLyKhachHang.Properties.Resources.competitors_icon;
            button6.Text = "Quản lý booking";
            button6.Show();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
        }
        /// <summary>
        /// Đồng hồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// Xử lý sự kiện khi nhấp vào button Quản trị hệ thống trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuanTriHeThong(object sender, EventArgs e)
        {
            button5.Text = "Thêm mới người dùng";
            button5.Image = global::QuanLyKhachHang.Properties.Resources.user_male_add_icon;
            button5.Show();

            button6.Image = global::QuanLyKhachHang.Properties.Resources.Groups_Meeting_Light_icon;
            button6.Text = "Thêm mới nhóm người dùng";
            button6.Show();

            button7.Image = global::QuanLyKhachHang.Properties.Resources.check_user_icon;
            button7.Text = "Phân quyền người dùng";
            button7.Show();

            button8.Image = global::QuanLyKhachHang.Properties.Resources.dollar_folder_icon;
            button8.Text = "Thiết lập loại đồng tiền chính trong hệ thống";
            button8.Show();

            button9.Image = global::QuanLyKhachHang.Properties.Resources.conversion_of_currency_icon;
            button9.Text = "Thiết lập tỉ giá quy đổi";
            button9.Show();
        }
        /// <summary>
        /// Menu about
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm Quản Lý Kinh Doanh - Team 08 - K16T01 - DH Văn Lang");
        }
        /// <summary>
        /// xử lý sự kiện khi nhấp nút trang chính trên giao diện chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            //Hide button
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button8.Hide();
            button9.Hide();
            button10.Hide();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

      

       


      

     
    }
}
