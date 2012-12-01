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
    public partial class add_ : Form
    {
        bool CheckMangoaite = false;
        ABCLogisticEntities context=new ABCLogisticEntities();
        NgoaiTeTa p = new NgoaiTeTa();
        public add_()
        {
            InitializeComponent();
        }

       
        /// <summary>
        /// xu li button huy bo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// xu li kiem tra ma ngoai te
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            string mangoaite = txtmangoaite.Text;
            if (mangoaite == "")
            {
                MessageBox.Show("Thieu ma ngoai te. Vui long nhap ma ngoai te");
            }
            else
            {
                if (ControlBL.CheckMangoaite(mangoaite) == true)
                {
                    MessageBox.Show("ma ngoai te da ton tai! Xin vui lòng điền vào mã khách hành khác!");
                }
                else
                {
                    MessageBox.Show(" hợp lệ! Bạn có thể nhập tiếp các thông tin khác!");
                    CheckMangoaite = true;
                }
            }
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
    }
}
