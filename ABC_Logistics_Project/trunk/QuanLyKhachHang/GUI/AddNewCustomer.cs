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
        public AddNewCustomer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// kiểm tra xem có bị trùng mã khách hàng hay không
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            string makh = txtMaCongTy.Text;
            if (makh == "")
            {
                MessageBox.Show("Thieu ma khach hang. Vui long nhap ma khach hang");
            }
            else
            {
                if (ControlBL.CheckMaKH(makh) == true)
                {
                    MessageBox.Show("Mã Khách hàng này đã có rồi! Xin vui lòng điền vào mã khách hành khác!");
                }
                else
                {
                    MessageBox.Show("Mã khách hàng hợp lệ! Bạn có thể nhập tiếp các thông tin khác!");
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
                p.MaTinhThanh =(int)cboxTinhThanh.SelectedValue;
                p.DiaChi = txtDiaChiLienLac.Text;
                p.Sdt = txtSdt.Text;
                p.Fax = txtSoFax.Text;
                p.Email = txtEmail.Text;
                p.Web = txtWebsite.Text;
                p.MaNhanVienQuanLy = 1;

                //kiem tra tính hợp lệ khi nhập từ bàn phím
                if (p.MaCongTy != "" && p.TenCTyV != "" && p.LoaiKhachHang != "" && p.DiaChi != "" && p.Sdt != "")
                {
                    context.KhachHangTas.AddObject(p);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show("Ban da them thanh cong!", "Thong Bao", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm!");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập hết các thông tin bắc buộc! Xin hãy nhập hết các thông tin bắc buộc");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa kiễm tra mã khách hàng. Vui lòng kiễm tra mã khách hàng trước khi nhấn Đồng ý");
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
            var QuocGia = from cat in context.QuocGiaTas
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
            strCheck =  rdKhachHang.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDoiTac_CheckedChanged(object sender, EventArgs e)
        {
            strCheck =  rdDoiTac.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
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
                MessageBox.Show("Thêm Thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
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
     

      

       

        


       
    }
}
