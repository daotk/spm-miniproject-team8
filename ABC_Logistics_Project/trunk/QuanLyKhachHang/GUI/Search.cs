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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        /// <summary>
        /// tim kiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txttukhoa_TextChanged(object sender, EventArgs e)
        {
            string txttext = txttukhoa.Text;
            ABCLogisticsEntities2 context = new ABCLogisticsEntities2();
            var customer = from p in context.Customers
                           where p.CustomerID.Contains(txttext)
                           select new { p.CustomerID, p.CompanyNameV, p.CompanyNameE, p.Address, p.Phone, p.Business, p.ManagementStaff };
            grdtimkiem.DataSource = customer.ToList();
        }
    }
}
