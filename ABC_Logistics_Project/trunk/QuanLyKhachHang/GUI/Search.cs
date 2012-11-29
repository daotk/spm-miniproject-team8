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
    public partial class Search : Form
    {
        public delegate void Editcusdelegate(string item);
        public event Editcusdelegate submit;
        ABCLogisticEntities context = new ABCLogisticEntities();
        string strStatusCheck;
        public Search()
        {
            InitializeComponent();
        }
        /// <summary>
        /// tim kiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txttukhoa_TextChanged(object sender, EventArgs e)
        {
            //khach hang
            if (strStatusCheck == rdKhachHang.Text)
            {
                if (cboTimKiemTheo.Text == "Mã công ty")
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.MaCongTy.Contains(txttext)) && (p.LoaiKhachHang == rdKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    grdtimkiem.DataSource = customer.ToList();
                }
                else
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.TenCTyV.Contains(txttext)) && (p.LoaiKhachHang == rdKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    grdtimkiem.DataSource = customer.ToList();
                }
            }

            //Agent
            if (strStatusCheck == rdAgent.Text)
            {
                if (cboTimKiemTheo.Text == "Tên công ty")
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.MaCongTy.Contains(txttext)) && (p.LoaiKhachHang == rdAgent.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    grdtimkiem.DataSource = customer.ToList();
                }
                else
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.TenCTyV.Contains(txttext)) && (p.LoaiKhachHang == rdAgent.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    grdtimkiem.DataSource = customer.ToList();
                }
            }

            //Doi tac
            if (strStatusCheck == rdDoiTacKhachHang.Text)
            {
                if (cboTimKiemTheo.Text == "Tên công ty")
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.MaCongTy.Contains(txttext)) && (p.LoaiKhachHang == rdDoiTacKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    grdtimkiem.DataSource = customer.ToList();
                }
                else
                {
                    string txttext = txtTimKiem.Text;
                    var customer = from p in context.KhachHangTas
                                   where ((p.TenCTyV.Contains(txttext)) && (p.LoaiKhachHang == rdDoiTacKhachHang.Text))
                                   select new { p.MaCongTy, p.TenCTyV, p.QuocGiaTa.TenQuocGia, p.TinhThanhTa.TenTinhThanh, p.DiaChi, p.Sdt, p.LinhVucKinhDoanhTa.TenLVKD, p.NhanVienTa.HovTen };
                    grdtimkiem.DataSource = customer.ToList();
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
        /// Xu ly1 khi nhap double vao 1 cell trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string makh = grdtimkiem.CurrentRow.Cells[0].Value.ToString();
            if (this.submit != null)
            {
                this.submit(makh);
            }
            this.Close();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strStatusCheck = rdKhachHang.Text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdAgent_CheckedChanged(object sender, EventArgs e)
        {
            strStatusCheck = rdAgent.Text;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDoiTacKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            strStatusCheck = rdDoiTacKhachHang.Text;
        }
        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Load(object sender, EventArgs e)
        {
            cboTimKiemTheo.SelectedIndex = 0;
            rdKhachHang.Checked = true;
        }


    }
}
