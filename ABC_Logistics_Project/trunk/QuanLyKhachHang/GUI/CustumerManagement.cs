﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI
{
    public partial class CustumerManagement : Form
    {
        public CustumerManagement()
        {
            InitializeComponent();
        }

   

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
            EditCustomer.ShowDialog();
        }
    }
}
