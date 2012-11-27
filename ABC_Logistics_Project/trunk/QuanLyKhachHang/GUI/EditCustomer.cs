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
            //doc danh sach quoc gia tu database
            var QuocGia = from cat in context.QuocGiaTas
                          select cat;
            cboQuocGia.DataSource = QuocGia.ToList<QuocGiaTa>();
            cboQuocGia.DisplayMember = "TenQuocGia";
            cboQuocGia.ValueMember = "MaQuocGia";

            //doc danh sach tinh thanh khi chon quoc gia
            int catID;
            Int32.TryParse(cboQuocGia.SelectedValue.ToString(), out catID);
            var tinhthanh = from p in context.TinhThanhTas
                            where p.MaQuocGia == catID
                            select p;
            cboTinhThanh.DataSource = tinhthanh.ToList<TinhThanhTa>();
            cboTinhThanh.DisplayMember = "TenTinhThanh";
            cboTinhThanh.ValueMember = "MaTinhThanh";

            //doc danh sach linh vuc kinh doanh tu database
            var linhvuc = from cat in context.LinhVucKinhDoanhTas
                          select cat;
            cboLinhVucKinhDoanh.DataSource = linhvuc.ToList<LinhVucKinhDoanhTa>();
            cboLinhVucKinhDoanh.DisplayMember = "TenLVKD";
            cboLinhVucKinhDoanh.ValueMember = "MaLVKD";

            //doc danh sach nhân viên tu database
            var nhanvien = from nhan in context.NhanVienTas
                           select nhan;
            cboNhanVienQuanLy.DataSource = nhanvien.ToList<NhanVienTa>();
            cboNhanVienQuanLy.DisplayMember = "HovTen";
            cboNhanVienQuanLy.ValueMember = "MaNhanVien";

            customer = (from p in context.KhachHangTas
                        where p.MaCongTy == MaKhachHang
                        select p).FirstOrDefault<KhachHangTa>();
            txtMaCongTy.Text = customer.MaCongTy;
            txtTenGiaoDichV.Text = customer.TenCTyV;
            txtTenGiaoDichE.Text = customer.TenCTyE;
            txtTenGiaoDichS.Text = customer.TenCTyVT;
            cboLinhVucKinhDoanh.SelectedValue = customer.MaLVKD;
            txtCongTyChuQuan.SelectedText = customer.CongTyChuQuan;
            if (customer.LoaiKhachHang.ToString() == rdKhachHang.Text)
            {
                rdKhachHang.Checked = true;
            }
            if (customer.LoaiKhachHang.ToString() == rdDoiTacKhachHang.Text)
            {
                rdDoiTacKhachHang.Checked = true;
            }
            if (customer.LoaiKhachHang.ToString() == rdAgent.Text)
            {
                rdAgent.Checked = true;
            }
            cboQuocGia.SelectedValue = customer.MaQuocGia;
            cboTinhThanh.SelectedValue = customer.MaTinhThanh;
            txtDiaChi.Text = customer.DiaChi;
            txtSDT.Text = customer.Sdt;
            txtSoFax.Text = customer.Fax;
            txtEmail.Text = customer.Email;
            txtWed.Text = customer.Web;
            cboNhanVienQuanLy.SelectedValue = customer.MaNhanVienQuanLy;
        }

        /// <summary>
        /// Loc danh sach tinh thanh khi chon Quoc gia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQuocGia.SelectedIndex >= 0)
            {
                int catID;
                Int32.TryParse(cboQuocGia.SelectedValue.ToString(), out catID);
                var tinhthanh = from p in context.TinhThanhTas
                                where p.MaQuocGia == catID
                                select p;
                cboTinhThanh.DataSource = tinhthanh.ToList<TinhThanhTa>();
                cboTinhThanh.DisplayMember = "TenTinhThanh";
                cboTinhThanh.ValueMember = "MaTinhThanh";

            }
        }
       


    }
}
