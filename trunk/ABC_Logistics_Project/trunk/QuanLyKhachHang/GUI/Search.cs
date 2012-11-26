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
        ABCLogisticEntities1 context = new ABCLogisticEntities1();
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
                           select new { p.MaCongTy, p.TenCTyV, p.DiaChi, p.TinhThanh, p.TenQuocGia, p.Sdt, p.LinhVucKinhDoanh, p.NhanVienQuanLy };
            grdtimkiem.DataSource = customer.ToList();
        }

        /// <summary>
        /// Xử lý chọn hết text trong ô tìm kiếm khi chọn vào nó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txttukhoa.SelectAll();
        }

        /// <summary>
        /// Xu ly1 khi nhap double vao 1 cell trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string makh = grdtimkiem.CurrentRow.Cells[0].Value.ToString();
            EditCustomer Fview = new EditCustomer(makh);
            Fview.ShowDialog();
          
            this.Close();

        }


    }
}
