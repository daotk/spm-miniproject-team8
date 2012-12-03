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
        bool bCheckClick = false;
        NgoaiTeTa ngoaite = new NgoaiTeTa();
        string StrUsername;
        string strCapNhat = "Cập nhật",strHuyBo="Hủy bỏ",strChinhSua="Chỉnh sửa ngoại tệ",strLuu="Lưu",strThemMoi = "Thêm mới ngoại tệ",strChinhSuaTiGia="Chỉnh sửa tỉ giá quy đổi",
            strXoa = "Xóa ngoại tệ";
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
        private void btnTrangChinh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Xu ly tab danh muc ngoai te
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
        /// <summary>
        /// Load danh muc ngoai te vao datagirdview trong tab danh muc
        /// </summary>
        private void LoadDanhMuc()
        {
            var ngoaite = from p in context.NgoaiTeTas
                          select new { p.MaNgoaiTe, p.TenNgoaiTe, p.TiGiaQuyDoi, p.NgayTao, p.NgayCapNhat, p.GhiChu, };
            dataGridView1.DataSource = ngoaite.ToList();
        }
        /// <summary>
        /// trang thái ban đầu khi load vào tab ngoai te
        /// </summary>
        private void TrangThaiBanDau()
        {
            //disabled all
            lblMaNgoaiTe.Enabled = false;
            lblTenNgoaiTe.Enabled = false;
            lblTiGia.Enabled = false;
            lblNgayTao.Enabled = false;
            lblGhiChu.Enabled = false;
            txtTenNgoaiTe.Text = "";
            txtTenNgoaiTe.Enabled = false;
            txtMaNgoaiTe.Text = "";
            txtMaNgoaiTe.Enabled = false;
            txtTiGia.Text = "";
            txtTiGia.Enabled = false;
            txtGhiChu.Text = "";
            txtGhiChu.Enabled = false;
            dtNgayTao.Enabled = false;
            btnChinhsua.Show();
            btnChinhsua.Text = strChinhSua;
            btnThemmoi.Show();
            btnThemmoi.Text = strThemMoi;
            button3.Show();
            button3.Text = strXoa;
            button5.Show();
            button5.Text = strChinhSuaTiGia;
            dtNgayTao.Value = DateTime.Today;
        }
        /// <summary>
        /// nút đầu tiên trong tab ngoai te
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //bam nut them moi
            if (btnThemmoi.Text == strThemMoi)
            {
                EnalbleAll();
                button3.Hide();
                button5.Hide();
                btnThemmoi.Text = strLuu;
                btnChinhsua.Text = strHuyBo;
            }
            else
            {
                //luu
                if (btnThemmoi.Text == strLuu)
                {
                    ngoaite.MaNgoaiTe = txtMaNgoaiTe.Text;
                    ngoaite.TenNgoaiTe = txtTenNgoaiTe.Text;
                    ngoaite.TiGiaQuyDoi = Int32.Parse(txtTiGia.Text);
                    ngoaite.NgayTao = dtNgayTao.Value.Date;
                    ngoaite.GhiChu = txtGhiChu.Text;
                    context.NgoaiTeTas.AddObject(ngoaite);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Đã thêm thành công một ngoại tệ","Thông báo");
                        TrangThaiBanDau();
                        LoadDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại","Thông báo");
                    }
                }
                //cap nhat
                if (btnThemmoi.Text == strCapNhat)
                {
                    ngoaite.TenNgoaiTe = txtTenNgoaiTe.Text;
                    ngoaite.TiGiaQuyDoi = int.Parse(txtTiGia.Text);
                    ngoaite.NgayTao = dtNgayTao.Value;
                    ngoaite.GhiChu = txtGhiChu.Text;
                    ngoaite.NgayCapNhat = DateTime.Today;
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        TrangThaiBanDau();
                        LoadDanhMuc();
                        MessageBox.Show("Đã cập nhật thành công","Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại","Thông báo");
                    }
                }
            }
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
        /// button thu 2 trong tab danh muc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChinhSua_Click(object sender, EventArgs e)
        {
                if (btnChinhsua.Text == strHuyBo)
                {
                    TrangThaiBanDau();
                }
                else
                {
                    if (bCheckClick == false)
                    {
                        MessageBox.Show("Bạn chưa chọn ngoại tệ cần chỉnh sữa! Vui lòng chọn 1 loại ngoại tệ để chỉnh sữa", "Thông báo");
                    }
                    else
                    {
                        if (btnChinhsua.Text == strChinhSua)
                        {
                            EnalbleAll();
                            btnThemmoi.Text = strCapNhat;
                            btnChinhsua.Text = strHuyBo;
                            button3.Hide();
                            button5.Hide();
                            txtMaNgoaiTe.Enabled = false;
                        }
                    }
                }
        }

        //nut thoat trong tab danh muc
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// xủ lý khi click vao 1 cell trong datagirdview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string MaNgoaiTe = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ngoaite = (from p in context.NgoaiTeTas
                       where p.MaNgoaiTe == MaNgoaiTe
                       select p).FirstOrDefault<NgoaiTeTa>();
            txtMaNgoaiTe.Text = ngoaite.MaNgoaiTe;
            txtTenNgoaiTe.Text = ngoaite.TenNgoaiTe;
            txtTiGia.Text = ngoaite.TiGiaQuyDoi.ToString();
            dtNgayTao.Value = ngoaite.NgayTao.Date;
            txtGhiChu.Text = ngoaite.GhiChu;
            bCheckClick = true;
        }

        /// <summary>
        /// Xoa ngoai te
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (bCheckClick == false)
            {
                MessageBox.Show("Bạn chưa chọn ngoại tệ cần chỉnh sữa! Vui lòng chọn 1 loại ngoại tệ để chỉnh sữa", "Thông báo");
            }
            else
            {
                string strMaNgoaiTe = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa ngoại tệ có mã là " + strMaNgoaiTe + " Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (ABCLogisticEntities newcontext = new ABCLogisticEntities())
                    {
                        NgoaiTeTa p = new NgoaiTeTa() { MaNgoaiTe = strMaNgoaiTe };
                        newcontext.NgoaiTeTas.Attach(p);
                        newcontext.ObjectStateManager.ChangeObjectState(p, EntityState.Deleted);
                        int count = newcontext.SaveChanges();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã xóa thành công","Thông báo");
                            LoadDanhMuc();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại","Thông báo");
                        }
                    }
                }
                else
                {
                    LoadDanhMuc();
                }
            }
        }
        #endregion


    }
}
