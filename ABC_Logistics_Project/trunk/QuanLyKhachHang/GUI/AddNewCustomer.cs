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
    public partial class AddNewCustomer : Form
    {
        ABCLogisticsEntities4 context=new ABCLogisticsEntities4();
        public AddNewCustomer()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// xu li khi nhan nut "dong y"trong giao dien tim khach hang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Customer p = new Customer();
            p.CustomerID = txtMaCongTy.Text;
            p.CompanyNameV = txtTenGiaoDichV.Text;
            p.CompanyNameE = txtTenGiaoDichE.Text;
            p.CompanyNameS = txtTenVietTat.Text;
            p.Business = (string)cboxLinhVucKinhDoanh.SelectedValue;
            p.Company = (string)cboxCongTyChuQuan.SelectedValue;
            p.Classify = rdAgent.Text;
            p.Classify = rdDoiTac.Text;
            p.Classify = rdKhachHang.Text;
            p.NationalName = (string)cboxQuocGia.SelectedValue;
            p.CityName = (string)cboxTinhThanh.SelectedValue;
            p.Address = txtDiaChiLienLac.Text;
            p.Phone = txtSdt.Text;
            p.Fax = txtSoFax.Text;
            p.Email = txtEmail.Text;
            p.Wed = txtWebsite.Text;
            p.ManagementStaff = (string)cboxNhanVienQuanLy.SelectedValue;

            context.Customers.AddObject(p);
            int count = context.SaveChanges();
            if (count > 0)
            {
                MessageBox.Show("the new customer have been addeed successfully");
                this.Close();
            }
            else 
            {
                MessageBox.Show("cannot add new customer");
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xu li khi load form trong them danh sach khach hang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewCustomer_Load(object sender, EventArgs e)
        {
            //doc danh sach ten nhan vien tu database
            var nhanvien = from cat in context.NhanViens
                           select cat;
            cboxNhanVienQuanLy.DataSource = nhanvien.ToList<NhanVien>();
            cboxNhanVienQuanLy.DisplayMember = "FirstName";
            cboxNhanVienQuanLy.ValueMember = "MaNhanVien";

            //doc danh sach quoc gia tu database
            var QuocGia = from cat in context.QuocGias
                          select cat;
            cboxQuocGia.DataSource = QuocGia.ToList<QuocGia>();
            cboxQuocGia.DisplayMember = "TenQuocGia";
            cboxQuocGia.ValueMember = "MaQuocGia";

            //doc danh sach tinh thanh tu database
            var tinhthanh = from cat in context.TinhThanhs
                            select cat;
            cboxTinhThanh.DataSource = tinhthanh.ToList<TinhThanh>();
            cboxTinhThanh.DisplayMember = "TenTinhThanh";
            cboxTinhThanh.ValueMember = "MaTinhThanh";

            //doc danh sach linh vuc kinh doanh tu database
            var linhvuc = from cat in context.Customers
                          select cat;
            cboxLinhVucKinhDoanh.DataSource=linhvuc.ToList<Customer>();
            cboxLinhVucKinhDoanh.DisplayMember = "Business";

            //doc danh sach congtychuquan tu database
            var congty = from cat in context.Customers
                         select cat;
            cboxCongTyChuQuan.DataSource=congty.ToList<Customer>();
            cboxCongTyChuQuan.DisplayMember = "Company";
        }

       

        

       

       
    }
}
