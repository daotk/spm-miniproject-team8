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
        ABCLogisticEntities1 context = new ABCLogisticEntities1();
        string MaKhachHang;
        KhachHang customer;
        public ViewCustomer(string pMaKhachHang)
        {
            MaKhachHang = pMaKhachHang;
            InitializeComponent();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            customer = (from p in context.KhachHangs
                        where p.MaCongTy == MaKhachHang
                        select p).FirstOrDefault<KhachHang>();
            txtMaCongTy.Text = customer.MaCongTy;
            txtTenGiaoDichV.Text = customer.TenCTyV;
            txtTenGiaoDichE.Text = customer.TenCTyE;
            txtTenGiaoDichS.Text = customer.TenCTyVietTat;
            cboLinhVucKinhDoanh.SelectedText = customer.LinhVucKinhDoanh;
            cboCongTyChuQuan.SelectedItem = customer.CongTyChuQuan;
            cboQuocGia.SelectedValue = customer.TenQuocGia;
            cboTinhThanh.Text = customer.TinhThanh;
            txtDiaChi.Text = customer.DiaChi;
            txtSDT.Text = customer.Sdt.ToString();
            txtSoFax.Text = customer.Fax.ToString();
            txtEmail.Text = customer.Email;
            txtWedsite.Text = customer.Web;
            cboNhanVienQuanLy.SelectedValue = customer.MaNhanVien;
            
     
        }
    }
}
