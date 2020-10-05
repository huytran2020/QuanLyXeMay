using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BLL_DAL
{
    public class QLPhieuXuat
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void LayPhieuXuat(DataGridView dataGridViewPhieuXuat)
        {

            var nv = from p in xm.PHIEUXUATs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phiếu xuất");
            dt.Columns.Add("Ngày lập");
            dt.Columns.Add("Nhân viên lập");
            dt.Columns.Add("Tên khách hàng");
            dt.Columns.Add("Tổng tiền");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MAPX.Trim(), nv1.NGAYXUAT, nv1.MANV.Trim(), nv1.MAKH.Trim(), nv1.TONGTIENPX);
            }
            dataGridViewPhieuXuat.DataSource = dt;
        }
        public void ThemPhieuXuat(string MaPX, string ngaylap, string MaNV, string MaKH, double tongtien)
        {
            PHIEUXUAT px = new PHIEUXUAT();
            px.MAPX = MaPX;
            px.NGAYXUAT = DateTime.Parse(ngaylap);
            px.MANV = MaNV;
            px.MAKH = MaKH;
            px.TONGTIENPX = tongtien;
            xm.PHIEUXUATs.InsertOnSubmit(px);
            xm.SubmitChanges();
        }
        public void SuaPhieuXuat(string MaPX, string ngaylap, string MaNV, string MaKH, double tongtien)
        {

            var nv = (from a in xm.PHIEUXUATs where a.MAPX == MaPX select a).SingleOrDefault();
            if (nv != null)
            {
                nv.MAPX = MaPX;
                nv.NGAYXUAT = DateTime.Parse(ngaylap);
                nv.MANV = MaNV;
                nv.MAKH = MaKH;
                nv.TONGTIENPX = tongtien;
                xm.SubmitChanges();
            }
        }
        public void XoaPhieuXuat(string MaPX)
        {
            PHIEUXUAT nv;
            nv = xm.PHIEUXUATs.Where(t => t.MAPX == MaPX).FirstOrDefault();
            if (nv != null)
            {
                xm.PHIEUXUATs.DeleteOnSubmit(nv);
                xm.SubmitChanges();
            }
        }
    }
}
