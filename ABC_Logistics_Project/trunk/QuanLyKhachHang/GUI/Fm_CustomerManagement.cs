using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachHang.DA;
using System.Data.SqlClient;

namespace QuanLyKhachHang.GUI
{
    public partial class Fm_CustomerManagement : Form
    {
        string strStatusCheck;
        ABCLogisticEntities context = new ABCLogisticEntities();
        string StrUsername;
        public Fm_CustomerManagement(string strUsername)
        {
            StrUsername = strUsername;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Xủ lý khi nhap nut Edit tren giao dien Customer management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Fm_EditCustomer Fedit = new Fm_EditCustomer();
            if (Fedit.ShowDialog() == DialogResult.Cancel)
            {
                if (strStatusCheck == rdAgent.Text)
                {
                    LoadData_WhenRadioChange(rdAgent.Text);
                }
                else
                {
                    if (strStatusCheck == rdDoiTacKhachHang.Text)
                    {
                        LoadData_WhenRadioChange(rdDoiTacKhachHang.Text);
                    }
                    else
                    {
                        if (strStatusCheck == rdKhachHang.Text)
                        {
                            LoadData_WhenRadioChange(rdKhachHang.Text);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Xử lý chọn hết text trong ô tìm kiếm khi chọn vào nó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.SelectAll();
        }

        /// <summary>
        /// load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            cboTimKiemTheo.SelectedIndex = 0;
            rdKhachHang.Checked=true;
            lblTenNhanVien.Text = StrUsername;
        }

        /// <summary>
        /// Add new custommer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Fm_AddNewCustomer Fadd = new Fm_AddNewCustomer(StrUsername);
            if (Fadd.ShowDialog() == DialogResult.Cancel)
            {
                if (strStatusCheck == rdAgent.Text)
                {
                    LoadData_WhenRadioChange(rdAgent.Text);
                }
                else
                {
                    if (strStatusCheck == rdDoiTacKhachHang.Text)
                    {
                        LoadData_WhenRadioChange(rdDoiTacKhachHang.Text);
                    }
                    else
                    {
                        if (strStatusCheck == rdKhachHang.Text)
                        {
                            LoadData_WhenRadioChange(rdKhachHang.Text);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Xu ly khi nhap double vao 1 cell trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string makh = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Fm_ViewCustomer Fview = new Fm_ViewCustomer(makh);
            if (Fview.ShowDialog() == DialogResult.Cancel)
            {
                if (strStatusCheck == rdAgent.Text)
                {
                    LoadData_WhenRadioChange(rdAgent.Text);
                }
                else
                {
                    if (strStatusCheck == rdDoiTacKhachHang.Text)
                    {
                        LoadData_WhenRadioChange(rdDoiTacKhachHang.Text);
                    }
                    else
                    {
                        if (strStatusCheck == rdKhachHang.Text)
                        {
                            LoadData_WhenRadioChange(rdKhachHang.Text);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// xu ly su kien khi đánh text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      
            //khach hang
            if (strStatusCheck == rdKhachHang.Text)
            {
                if (cboTimKiemTheo.Text == "Mã khách hàng")
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.MaCongTy.Contains(txttext)) && (p.LoaiKhachHang == rdKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    dataGridView1.DataSource = customer.ToList();
                    //stt
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                  
                }
                else
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.TenCTyV.Contains(txttext)) && (p.LoaiKhachHang == rdKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    dataGridView1.DataSource = customer.ToList();
                    //stt
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                   
                }
            }
            
            //Agent
            if (strStatusCheck == rdAgent.Text)
            {
                if (cboTimKiemTheo.Text == "Mã khách hàng")
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.MaCongTy.Contains(txttext)) && (p.LoaiKhachHang == rdAgent.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    dataGridView1.DataSource = customer.ToList();
                    //stt
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                   
                }
                else
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.TenCTyV.Contains(txttext)) && (p.LoaiKhachHang == rdAgent.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    dataGridView1.DataSource = customer.ToList();
                    //stt
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                   
                }
            }

            //Doi tac
            if (strStatusCheck == rdDoiTacKhachHang.Text)
            {
                if (cboTimKiemTheo.Text == "Mã khách hàng")
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.MaCongTy.Contains(txttext)) && (p.LoaiKhachHang == rdDoiTacKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    dataGridView1.DataSource = customer.ToList();
                    //stt
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                    
                }
                else
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.TenCTyV.Contains(txttext)) && (p.LoaiKhachHang == rdDoiTacKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    dataGridView1.DataSource = customer.ToList();
                    //stt
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    }
                  
                }
            }
        }

        /// <summary>
        /// lọc danh sách khách hàng khi check vào radio khách hàng và cho biến strStatus = Khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            LoadData_WhenRadioChange(rdKhachHang.Text);
            strStatusCheck = rdKhachHang.Text;
        }

        /// <summary>
        /// loc danh sach agent khi check vao radio agent và cho biến strStatus = Agent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {

            LoadData_WhenRadioChange(rdAgent.Text);
            strStatusCheck = rdAgent.Text;
        }

        /// <summary>
        /// loc danh sach doi tac khach hang khi check vao nut đối tác khách hàng và cho biến strStatus = Đối tác khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDoiTacKhachHang_CheckedChanged(object sender, EventArgs e)
        {

           LoadData_WhenRadioChange(rdDoiTacKhachHang.Text);
           strStatusCheck = rdDoiTacKhachHang.Text;
        }

        /// <summary>
        /// lộc danh sách khi chọn radio button
        /// </summary>
        /// <param name="macheck">loại khách hàng cần phải lộc</param>
        private void LoadData_WhenRadioChange(string macheck)
        {
            var cus = from p in context.GetLoaiKhachHang(macheck)
                      select new { p.MaCongTy, p.TenCTyV, p.TinhThanhTa.TenTinhThanh, p.QuocGiaTa.TenQuocGia, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
            dataGridView1.DataSource = cus.ToList();
            //stt
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }


        }
    }
