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
        ABCLogisticEntities1 context=new ABCLogisticEntities1();
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
            if (ControlBL.CheckMaKH(makh) == true)
            {
                MessageBox.Show("Mã Khách hàng này đã có rồi! Xin vui lòng điền vào mã khách hành khác!");
            }
            else
            {
                MessageBox.Show("Mã khách hàng hợp lệ! Bạn có thể nhập tiếp các thông tin khác!");
                CheckMAKH =true;
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
                KhachHang p = new KhachHang();
                p.MaCongTy = txtMaCongTy.Text;
                p.TenCTyV = txtTenGiaoDichV.Text;
                p.TenCTyE = txtTenGiaoDichE.Text;
                p.TenCTyVietTat = txtTenVietTat.Text;
                p.LinhVucKinhDoanh = cboxLinhVucKinhDoanh.Text;
                p.CongTyChuQuan = cboxCongTyChuQuan.Text;

                p.LoaiKhachHang = strCheck;

                p.TenQuocGia = cboxQuocGia.Text;
                p.TinhThanh = cboxTinhThanh.Text;
                p.DiaChi = txtDiaChiLienLac.Text;
                p.Sdt = txtSdt.Text;
                p.Fax = txtSoFax.Text;
                p.Email = txtEmail.Text;
                p.Web = txtWebsite.Text;
                p.NhanVienQuanLy = txtNhanVienQuanLy.Text;

                //kiem tra tính hợp lệ khi nhập từ bàn phím
                if (p.MaCongTy != "" && p.TenCTyV != "" && p.LoaiKhachHang != "" && p.TenQuocGia != ""  && p.TinhThanh!="" && p.DiaChi != "" && p.Sdt != "")
                {
                    context.KhachHangs.AddObject(p);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        DialogResult result = MessageBox.Show("Ban da them thanh cong!", "Thong Bao", MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
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
            var QuocGia = from cat in context.QuocGias
                          select cat;
            cboxQuocGia.DataSource = QuocGia.ToList<QuocGia>();
            cboxQuocGia.DisplayMember = "TenQuocGia";
            cboxQuocGia.ValueMember = "MaQuocGia";

            //doc danh sach tinh thanh khi chon quoc gia
            int catID;
            Int32.TryParse(cboxQuocGia.SelectedValue.ToString(), out catID);
            var tinhthanh = from p in context.TinhThanhs
                            where p.MaQuocGia == catID
                            select p.TenTinhThanh;
            cboxTinhThanh.DataSource = tinhthanh.ToList();
            cboxTinhThanh.DisplayMember = "TenTinhThanh";

            //doc danh sach linh vuc kinh doanh tu database
            var linhvuc = from cat in context.LinhVucKinhDoanhs
                          select cat;
            cboxLinhVucKinhDoanh.DataSource=linhvuc.ToList<LinhVucKinhDoanh>();
            cboxLinhVucKinhDoanh.DisplayMember = "TenLinhVucKinhDoanh";

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
                var tinhthanh = from p in context.TinhThanhs
                                where p.MaQuocGia == catID
                                select p.TenTinhThanh;
                cboxTinhThanh.DataSource = tinhthanh.ToList();
                cboxTinhThanh.DisplayMember = "TenTinhThanh";

            }
        }

        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = "Khách hàng";
        }

        private void rdDoiTac_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = "Đối tác khách hàng";
        }

        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
            strCheck = "Agent";
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

       

     

      

       

        

       

       
    }
}
