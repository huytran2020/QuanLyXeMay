using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class PhieuNhap
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void layThongTin(DataGridView dataGridViewPhieuNhap)
        {
            var nv = from p in xm.PHIEUNHAPs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phiếu nhập");
            dt.Columns.Add("Mã nhà cung cấp");
            dt.Columns.Add("Mã nhân viên");
            dt.Columns.Add("Ngày nhập");
            dt.Columns.Add("Thanh toán");
            dt.Columns.Add("Tổng tiền");
            dt.Columns.Add("Số tiền đã trả");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MAPN.Trim(), nv1.MANCC.Trim(), nv1.MANV.Trim(), nv1.NGAYNHAP, nv1.THANHTOAN, nv1.TONGTIENPN, nv1.SOTIENDATRA);
            }
            dataGridViewPhieuNhap.DataSource = dt;

        }
        public void ThemPhieuNhap(string MaPN, string MaNCC, string MaNV ,string ngaynhap, int thanhtoan, double tongtien, double sotiendatra)
        {
            PHIEUNHAP px = new PHIEUNHAP();
            px.MAPN = MaPN;
            px.MANCC = MaNCC;
            px.MANV = MaNV;           
            px.NGAYNHAP = DateTime.Parse(ngaynhap);
            px.TONGTIENPN = tongtien;
            xm.PHIEUNHAPs.InsertOnSubmit(px);
            xm.SubmitChanges();
        }
        public void SuaPhieuNhap(string MaPN, string MaNCC, string MaNV, string ngaynhap, int thanhtoan, double tongtien, double sotiendatra)
        {

            var px = (from a in xm.PHIEUNHAPs where a.MAPN == MaPN select a).SingleOrDefault();
            if (px != null)
            {
                px.MAPN = MaPN;
                px.MANCC = MaNCC;
                px.MANV = MaNV;
                px.NGAYNHAP = DateTime.Parse(ngaynhap);
                px.TONGTIENPN = tongtien;
                xm.SubmitChanges();
            }
        }
        public void XoaPhieuNhap(string MaPN)
        {
            PHIEUNHAP nv;
            nv = xm.PHIEUNHAPs.Where(t => t.MAPN == MaPN).FirstOrDefault();
            if (nv != null)
            {
                xm.PHIEUNHAPs.DeleteOnSubmit(nv);
                xm.SubmitChanges();
            }
        }
        public IQueryable<NHACUNGCAP> loadTenNCC()
        {
            return xm.NHACUNGCAPs.Select(sv => sv);
        }
        public IQueryable<NHANVIEN> LoadMaNV()
        {
            return xm.NHANVIENs.Select(k => k);
        }
    }
}
