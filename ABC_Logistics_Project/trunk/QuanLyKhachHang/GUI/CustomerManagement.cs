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
    public partial class CustomerManagement : Form
    {
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

        private void CustumerManagement_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý sự kiện khi nhấn nút thêm mới khách hàng trên giao diện quản lý khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (Status == false)
            {
                AddNewCustomer FNewCustomer = new AddNewCustomer();
                FNewCustomer.Show();
                Status = true;
            }
            else
            {
                MessageBox.Show("Bạn đã mở của sổ thêm mới khách hàng rồi!");
            }
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

       
    }
}
