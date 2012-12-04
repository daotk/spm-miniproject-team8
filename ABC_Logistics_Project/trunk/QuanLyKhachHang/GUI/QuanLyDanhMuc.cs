﻿using System;
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
        QuocGiaTa quocgia = new QuocGiaTa();
        TinhThanhTa tinhthanh = new TinhThanhTa();
      
        bool bCheckClick = false,bCheckClickQuocGia;
        string StrUsername;
        string strCapNhat = "Cập nhật", strHuyBo = "Hủy bỏ", strChinhSua = "Chỉnh sửa ngoại tệ", strLuu = "Lưu", strThemMoi = "Thêm mới ngoại tệ", strChinhSuaTiGia = "Chỉnh sửa tỉ giá quy đổi",
            strXoa = "Xóa ngoại tệ", strThemQuocGia = "Thêm", strChinhSuaQuocGia = "Chỉnh sửa", strXoaQuocGia = "Xóa", strLuuQuocGia = "Lưu";
        public QuanLyDanhMuc(string strUsername)
        {
            StrUsername = strUsername;
            InitializeComponent();
        }
        #region Danh Muc
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
        #endregion

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

            //load trong tab danh muc quoc gia
            var chauluc = from p in context.GetAllChau()
                          select p;
            cboChau.DataSource = chauluc.ToList<ChauTa>();
            cboChau.DisplayMember = "TenChauLuc";
            cboChau.ValueMember = "MaChau";
            Load_DanhMucQuocGia();

            var quocgia = from cat in context.GetAllQuocGia()
                          select cat;
            cboQuocGia.DataSource = quocgia.ToList<QuocGiaTa>();
            cboQuocGia.DisplayMember = "TenQuocGia";
            cboQuocGia.ValueMember = "MaQuocGia";
            LoadTinhThanh();

        }

        #region Xu ly tab danh muc ngoai te

        /// <summary>
        /// Load danh muc ngoai te vao datagirdview trong tab danh muc
        /// </summary>
        private void LoadDanhMuc()
        {
            var ngoaite = from p in context.GetAllNgoaiTe()
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
                        MessageBox.Show("Đã thêm thành công một ngoại tệ", "Thông báo");
                        TrangThaiBanDau();
                        LoadDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo");
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
                        MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông báo");
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
                            MessageBox.Show("Đã xóa thành công", "Thông báo");
                            LoadDanhMuc();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo");
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

        #region Danh Muc Quoc Gia
        /// <summary>
        /// Thêm 1 quốc gia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemQuocGia_Click(object sender, EventArgs e)
        {
            if (btnThemQuocGia.Text == strLuu)
            {
                QuocGiaTa newguocgia = new QuocGiaTa();
                newguocgia.TenVietTac = txtMaQuocGia.Text;
                newguocgia.TenQuocGia = txtTenQuocGia.Text;
                newguocgia.MaChau = (int)cboChau.SelectedValue;
                newguocgia.GhiChu = txtGhiChuQuocGia.Text;
                context.QuocGiaTas.AddObject(newguocgia);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Đã thêm thành công", "Thông báo");
                    Load_DanhMucQuocGia();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo");
                }
            }
            else
            {
                if (btnThemQuocGia.Text == strThemQuocGia)
                {
                    EnableDanhMucQuocGia();
                    txtMaQuocGia.Text = "";
                    txtTenQuocGia.Text = "";
                    txtGhiChuQuocGia.Text = "";
                    btnThemQuocGia.Text = strLuuQuocGia;
                    btnChinhSuaQuocGia.Text = strHuyBo;
                    btnXoaQuocGia.Hide();
                }
                else
                {
                    if (btnThemQuocGia.Text == strCapNhat)
                    {
                        quocgia.TenVietTac = txtMaQuocGia.Text;
                        quocgia.TenQuocGia = txtTenQuocGia.Text;
                        quocgia.MaChau = (int)cboChau.SelectedValue;
                        quocgia.GhiChu = txtGhiChuQuocGia.Text;
                        int count = context.SaveChanges();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                            Load_DanhMucQuocGia();
                            TrangThaiBanDauQuocGia();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại", "Thông báo");
                        }

                    }
                }
            }

        }
        /// <summary>
        /// Load danh muc quoc gia
        /// </summary>
        private void Load_DanhMucQuocGia()
        {
            var quocgia = from p in context.GetAllQuocGia()
                          select new { p.TenVietTac, p.TenQuocGia, p.ChauTa.TenChauLuc, p.GhiChu };
            dgQuocGia.DataSource = quocgia.ToList();
            //stt
            for (int i = 0; i < dgQuocGia.Rows.Count; i++)
            {
                dgQuocGia.Rows[i].Cells[0].Value = i + 1;
            }  
        }
        /// <summary>
        /// Chinh sua quoc gia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChinhSuaQuocGia_Click(object sender, EventArgs e)
        {
            if (btnChinhSuaQuocGia.Text == strChinhSuaQuocGia)
            {
                if (bCheckClickQuocGia == true)
                {
                    EnableDanhMucQuocGia();
                    string strTenQuocGia = dgQuocGia.CurrentRow.Cells[1].Value.ToString();
                    quocgia = (from p in context.QuocGiaTas
                               where p.TenVietTac == strTenQuocGia
                               select p).FirstOrDefault<QuocGiaTa>();
                    txtMaQuocGia.Text = quocgia.TenVietTac;
                    txtTenQuocGia.Text = quocgia.TenQuocGia;
                    cboChau.SelectedValue = quocgia.MaChau;
                    txtGhiChuQuocGia.Text = quocgia.GhiChu;
                    btnChinhSuaQuocGia.Text = strHuyBo;
                    btnThemQuocGia.Text = strCapNhat;
                    btnXoaQuocGia.Hide();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn quốc gia cần chỉnh sữa", "Thông báo");
                }
            }
            else
            {
                TrangThaiBanDauQuocGia();
            }    
        }
        /// <summary>
        /// trang thai ban dau tab danh muc quoc gia
        /// </summary>
        private void TrangThaiBanDauQuocGia()
        {
            txtMaQuocGia.Enabled = false;
            txtTenQuocGia.Enabled = false;
            cboChau.Enabled = false;
            txtGhiChuQuocGia.Enabled = false;

            btnThemQuocGia.Text = strThemQuocGia;
            btnChinhSuaQuocGia.Text = strChinhSuaQuocGia;
            btnXoaQuocGia.Show();
            btnXoaQuocGia.Text = strXoaQuocGia;
        }
        /// <summary>
        /// 
        /// </summary>
        private void EnableDanhMucQuocGia()
        {
            txtMaQuocGia.Enabled = true;
            txtTenQuocGia.Enabled = true;
            cboChau.Enabled = true;
            txtGhiChuQuocGia.Enabled = true;
        }
        /// <summary>
        /// Cell Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgQuocGia_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strTenQuocGia = dgQuocGia.CurrentRow.Cells[1].Value.ToString();
            quocgia = (from p in context.QuocGiaTas
                       where p.TenVietTac == strTenQuocGia
                       select p).FirstOrDefault<QuocGiaTa>();
            txtMaQuocGia.Text = quocgia.TenVietTac;
            txtTenQuocGia.Text = quocgia.TenQuocGia;
            cboChau.SelectedValue = quocgia.MaChau;
            txtGhiChuQuocGia.Text = quocgia.GhiChu;
            bCheckClickQuocGia = true;
        }
        /// <summary>
        /// Xoa Quoc Gia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaQuocGia_Click(object sender, EventArgs e)
        {
            if (bCheckClickQuocGia == false)
            {
                MessageBox.Show("Bạn chưa chọn quốc gia cần xóa!", "Thông báo");
            }
            else
            {
                string strMaQuocGia = dgQuocGia.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có muốn xóa quoc gia có mã là " + strMaQuocGia + " Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (ABCLogisticEntities newcontext = new ABCLogisticEntities())
                    {
                        QuocGiaTa p = new QuocGiaTa() { TenVietTac = strMaQuocGia};
                        newcontext.QuocGiaTas.Attach(p);
                        //newcontext.ObjectStateManager.ChangeObjectState(p, EntityState.Deleted);
                        newcontext.QuocGiaTas.DeleteObject(p);
                        int count = newcontext.SaveChanges();
                       
         
                        if (count > 0)
                        {
                            MessageBox.Show("Đã xóa thành công", "Thông báo");
                            Load_DanhMucQuocGia();
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại", "Thông báo");
                        }
                    }
                }
                else
                {
                    Load_DanhMucQuocGia();
                }
            }
        }

        /// <summary>
        /// Enable tinh thanh
        /// </summary>
        private void EnableDanhMucTinhThanh()
        {
            txtMaTinhThanh.Enabled = true;
            txtTenTinhThanh.Enabled = true;
            cboQuocGia.Enabled = true;
            txtGhiChuTinhThanh.Enabled = true;
        }
        /// <summary>
        /// trang thai ban dau cua tinh thanh
        /// </summary>
        private void TrangThaiBanDauTinhThanh()
        {
            txtMaTinhThanh.Text = "";
            txtTenTinhThanh.Text = "";
            txtGhiChuTinhThanh.Text = "";
            txtMaTinhThanh.Enabled = false;
            txtTenTinhThanh.Enabled = false;
            cboQuocGia.Enabled = false;
            txtGhiChuTinhThanh.Enabled = false;
            btnThemTinhThanh.Text = strThemQuocGia;
            btnChinhSuaTinhThanh.Text = strChinhSuaQuocGia;
            btnXoaTinhThanh.Text = strXoaQuocGia;
            btnXoaTinhThanh.Show();
        }

        private void LoadTinhThanh()
        {
            var tinhthanh = from p in context.GetAllTinhThanh()
                            select new {p.TenVietTac,p.TenTinhThanh,p.QuocGiaTa.TenQuocGia,p.GhiChu};
            dgTinhThanh.DataSource = tinhthanh.ToList();
            //stt
            for (int i = 0; i < dgTinhThanh.Rows.Count; i++)
            {
                dgTinhThanh.Rows[i].Cells[0].Value = i + 1;
            }  
        }

        /// <summary>
        /// thêm tỉnh thành
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTinhThanh_Click(object sender, EventArgs e)
        {
            if (btnThemTinhThanh.Text == strThemQuocGia)
            {
                txtMaTinhThanh.Text = "";
                txtTenTinhThanh.Text = "";
                txtGhiChuTinhThanh.Text = "";
                EnableDanhMucTinhThanh();
                btnThemTinhThanh.Text = strLuu;
                btnChinhSuaTinhThanh.Text = strHuyBo;
                btnXoaTinhThanh.Hide();
            }
            else
            {
                //luu
                if (btnThemTinhThanh.Text == strLuu)
                {
                    TinhThanhTa newtinhthanh = new TinhThanhTa();
                    newtinhthanh.TenVietTac = txtMaTinhThanh.Text;
                    newtinhthanh.TenTinhThanh = txtTenTinhThanh.Text;
                    newtinhthanh.MaQuocGia = (int)cboQuocGia.SelectedValue;
                    newtinhthanh.GhiChu = txtGhiChuTinhThanh.Text;
                    context.TinhThanhTas.AddObject(newtinhthanh);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Đã thêm thành công", "Thông báo");
                        LoadTinhThanh();
                        TrangThaiBanDauTinhThanh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo");
                    }
                }
                    //cap nhat
                else
                {
                    if (btnThemTinhThanh.Text == strCapNhat)
                    {
                        tinhthanh.TenVietTac = txtMaTinhThanh.Text;
                        tinhthanh.TenTinhThanh = txtTenTinhThanh.Text;
                        tinhthanh.MaQuocGia = (int)cboQuocGia.SelectedValue;
                        tinhthanh.GhiChu = txtGhiChuTinhThanh.Text;
                        int count = context.SaveChanges();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã cập nhật thành công", "Thông báo");
                            LoadTinhThanh();
                            TrangThaiBanDauTinhThanh();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại", "Thông báo");
                        }
                    }
                    
                }

            }
        }
        /// <summary>
        /// chinh sua tinh thanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChinhSuaTinhThanh_Click(object sender, EventArgs e)
        {
            if (btnChinhSuaTinhThanh.Text == strChinhSuaQuocGia)
            {
                btnThemTinhThanh.Text = strCapNhat;
                btnChinhSuaTinhThanh.Text = strHuyBo;
                btnXoaTinhThanh.Hide();
                EnableDanhMucTinhThanh();
                string strMaTinhThanh = dgTinhThanh.CurrentRow.Cells[1].Value.ToString();
                tinhthanh = (from p in context.TinhThanhTas
                           where p.TenVietTac == strMaTinhThanh
                           select p).FirstOrDefault<TinhThanhTa>();
                txtMaTinhThanh.Text = tinhthanh.TenVietTac;
                txtTenTinhThanh.Text = tinhthanh.TenTinhThanh;
                cboQuocGia.SelectedValue = tinhthanh.MaQuocGia;
                txtGhiChuTinhThanh.Text = tinhthanh.GhiChu;
            }
            else
            {
                if (btnChinhSuaTinhThanh.Text == strHuyBo)
                {
                    TrangThaiBanDauTinhThanh();
                }
            }
        }
        /// <summary>
        /// cell mouse click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTinhThanh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strMaTinhThanh = dgTinhThanh.CurrentRow.Cells[1].Value.ToString();
            tinhthanh = (from p in context.TinhThanhTas
                         where p.TenVietTac == strMaTinhThanh
                         select p).FirstOrDefault<TinhThanhTa>();
            txtMaTinhThanh.Text = tinhthanh.TenVietTac;
            txtTenTinhThanh.Text = tinhthanh.TenTinhThanh;
            cboQuocGia.SelectedValue = tinhthanh.MaQuocGia;
            txtGhiChuTinhThanh.Text = tinhthanh.GhiChu;
        }
        /// <summary>
        /// xoa tinh thanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTinhThanh_Click(object sender, EventArgs e)
        {
            string strMaTinhThanh = dgTinhThanh.SelectedRows[0].Cells[1].Value.ToString();
            DialogResult result = MessageBox.Show("Bạn có muốn xóa tỉnh thành có mã là " + strMaTinhThanh + " Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (ABCLogisticEntities newcontext = new ABCLogisticEntities())
                {
                    QuocGiaTa p = new QuocGiaTa() { TenVietTac = strMaTinhThanh };
                    newcontext.QuocGiaTas.Attach(p);
                    newcontext.ObjectStateManager.ChangeObjectState(p, EntityState.Deleted);
                    int count = newcontext.SaveChanges();

                    if (count > 0)
                    {
                        MessageBox.Show("Đã xóa thành công", "Thông báo");
                        LoadTinhThanh();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo");
                    }
                }
            }
        }

       #endregion


    }
}