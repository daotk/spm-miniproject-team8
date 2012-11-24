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
    public partial class ViewCustomer : Form
    {
        ABCLogisticsEntities2 context = new ABCLogisticsEntities2();
        string MaKhachHang;
        Customer customer;
        public ViewCustomer(string pMaKhachHang)
        {
            MaKhachHang = pMaKhachHang;
            InitializeComponent();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            customer = (from p in context.Customers
                        where p.CustomerID == MaKhachHang
                        select p).FirstOrDefault<Customer>();
            txtMaCongTy.Text = customer.CustomerID;
            txtTenGiaoDichV.Text = customer.CompanyNameV;
            txtTenGiaoDichE.Text = customer.CompanyNameE;
            txtTenGiaoDichS.Text = customer.CompanyNameS;
            cboLinhVucKinhDoanh.SelectedText = customer.Business;
            cboCongTyChuQuan.SelectedItem = customer.Company;
            cboQuocGia.SelectedValue = customer.NationalName;
            cboTinhThanh.Text = customer.CityName;
            txtDiaChi.Text = customer.Address;
            txtSDT.Text = customer.Phone;
            txtSoFax.Text = customer.Fax;
            txtEmail.Text = customer.Email;
            txtWedsite.Text = customer.Wed;
            cboNhanVienQuanLy.SelectedValue = customer.ManagementStaff;
            

            
        }
    }
}
