using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class KhachHang
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public KhachHang()
        {

        }
        public IQueryable<KHACHHANG> GetKHACHHANGs()
        {
            return xm.KHACHHANGs.Select(k => k);
        }
        public void ThemKH(string MaKH, string TenKH, string diachi, string sdt, string email,string cmnd)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.MAKH = MaKH;
            kh.TENKH = TenKH;
            kh.DIACHIKH = diachi;
            kh.SDTKH = sdt;
            kh.EMAILKH = email;
            kh.CMND = cmnd;
            xm.KHACHHANGs.InsertOnSubmit(kh);
            xm.SubmitChanges();
        }
        public void SuaKH(string MaKH, string TenKH, string diachi, string sdt, string email, string cmnd)
        {

            var kh = (from a in xm.KHACHHANGs where a.MAKH == MaKH select a).SingleOrDefault();
            if (kh != null)
            {
                kh.MAKH = MaKH;
                kh.TENKH = TenKH;
                kh.DIACHIKH = diachi;
                kh.SDTKH = sdt;
                kh.EMAILKH = email;
                kh.CMND = cmnd;
                xm.SubmitChanges();
            }
        }
        public void XoaKH(string Makh)
        {
            KHACHHANG kh;
            kh = xm.KHACHHANGs.Where(t => t.MAKH == Makh).FirstOrDefault();
            if (kh != null)
            {
                xm.KHACHHANGs.DeleteOnSubmit(kh);
                xm.SubmitChanges();
            }
        }
    }
}
