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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
