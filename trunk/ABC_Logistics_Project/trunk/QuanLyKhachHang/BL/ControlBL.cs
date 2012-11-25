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
            ABCLogisticEntities1 context = new ABCLogisticEntities1();
            bool check = false;
            string MaKhachHang;
            MaKhachHang = makh;
            KhachHang objCustomer = context.KhachHangs.Where(p=> p.MaCongTy == MaKhachHang).FirstOrDefault();
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
