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
            ABCLogisticEntities1 context = new ABCLogisticEntities1();
            var customer = from p in context.KhachHangs
                           where p.MaCongTy.Contains(txttext)
                           select new { p.MaCongTy, p.TenCTyV, p.TenCTyE, p.DiaChi, p.Sdt, p.LinhVucKinhDoanh, p.NhanVienQuanLy };
            grdtimkiem.DataSource = customer.ToList();
        }
    }
}
