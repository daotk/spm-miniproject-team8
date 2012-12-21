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
    public partial class Fm_EditCustomer : Form
    {
        ABCLogisticEntities context = new ABCLogisticEntities();
        KhachHangTa customer;
        NguoiLienHeTa NguoiLH;
        string strCheck, makh;
        public Fm_EditCustomer()
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
                Fm_Search FSearch = new Fm_Search();
                FSearch.submit += new Fm_Search.Editcusdelegate(FSearch_submit);
                FSearch.ShowDialog();
               
        }

        void FSearch_submit(string item)
        {
            makh = item;
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
                        where p.MaCongTy == item
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
            dtNgayTao.Value = customer.NgayTao.Value;

            //load NLH
            Load_DataNLH();
        }

        /// <summary>
        /// xử lý sự kiện khi nhấp nút cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
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
            customer.Web = txtWed.Text;
            customer.MaNhanVienQuanLy = (int)cboNhanVienQuanLy.SelectedValue;
            customer.NgayTao = dtNgayTao.Value;
            int count = context.SaveChanges();
            if (count > 0)
            {
                MessageBox.Show("Cập nhật thành công","Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại","Thông báo");
            }
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = rdKhachHang.Text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDoiTacKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = rdDoiTacKhachHang.Text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = rdAgent.Text;
        }
        /// <summary>
        /// Load data nguoi lien he
        /// </summary>
        private void Load_DataNLH()
        {
            //load danh sach nguoi lien hệ
            var nguoilienhe = from cat in context.NguoiLienHeTas
                              where cat.MaKhachhang == makh
                              select new { cat.MaNguoiLienHe, cat.HoVaChuLotNLH, cat.TenNLH, cat.PhongBan, cat.ChucDanh, cat.SDT, cat.SoDD, cat.Email };
            dgvNLH.DataSource = nguoilienhe.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNLH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //load nguoi lien he len textbox
            Int32 makh = (int)dgvNLH.CurrentRow.Cells[0].Value;

            NguoiLH = (from p in context.NguoiLienHeTas
                       where p.MaNguoiLienHe == makh
                       select p).FirstOrDefault<NguoiLienHeTa>();

            txtHoNLH.Text = NguoiLH.HoVaChuLotNLH;
            txtTenNLH.Text = NguoiLH.TenNLH;
            txtPhongBanNLH.Text = NguoiLH.PhongBan;
            txtChucDanhNLH.Text = NguoiLH.ChucDanh;
            txtSdtNLH.Text = NguoiLH.SDT;
            txtSoDDNLH.Text = NguoiLH.SoDD;
            txtEmailNLH.Text = NguoiLH.Email;
        }
        /// <summary>
        /// luu lai chinh sua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NguoiLH.HoVaChuLotNLH = txtHoNLH.Text;
            NguoiLH.TenNLH = txtTenNLH.Text;
            NguoiLH.PhongBan = txtPhongBanNLH.Text;
            NguoiLH.ChucDanh = txtChucDanhNLH.Text;
            NguoiLH.SDT = txtSdtNLH.Text;
            NguoiLH.SoDD = txtSoDDNLH.Text;
            NguoiLH.Email = txtEmailNLH.Text;
            int count = context.SaveChanges();
            if (count > 0)
            {
                MessageBox.Show("Cập nhật thành công","Thông báo");
                Load_DataNLH();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại","Thông báo");
            }

        }
        /// <summary>
        /// huy bo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int MaNLH;
            if (Int32.TryParse(dgvNLH.CurrentRow.Cells[0].Value.ToString(), out MaNLH))
            {
                using (ABCLogisticEntities newcontext = new ABCLogisticEntities())
                {
                    NguoiLienHeTa p = new NguoiLienHeTa() { MaNguoiLienHe = MaNLH };
                    newcontext.NguoiLienHeTas.Attach(p);
                    newcontext.ObjectStateManager.ChangeObjectState(p, EntityState.Deleted);
                    int count = newcontext.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thành công","Thông báo");
                        Load_DataNLH();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại","Thông báo");
                    }
                }
            }
        }



    }
}
