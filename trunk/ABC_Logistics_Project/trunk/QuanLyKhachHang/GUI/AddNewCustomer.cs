using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachHang.DA;
using QuanLyKhachHang.BL;

namespace QuanLyKhachHang.GUI
{
    public partial class AddNewCustomer : Form
    {
        ABCLogisticEntities context=new ABCLogisticEntities();
        KhachHangTa p = new KhachHangTa();
        NguoiLienHeTa nlh = new NguoiLienHeTa();
        bool CheckMAKH = false;
        string strCheck;
        bool bcheck = false;
        string strUsername;
        public AddNewCustomer(string strusername)
        {
            strUsername = strusername;
            InitializeComponent();
        }
       

        /// <summary>
        /// text change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMaCongTy_TextChanged(object sender, EventArgs e)
        {
            string makh = txtMaCongTy.Text;
            if (makh == "")
            {
                btnCheck.Image = global::QuanLyKhachHang.Properties.Resources.no_icon;
            }
            else
            {
                if (ControlBL.CheckMaKH(makh) == true)
                {
                    btnCheck.Image = global::QuanLyKhachHang.Properties.Resources.no_icon;
                }
                else
                {
                    btnCheck.Image = global::QuanLyKhachHang.Properties.Resources.check_2_icon;
                    CheckMAKH = true;
                }
            }
        }

        /// <summary>
        /// xử lý sự kiện khi nhấn nhút "Cancel" trong giao diện thêm mới khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (CheckMAKH == true)
            {
                p.MaCongTy = txtMaCongTy.Text;
                p.TenCTyV = txtTenGiaoDichV.Text;
                p.TenCTyE = txtTenGiaoDichE.Text;
                p.TenCTyVT = txtTenVietTat.Text;
                p.MaLVKD = (int)cboxLinhVucKinhDoanh.SelectedValue;
                p.CongTyChuQuan = cboxCongTyChuQuan.Text;
                p.LoaiKhachHang = strCheck;
                p.MaQuocGia = (int)cboxQuocGia.SelectedValue;
                p.MaTinhThanh = (int)cboxTinhThanh.SelectedValue;
                p.DiaChi = txtDiaChiLienLac.Text;
                p.Sdt = txtSdt.Text;
                p.Fax = txtSoFax.Text;
                p.Email = txtEmail.Text;
                p.Web = txtWebsite.Text;
                p.MaNhanVienQuanLy = (int)cboNhanVienQuanLy.SelectedValue;
                p.NgayTao = dtNgayTao.Value;

                //kiem tra tính hợp lệ khi nhập từ bàn phím
                if (p.MaCongTy != "" && p.TenCTyV != "" && bcheck==true && p.MaTinhThanh != null && p.MaQuocGia != null && p.DiaChi != "" && p.Sdt != "")
                {
                    context.KhachHangTas.AddObject(p);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Đã thêm thành công!", "Thông báo");
                        TrangThaiBanDau();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa điền đầy đủ thông tin bắc buộc", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa kiễm tra ma khác hàng", "Thông báo");
            }
        }

        /// <summary>
        /// xu li khi load form trong them danh sach khach hang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewCustomer_Load(object sender, EventArgs e)
        {
          
            //doc danh sach quoc gia tu database
            var QuocGia = from cat in context.GetAllQuocGia()
                          select cat;
            cboxQuocGia.DataSource = QuocGia.ToList<QuocGiaTa>();
            cboxQuocGia.DisplayMember = "TenQuocGia";
            cboxQuocGia.ValueMember = "MaQuocGia";

            //doc danh sach tinh thanh khi chon quoc gia
            int catID;
            Int32.TryParse(cboxQuocGia.SelectedValue.ToString(), out catID);
            var tinhthanh = from p in context.TinhThanhTas
                            where p.MaQuocGia == catID
                            select p;
            cboxTinhThanh.DataSource = tinhthanh.ToList<TinhThanhTa>();
            cboxTinhThanh.DisplayMember = "TenTinhThanh";
            cboxTinhThanh.ValueMember = "MaTinhThanh";
            
            //doc danh sach linh vuc kinh doanh tu database
            var linhvuc = from cat in context.LinhVucKinhDoanhTas
                          select cat;
            cboxLinhVucKinhDoanh.DataSource=linhvuc.ToList<LinhVucKinhDoanhTa>();
            cboxLinhVucKinhDoanh.DisplayMember = "TenLVKD";
            cboxLinhVucKinhDoanh.ValueMember = "MaLVKD";


            //hien thi de nghi cho cbo
            cboxCongTyChuQuan.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboxCongTyChuQuan.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (txtMaCongTy.Text == "")
            {
                btnCheck.Image = global::QuanLyKhachHang.Properties.Resources.no_icon;
            }
            //load danh sach nhan vien
            var nhanvien1 = from pa in context.GetNhanVien_TenNhanVien(strUsername)
                           select pa;
            cboNhanVienQuanLy.DataSource = nhanvien1.ToList();
            cboNhanVienQuanLy.DisplayMember = "HovTen";
            cboNhanVienQuanLy.ValueMember = "MaNhanVien";
        }

        /// <summary>
        /// Loc danh sach tinh thanh khi chon Quoc gia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxQuocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxQuocGia.SelectedIndex >= 0)
            {
                int catID;
                Int32.TryParse(cboxQuocGia.SelectedValue.ToString(), out catID);
                var tinhthanh = from p in context.TinhThanhTas
                                where p.MaQuocGia == catID
                                select p;
                cboxTinhThanh.DataSource = tinhthanh.ToList<TinhThanhTa>();
                cboxTinhThanh.DisplayMember = "TenTinhThanh";
                cboxTinhThanh.ValueMember = "MaTinhThanh";

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            bcheck = true;
            strCheck =  rdKhachHang.Text;
            cboxLinhVucKinhDoanh.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDoiTac_CheckedChanged(object sender, EventArgs e)
        {
            bcheck = true;
            strCheck =  rdDoiTac.Text;
            cboxLinhVucKinhDoanh.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
            bcheck = true;
            strCheck = rdAgent.Text;
            cboxLinhVucKinhDoanh.Enabled = false;
            cboxLinhVucKinhDoanh.SelectedValue = 3;
        }

        /// <summary>
        /// không cho nhập chữ vào các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        /// <summary>
        /// xử lý nút luu trong tab thêm nguoi liên hệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            nlh.HoVaChuLotNLH = txtHoTenNLH.Text;
            nlh.TenNLH = txtTenNLH.Text;
            nlh.PhongBan = txtPhongBanNLH.Text;
            nlh.ChucDanh = txtChucDanhNLH.Text;
            nlh.SDT = txtSdtNLH.Text;
            nlh.SoDD = txtSdtDDNLH.Text;
            nlh.Email = txtEmailNLH.Text;
            nlh.MaKhachhang = p.MaCongTy;
            context.NguoiLienHeTas.AddObject(nlh);
            int count = context.SaveChanges();
            if (count > 0)
            {
                MessageBox.Show("Thêm Thành công","Thông báo");
                //load danh sach nguoi lien hệ
                var nguoilienhe = from cat in context.NguoiLienHeTas
                                  where cat.MaKhachhang == p.MaCongTy
                                  select new { cat.MaNguoiLienHe, cat.HoVaChuLotNLH, cat.TenNLH, cat.PhongBan, cat.ChucDanh, cat.SDT, cat.SoDD, cat.Email };
                dataGridView1.DataSource = nguoilienhe.ToList();
            }
            else
            {
                MessageBox.Show("Thêm thất bại","Thông báo");
            }


        }
        /// <summary>
        /// xủ lý khi nhấn nút hủy bỏ trong tab thêm người liên hệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrangThaiBanDau()
        {
            txtMaCongTy.Enabled = false;
            txtTenGiaoDichV.Enabled = false;
            txtTenGiaoDichE.Enabled = false;
            txtTenVietTat.Enabled = false;
            cboxCongTyChuQuan.Enabled = false;
            rdKhachHang.Enabled = false;
            rdDoiTac.Enabled = false;
            rdAgent.Enabled = false;
            txtDiaChiLienLac.Enabled = false;
            txtSdt.Enabled = false;
            txtSoFax.Enabled = false;
            txtEmail.Enabled = false;
            txtWebsite.Enabled = false;
            dtNgayTao.Enabled = false;
            cboxCongTyChuQuan.Enabled = false;
            cboxLinhVucKinhDoanh.Enabled = false;
            cboxQuocGia.Enabled = false;
            cboxTinhThanh.Enabled = false;
        }



       
    }
}
