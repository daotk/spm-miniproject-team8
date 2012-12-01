using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachHang.BL;
using QuanLyKhachHang.DA;

namespace QuanLyKhachHang.GUI
{
    public partial class QuanLyDanhMuc : Form
    {
        ABCLogisticEntities context = new ABCLogisticEntities();
        NgoaiTeTa ngoaite = new NgoaiTeTa();
        string StrUsername;
        public QuanLyDanhMuc(string strUsername)
        {
            StrUsername = strUsername;
            InitializeComponent();
        }

        /// <summary>
        /// Đồng hồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// trang chinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            lblTenNhanVien.Text = StrUsername;

            //load tab danh muc ngoai te
            LoadDanhMuc();
         
        }

        private void LoadDanhMuc()
        {
            var ngoaite = from p in context.NgoaiTeTas
                          select new { p.MaNgoaiTe, p.TenNgoaiTe, p.TiGiaQuyDoi, p.NgayTao, p.NgayCapNhat, p.GhiChu, };
            dataGridView1.DataSource = ngoaite.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnalbleAll();
            button3.Hide();
            button5.Hide();
            //
            if (button2.Text == "Lưu")
            {
                ngoaite.MaNgoaiTe = txtMaNgoaiTe.Text;
                ngoaite.TenNgoaiTe = txtTenNgoaiTe.Text;
                ngoaite.TiGiaQuyDoi =  Int32.Parse(txtTiGia.Text);
                ngoaite.NgayTao = dtNgayTao.Value;
                ngoaite.GhiChu = txtGhiChu.Text;

                context.NgoaiTeTas.AddObject(ngoaite);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Them thanh cong");
                    LoadDanhMuc();
                }
                else
                {
                    MessageBox.Show("Them that bai");
                }
            }
            button2.Text = "Lưu";
            button1.Text = "Hủy bỏ";

        }
        /// <summary>
        /// Enabled
        /// </summary>
        private void EnalbleAll()
        {
            lblMaNgoaiTe.Enabled = true;
            lblTenNgoaiTe.Enabled = true;
            lblTiGia.Enabled = true;
            lblNgayTao.Enabled = true;
            lblGhiChu.Enabled = true;
            txtTenNgoaiTe.Enabled = true;
            txtMaNgoaiTe.Enabled = true;
            txtTiGia.Enabled = true;
            txtGhiChu.Enabled = true;
            dtNgayTao.Enabled = true;
        }
        /// <summary>
        /// button thu 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (button1.Text == "Hủy bỏ")
            {
                HuyBoKhiLuu();
                button3.Show();
                button5.Show();
                button1.Text = "Chỉnh sửa ngoại tệ";
                button2.Text = "Thêm mới ngoại tệ";

            }
        }

        private void HuyBoKhiLuu()
        {
            txtMaNgoaiTe.Text = "";
            txtTenNgoaiTe.Text = "";
            txtTiGia.Text = "";
            txtGhiChu.Text = "";
            dtNgayTao.Value = DateTime.Today;
            //disabled
            lblMaNgoaiTe.Enabled = false;
            lblTenNgoaiTe.Enabled = false;
            lblTiGia.Enabled = false;
            lblNgayTao.Enabled = false;
            lblGhiChu.Enabled = false;
            txtTenNgoaiTe.Enabled = false;
            txtMaNgoaiTe.Enabled = false;
            txtTiGia.Enabled = false;
            txtGhiChu.Enabled = false;
            dtNgayTao.Enabled = false;
        }

      
      
    }
}
