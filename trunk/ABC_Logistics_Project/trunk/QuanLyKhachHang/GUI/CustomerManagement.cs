﻿using System;
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
    public partial class CustomerManagement : Form
    {

        ABCLogisticEntities1 context = new ABCLogisticEntities1();
        public CustomerManagement()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        /// <summary>
        /// chinh sua thong tin khach hang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EditCustomer EditCustomer = new EditCustomer();
            EditCustomer.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            EditCustomer Fedit = new EditCustomer();
            Fedit.ShowDialog();

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
            Load_Data();
            cboTimKiemTheo.SelectedIndex = 0;
            rdKhachHang.Checked=true;
        }
        /// <summary>
        /// Add new custommer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            AddNewCustomer Fadd = new AddNewCustomer();
            if (Fadd.ShowDialog() == DialogResult.Cancel)
            {
                Load_Data();
            }
        }

        public void Load_Data()
        {
            var cus = from p in context.KhachHangs select new { p.MaCongTy, p.TenCTyV, p.DiaChi, p.TinhThanh,p.TenQuocGia, p.Sdt, p.LinhVucKinhDoanh, p.NhanVienQuanLy };
            dataGridView1.DataSource = cus.ToList();
            //Chỉnh màu cho từng dòng trong datagirdview
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (i%2==0)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                }
            }
        }
        /// <summary>
        /// Xu ly1 khi nhap double vao 1 cell trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string makh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ViewCustomer Fview = new ViewCustomer(makh);
            Fview.ShowDialog();
        }
        /// <summary>
        /// xu ly su kien khi đánh text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string txttext = txtTimKiem.Text;
            ABCLogisticEntities1 context = new ABCLogisticEntities1();
            var customer = from p in context.KhachHangs
                           where p.MaCongTy.Contains(txttext)
                           select new { p.MaCongTy, p.TenCTyV, p.TenCTyE, p.DiaChi, p.Sdt, p.LinhVucKinhDoanh, p.NhanVienQuanLy };
            dataGridView1.DataSource = customer.ToList();


        }
        /// <summary>
        /// check vào nút khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdKhachHang_CheckedChanged(object sender, EventArgs e)
        {
            Load_Data();
        }
         
          
        }



    }
