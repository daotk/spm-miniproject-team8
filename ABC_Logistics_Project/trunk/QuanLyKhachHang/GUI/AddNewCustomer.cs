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
        ABCLogisticsEntities2 context=new ABCLogisticsEntities2();
        public AddNewCustomer()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý sự kiện khi nhấn nhút "Cancel" trong giao diện thêm mới khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            CustomerManagement Fcus = new CustomerManagement();
           
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
            p.Business = cboxLinhVucKinhDoanh.Text;
            p.Company = cboxCongTyChuQuan.Text;
            //
            if (rdAgent.Checked == true)
            {
                p.Classify = rdAgent.Text;
            }
            if (rdDoiTac.Checked == true)
            {
                p.Classify = rdDoiTac.Text;
            }
            if (rdKhachHang.Checked)
            {
                p.Classify = rdKhachHang.Text;
            }
            p.NationalName = cboxQuocGia.Text;
            p.CityName = cboxTinhThanh.Text;
            p.Address = txtDiaChiLienLac.Text;
            p.Phone = txtSdt.Text;
            p.Fax = txtSoFax.Text;
            p.Email = txtEmail.Text;
            p.Wed = txtWebsite.Text;
            p.ManagementStaff = cboxNhanVienQuanLy.Text;

            //kiem tra tính hợp lệ khi nhập từ bàn phím
            if (p.CustomerID != "" && p.CompanyNameV != "" && p.Classify != "" && p.NationalName != "" && p.CityName != "" && p.Address != "" && p.Phone != "")
            {
                context.Customers.AddObject(p);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    DialogResult result = MessageBox.Show("Ban da them thanh cong!","Thong Bao", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        CustomerManagement Fcus = new CustomerManagement();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Không thể thêm!");
                }
            }
            else
            {
                MessageBox.Show("Ban Chua nhap het!");
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
            var linhvuc = from cat in context.LinhVucKinhDoanhs
                          select cat;
            cboxLinhVucKinhDoanh.DataSource=linhvuc.ToList<LinhVucKinhDoanh>();
            cboxLinhVucKinhDoanh.DisplayMember = "TenLinhVuc";

            //doc danh sach congtychuquan tu database
            var congty = from cat in context.Customers
                         select cat;
            cboxCongTyChuQuan.DataSource=congty.ToList<Customer>();
            cboxCongTyChuQuan.DisplayMember = "Company";

            //khong cho combobox chon gia tri
            cboxCongTyChuQuan.SelectedItem = -1;
            cboxLinhVucKinhDoanh.SelectedItem = -1;
            cboxNhanVienQuanLy.SelectedItem = -1;
            cboxQuocGia.SelectedItem = -1;
            cboxTinhThanh.SelectedItem = -1;
        }

     

      

       

        

       

       
    }
}
