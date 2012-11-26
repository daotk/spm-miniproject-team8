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
           
            ////doc danh sach quoc gia tu database
            //var QuocGia = from cat in context.QuocGias
            //              select cat;
            //cboQuocGia.DataSource = QuocGia.ToList<QuocGia>();
          
            ////doc danh sach linh vuc kinh doanh tu database
            //var linhvuc = from cat in context.LinhVucKinhDoanhs
            //              select cat;
            //cboLinhVucKinhDoanh.DataSource = linhvuc.ToList<LinhVucKinhDoanh>();

            ////doc danh sach tinh thanh tu database
            //var tinhthanh = from cat in context.TinhThanhs
            //              select cat;
            //cboQuocGia.DataSource = tinhthanh.ToList<TinhThanh>();

            customer = (from p in context.KhachHangs
                        where p.MaCongTy == MaKhachHang
                        select p).FirstOrDefault<KhachHang>();
            txtMaCongTy.Text = customer.MaCongTy;
            txtTenGiaoDichV.Text = customer.TenCTyV;
            txtTenGiaoDichE.Text = customer.TenCTyE;
            txtTenGiaoDichS.Text = customer.TenCTyVietTat;

            cboLinhVucKinhDoanh.Items.Add(customer.LinhVucKinhDoanh);
            cboLinhVucKinhDoanh.SelectedItem = customer.LinhVucKinhDoanh;

            txtCongTyChuQuan.SelectedText = customer.CongTyChuQuan;

            if (customer.LoaiKhachHang.ToString() == "Khách hàng")
            {
                rdKhachHang.Checked = true;
            }
            if (customer.LoaiKhachHang.ToString() == "Đối tác khách hàng")
            {
                rdDoitacKhachHang.Checked = true;
            }
            if (customer.LoaiKhachHang.ToString() == "Agent")
            {
                rdAgent.Checked = true;
            }

            cboQuocGia.Items.Add(customer.TenQuocGia);
            cboQuocGia.SelectedItem = customer.TenQuocGia;

            cboTinhThanh.Items.Add(customer.TinhThanh);
            cboTinhThanh.SelectedItem = customer.TinhThanh;
            txtDiaChi.Text = customer.DiaChi;
            txtSDT.Text = customer.Sdt;
            txtSoFax.Text = customer.Fax;
            txtEmail.Text = customer.Email;
            txtWedsite.Text = customer.Web;

            cboNhanVienQuanLy.Items.Add(customer.NhanVienQuanLy);
            cboNhanVienQuanLy.SelectedItem = customer.NhanVienQuanLy;
            

        }
    }
}
