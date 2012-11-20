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
    public partial class EditCustomer : Form
    {
   
        public EditCustomer()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Status == false)
            {
                Search FSearch = new Search();
                FSearch.Show();
                Status = true;
            }
            else
            {
                MessageBox.Show("Bạn đã mở của sổ tìm kiếm !");
            }
        }

        public bool Status { get; set; }
    }
}
