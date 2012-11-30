using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachHang.DA;
using QuanLyKhachHang.GUI;

namespace QuanLyKhachHang
{
    public partial class Login : Form
    {
        ABCLogisticEntities context = new ABCLogisticEntities();
        public Login()
        {
            InitializeComponent();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sử lý nút cancel trong Form Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban muon thoat?", "Canh bao", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Xủ lý sự kiện nút đồng ý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string strUsername= txtUsername.Text;
            string strPassword = txtPassword.Text;
            //
            NhanVienTa objNhanvien = context.NhanVienTas.Where(p => p.TendangNhap == strUsername).FirstOrDefault();
            if (objNhanvien != null)
            {
                var nhanvien = from p in context.NhanVienTas
                               where p.TendangNhap == strUsername
                               select p.MatKhauDangNhap;
                if (objNhanvien.MatKhauDangNhap == strPassword)
                {
                    
                    MessageBox.Show("Bạn đã đăng nhập thành công! Ấn Ok để vào giao diện chính","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    DialogResult result = System.Windows.Forms.DialogResult.OK;
                    if (result == DialogResult.OK)
                    {
                        MainForm Fmain = new MainForm(objNhanvien.HovTen);
                        this.Visible = false;
                        Fmain.ShowDialog();
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        this.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập xai mật khẩu!");
                }
            }
            else
            {
                MessageBox.Show("Bạn đã nhập xai tên tài khoản");
            }

        }
    }
}
