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
        ABCLogisticEntities context = new ABCLogisticEntities();
        string MaKhachHang;
        KhachHangTa customer;
        string strCheck;
        public ViewCustomer(string pMaKhachHang)
        {
            MaKhachHang = pMaKhachHang;
            InitializeComponent();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
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
            if (customer.LoaiKhachHang.ToString() ==rdKhachHang.Text )
            {
                rdKhachHang.Checked = true;
            }
            if (customer.LoaiKhachHang.ToString() == rdDoitacKhachHang.Text)
            {
                rdDoitacKhachHang.Checked = true;
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
            txtWedsite.Text = customer.Web;
            cboNhanVienQuanLy.SelectedValue = customer.MaNhanVienQuanLy;
            

        }
        /// <summary>
        /// xu ly khi nhap nut chinh sua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (btnDongY.Text == "Chỉnh sữa")
            {
                //enabled cac nut
                txtTenGiaoDichV.Enabled = true;
                txtTenGiaoDichE.Enabled = true;
                txtTenGiaoDichS.Enabled = true;
                cboLinhVucKinhDoanh.Enabled = true;
                txtCongTyChuQuan.Enabled = true;
                rdAgent.Enabled = true;
                rdDoitacKhachHang.Enabled = true;
                rdKhachHang.Enabled = true;
                cboQuocGia.Enabled = true;
                cboTinhThanh.Enabled = true;
                txtDiaChi.Enabled = true;
                txtSDT.Enabled = true;
                txtSoFax.Enabled = true;
                txtEmail.Enabled = true;
                txtWedsite.Enabled = true;
                cboNhanVienQuanLy.Enabled = true;
                //set text
                btnDongY.Text = "Cập nhật";

            }
            else
            {
                customer.TenCTyV = txtTenGiaoDichV.Text;
                customer.TenCTyE = txtTenGiaoDichE.Text;
                customer.TenCTyVT = txtTenGiaoDichS.Text;
                customer.MaLVKD = (int)cboLinhVucKinhDoanh.SelectedValue;
                customer.CongTyChuQuan = txtCongTyChuQuan.Text;
                customer.LoaiKhachHang = strCheck;
                customer.MaQuocGia = (int)cboQuocGia.SelectedValue;
                customer.MaTinhThanh = (int)cboTinhThanh.SelectedValue;
                customer.DiaChi = txtDiaChi.Text;
                customer.Sdt = txtSDT.Text;
                customer.Fax = txtSoFax.Text;
                customer.Email = txtEmail.Text;
                customer.Web = txtWedsite.Text;
                customer.MaNhanVienQuanLy = (int)cboNhanVienQuanLy.SelectedValue;
                int count = context.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            
            }

        /// <summary>
        /// cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = rdKhachHang.Text;
        }

        private void rdDoitacKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = rdDoitacKhachHang.Text;
        }

        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = rdAgent.Text;
        }
    }
}
