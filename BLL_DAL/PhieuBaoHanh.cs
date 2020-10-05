using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class PhieuBaoHanh
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public IQueryable<PHIEUBAOHANH> GetPHIEUBAOHANHs()
        {
            return xm.PHIEUBAOHANHs.Select(t => t);
        }

        public void themP(string map, string maxe, string ngay, string manv, string makh, string tr)
        {
            PHIEUBAOHANH hh = new PHIEUBAOHANH();
            hh.MAPBH = map;
            hh.MAXE = maxe;
            hh.NGAY = DateTime.Parse(ngay);
            hh.MANV = manv;
            hh.MAKH = makh;
            hh.TINHTRANG = tr;
            xm.PHIEUBAOHANHs.InsertOnSubmit(hh);
            xm.SubmitChanges();
        }

        public void xoaP(string map)
        {
            PHIEUBAOHANH pp = xm.PHIEUBAOHANHs.Where(t => t.MAPBH == map).FirstOrDefault();
            if (pp != null)
            {
                xm.PHIEUBAOHANHs.DeleteOnSubmit(pp);
                xm.SubmitChanges();
            }
        }

        public void suaP(string map, string maxe, string ngay, string manv, string makh, string tr)
        {
            var hh = (from d in xm.PHIEUBAOHANHs where d.MAPBH == map select d).SingleOrDefault();
            if (hh != null)
            {
                hh.MAXE = maxe;
                hh.NGAY = DateTime.Parse(ngay);
                hh.MANV = manv;
                hh.MAKH = makh;
                hh.TINHTRANG = tr;
                xm.SubmitChanges();
            }
        }
    }
}
