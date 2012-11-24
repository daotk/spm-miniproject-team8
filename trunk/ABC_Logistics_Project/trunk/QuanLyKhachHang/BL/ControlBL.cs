using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyKhachHang.DA;

namespace QuanLyKhachHang.BL
{
    class ControlBL
    {
       
        public static bool CheckMaKH(string makh)
        {
            ABCLogisticsEntities2 context = new ABCLogisticsEntities2();
            bool check = false;
            string MaKhachHang;
            MaKhachHang = makh;
            Customer objCustomer = context.Customers.Where(p=> p.CustomerID == MaKhachHang).FirstOrDefault();
            if (objCustomer != null)
            {
                check = true;
            }
            else
            {
                check = false;
            }
            return check;
        }

        public void SearchCustomer(string MaKH)
        {
            
        }

    }
}
