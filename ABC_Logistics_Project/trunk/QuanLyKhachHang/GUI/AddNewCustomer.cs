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
                string txtnhanvienquanly = "Dao Khau";

                KhachHang p = new KhachHang();
                p.MaCongTy = txtMaCongTy.Text;
                p.TenCTyV = txtTenGiaoDichV.Text;
                p.TenCTyE = txtTenGiaoDichE.Text;
                p.TenCTyVietTat = txtTenVietTat.Text;
                p.LinhVucKinhDoanh = cboxLinhVucKinhDoanh.Text;
                p.CongTyChuQuan = cboxCongTyChuQuan.Text;
                //
                if (rdAgent.Checked == true)
                {
                    p.LoaiKhachHang = rdAgent.Text;
                }
                if (rdDoiTac.Checked == true)
                {
                    p.LoaiKhachHang = rdDoiTac.Text;
                }
                if (rdKhachHang.Checked)
                {
                    p.LoaiKhachHang = rdKhachHang.Text;
                }
                p.TenQuocGia = cboxQuocGia.Text;
                p.TinhThanh = cboxTinhThanh.Text;
                p.DiaChi = txtDiaChiLienLac.Text;
                p.Sdt = txtSdt.Text;
                p.Fax = txtSoFax.Text;
                p.Email = txtEmail.Text;
                p.Web = txtWebsite.Text;
                p.NhanVienQuanLy = txtnhanvienquanly ;

                //kiem tra tính hợp lệ khi nhập từ bàn phím
                if (p.MaCongTy != "" && p.TenCTyV != "" && p.LoaiKhachHang != "" && p.TenQuocGia != "" && p.TinhThanh != "" && p.DiaChi != "" && p.Sdt != "")
                {
                    context.KhachHangs.AddObject(p);
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
          
            //doc danh sach quoc gia tu database
            var QuocGia = from cat in context.QuocGias
                          select cat;
            cboxQuocGia.DataSource = QuocGia.ToList<QuocGia>();
            cboxQuocGia.DisplayMember = "TenQuocGia";
            cboxQuocGia.ValueMember = "MaQuocGia";

            //doc danh sach linh vuc kinh doanh tu database
            var linhvuc = from cat in context.LinhVucKinhDoanhs
                          select cat;
            cboxLinhVucKinhDoanh.DataSource=linhvuc.ToList<LinhVucKinhDoanh>();
            cboxLinhVucKinhDoanh.DisplayMember = "TenLinhVucKinhDoanh";

            ////doc danh sach congtychuquan tu database
            //var congty = from cat in context.Customers
            //             select cat;
            //cboxCongTyChuQuan.DataSource=congty.ToList<Customer>();
            //cboxCongTyChuQuan.DisplayMember = "Company";

            //khong cho combobox chon gia tri
            cboxCongTyChuQuan.SelectedItem = -1;
            cboxLinhVucKinhDoanh.SelectedItem = 0;
            cboxQuocGia.SelectedItem = -2;
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


            }
        }

     

      

       

        

       

       
    }
}
