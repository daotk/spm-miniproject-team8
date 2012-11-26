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
    public partial class EditCustomer : Form
    {
        ABCLogisticEntities context = new ABCLogisticEntities();
        KhachHangTa customer;
        string MaKhachHang;
        public EditCustomer(string makh)
        {
            MaKhachHang = makh;
            InitializeComponent();
            EditCustomer_LoadCustomer();
        }

        public EditCustomer()
        {   
            InitializeComponent();
           
        }

        /// <summary>
        /// xủ lý sự kiện khi nhấp nút hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Mở form search khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
                Search FSearch = new Search();
                FSearch.ShowDialog();
               
        }
        /// <summary>
        /// xử lý sự kiện khi nhấp nút cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCustomer_LoadCustomer()
        {
            customer = (from p in context.KhachHangTas
                        where p.MaCongTy == MaKhachHang
                        select p).FirstOrDefault<KhachHangTa>();
            txtMaCongTy.Text = customer.MaCongTy;
            txtTenGiaoDichV.Text = customer.TenCTyV;
            txtTenGiaoDichE.Text = customer.TenCTyE;
            txtTenGiaoDichS.Text = customer.TenCTyVT;
            cboLinhVucKinhDoanh.SelectedText = customer.MaLVKD.ToString();
            txtCongTyChuQuan.SelectedText = customer.CongTyChuQuan;
            txtDiaChi.Text = customer.DiaChi;
            txtSDT.Text = customer.Sdt.ToString();
            txtSoFax.Text = customer.Fax.ToString();
            txtEmail.Text = customer.Email;
            txtWed.Text = customer.Web;
            cboNhanVienQuanLy.SelectedValue = customer.MaNhanVienQuanLy;
        }

       


    }
}
