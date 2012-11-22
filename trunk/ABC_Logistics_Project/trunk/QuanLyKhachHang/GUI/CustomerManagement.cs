using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachHang.DA;

namespace QuanLyKhachHang.GUI
{
    public partial class CustomerManagement : Form
    {

        ABCLogisticsEntities context = new ABCLogisticsEntities();
        public CustomerManagement()
        {
            InitializeComponent();
        }
        bool Status = false;


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddNewCustomer NewCustomer = new AddNewCustomer();
            NewCustomer.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EditCustomer EditCustomer = new EditCustomer();
            EditCustomer.Show();
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



        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditCustomer Fedit = new EditCustomer();
            Fedit.ShowDialog();

        }
        /// <summary>
        /// Xử lý chọn hết text trong ô tìm kiếm khi chọn vào nó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
        }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            var cus = from p in context.Customers select new { p.CustomerID, p.CompanyNameV, p.CompanyNameE, p.Address, p.Phone, p.Business, p.ManagementStaff };

            dataGridView1.DataSource = cus.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewCustomer Fadd = new AddNewCustomer();
            Fadd.ShowDialog();
        }





    }
}