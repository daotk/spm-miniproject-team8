using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyKhachHang.GUI
{
    public partial class Fm_CauHinh : Form
    {
        public delegate void ReturnResult(string strUerName,string strPassWord, string strLinkFile);
        public event ReturnResult returndata;
        public Fm_CauHinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                txtFileData.Text = folderBrowserDialog1.SelectedPath;   
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (this.returndata != null)
            {
                this.returndata(txtLogin.Text,txtPassword.Text,txtFileData.Text);
            }
            this.Close();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
