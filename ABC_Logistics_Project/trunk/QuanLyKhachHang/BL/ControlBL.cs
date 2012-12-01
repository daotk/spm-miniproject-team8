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
            ABCLogisticEntities context = new ABCLogisticEntities();
            bool check = false;
            string MaKhachHang;
            MaKhachHang = makh;
            KhachHangTa objCustomer = context.KhachHangTas.Where(p=> p.MaCongTy == MaKhachHang).FirstOrDefault();
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
        public static bool CheckMangoaite(string mangoaite)
        {
            ABCLogisticEntities context = new ABCLogisticEntities();
            bool check = false;
            string MaNgoaiTe;
            MaNgoaiTe = mangoaite;
            NgoaiTeTa objCustomer = context.NgoaiTeTas.Where(p => p.MaNgoaiTe == MaNgoaiTe).FirstOrDefault();
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
    }
}
