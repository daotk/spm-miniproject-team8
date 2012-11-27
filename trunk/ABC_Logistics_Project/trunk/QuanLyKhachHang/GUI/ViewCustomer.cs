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
        NguoiLienHeTa NguoiLH;
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
            if (customer.LoaiKhachHang.ToString() == rdKhachHang.Text)
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

            Load_DataNLH();

            //enalble cac cai trong tab nguoi lien he


        }

        private void Load_DataNLH()
        {
            //load danh sach nguoi lien hệ
            var nguoilienhe = from cat in context.NguoiLienHeTas
                              where cat.MaKhachhang == MaKhachHang
                              select new { cat.MaNguoiLienHe,cat.HoVaChuLotNLH, cat.TenNLH, cat.PhongBan, cat.ChucDanh, cat.SDT, cat.SoDD, cat.Email };
            dgvNLH.DataSource = nguoilienhe.ToList();
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
        /// xu ly khi nhan nut hủy bỏ trong tab nguoi lien he
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bntHuyBoNLH_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// xủ lý khi nhấn nút chỉnh sữa trong tab người liên hệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDongYNLH_Click(object sender, EventArgs e)
        {
            if (btnDongYNLH.Text == "Chỉnh sữa")
            {
                txtHoNLH.Enabled = true;
                txtTenNLH.Enabled = true;
                txtPhongBanNLH.Enabled = true;
                txtChucDanhNLH.Enabled = true;
                txtSdtNLH.Enabled = true;
                txtSoDDNLH.Enabled = true;
                txtEmailNLH.Enabled = true;
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
                btnDongYNLH.Text = "Cập nhật";
            }
            else
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
                    MessageBox.Show("Cập nhật thành công");
                    Load_DataNLH();
                    btnDongYNLH.Text = "Chỉnh sữa";
                    Disalble_Textbox();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }



            }


        }
        /// <summary>
        /// xu ly khi them 1 nguoi lien he
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text == "Thêm")
            {
                txtHoNLH.Enabled = true;
                txtTenNLH.Enabled = true;
                txtPhongBanNLH.Enabled = true;
                txtChucDanhNLH.Enabled = true;
                txtSdtNLH.Enabled = true;
                txtSoDDNLH.Enabled = true;
                txtEmailNLH.Enabled = true;
                btnThem.Text = "Lưu";
            }
            else
            {
                NguoiLienHeTa nguoilienhe = new NguoiLienHeTa();
                nguoilienhe.HoVaChuLotNLH = txtHoNLH.Text;
                nguoilienhe.TenNLH = txtTenNLH.Text;
                nguoilienhe.PhongBan = txtPhongBanNLH.Text;
                nguoilienhe.ChucDanh = txtChucDanhNLH.Text;
                nguoilienhe.SDT = txtSdtNLH.Text;
                nguoilienhe.SoDD = txtSoDDNLH.Text;
                nguoilienhe.Email = txtEmailNLH.Text;
                nguoilienhe.MaKhachhang = MaKhachHang;

                context.NguoiLienHeTas.AddObject(nguoilienhe);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Thêm Thành công");
                    Load_DataNLH();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }

            }

        }

        /// <summary>
        /// disalble cac textbox
        /// </summary>
        private void Disalble_Textbox()
        {
            txtHoNLH.Enabled = false;
            txtTenNLH.Enabled = false;
            txtPhongBanNLH.Enabled = false;
            txtChucDanhNLH.Enabled = false;
            txtSdtNLH.Enabled = false;
            txtSoDDNLH.Enabled = false;
            txtEmailNLH.Enabled = false;
        }

        private void btnXoaNLH_Click(object sender, EventArgs e)
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
                        MessageBox.Show("Xóa thành công");
                        Load_DataNLH();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }



                }



            }
        }


    }
}
