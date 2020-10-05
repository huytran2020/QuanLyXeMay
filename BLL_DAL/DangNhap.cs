using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class DangNhap
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public IQueryable<TAIKHOAN> getTenDangNhap( string dn)
        {
            var tk = from k in xm.TAIKHOANs where k.TenDangNhap == dn select k;
            return tk;
        }
        public IQueryable<TAIKHOAN> getMatKhau(string mk)
        {
            var pass = from k in xm.TAIKHOANs where k.MatKhau == mk select k;
            return pass;
        }
        public int LayTaiKhoan(string user, string password)
        {
            var tk = (from x in xm.TAIKHOANs
                      where x.TenDangNhap.Trim() == user && x.MatKhau.Trim() == password
                      select x).ToList();
            int a = tk.Count();
            return a;
        }
        public string LayTenNV(string user, string password)
        {
            string b = "";
            var Tennv = (from p in xm.NHANVIENs
                         join q in xm.TAIKHOANs on p.MANV equals q.MaNV
                         where q.TenDangNhap.Trim() == user && q.MatKhau.Trim() == password
                         select new
                         {
                             p.TENNV
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.TENNV;
            }
            return b;
        }
        public string LayQuyenNV(string user, string password)
        {
            string b = "";
            var Tennv = (from p in xm.TAIKHOANs
                         where p.TenDangNhap.Trim() == user && p.MatKhau.Trim() == password
                         select new
                         {
                             p.CapQuyen
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.CapQuyen;
            }
            return b;
        }
        public string LayMaNV(string user, string password)
        {
          
            string b = "";
            var Tennv = (from p in xm.TAIKHOANs
                         where p.TenDangNhap.Trim() == user && p.MatKhau.Trim() == password
                         select new
                         {
                             p.MaNV
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.MaNV;
            }
            return b;
        }
        public string LayTrangThai(string user, string password)
        {
            string b = "";
            var Tennv = (from p in xm.TAIKHOANs
                         where p.TenDangNhap.Trim() == user && p.MatKhau.Trim() == password
                         select new
                         {
                             p.TrangThai
                         }).ToList();
            if (Tennv.Count() != 0)
            {
                foreach (var a in Tennv)
                    b = a.TrangThai;
            }
            return b;
        }
    }
}
