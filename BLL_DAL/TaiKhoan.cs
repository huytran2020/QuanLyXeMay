using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class TaiKhoan
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void LayThongTin(DataGridView dataGridViewTaiKhoan)
        {
            var nv = (from p in xm.TAIKHOANs
                      join q in xm.NHANVIENs on p.MaNV equals q.MANV
                      select new
                      {
                          p.MaNV,
                          q.TENNV,
                          p.TenDangNhap,
                          p.CapQuyen,
                          p.TrangThai
                      }).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Nhân Viên");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Tên Đăng Nhập");
            dt.Columns.Add("Cấp Quyền");
            dt.Columns.Add("Trạng Thái");
            foreach (var TD in nv)
            {
                dt.Rows.Add(TD.MaNV.Trim(), TD.TENNV.Trim(), TD.TenDangNhap.Trim(), TD.CapQuyen.Trim(), TD.TrangThai.Trim());
            }
            dataGridViewTaiKhoan.DataSource = dt;
        }
        public string LayMaNV(string Ten)
        {
            string b = "";
            var Ma = (from p in xm.NHANVIENs
                      where p.TENNV.Trim() == Ten
                      select new
                      {
                          p.MANV
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MANV;
            }
            return b;
        }
        

        //public string LayTrangThai()
        //{
        //    string b = "";
        //    var Ma = (from p in xm.TAIKHOANs

        //              select new
        //              {
        //                  p.TrangThai
        //              }).ToList();
        //    if (Ma.Count() != 0)
        //    {
        //        foreach (var a in Ma)
        //            b = a.TrangThai;
        //    }
        //    return b;
        //}
        public string LayMK(string tdn)
        {
            string b = "";
            var Ma = (from p in xm.TAIKHOANs
                      where p.TenDangNhap.Trim() == tdn
                      select new
                      {
                          p.MatKhau
                      }).ToList();
            if (Ma.Count() != 0)
            {
                foreach (var a in Ma)
                    b = a.MatKhau;
            }
            return b;
        }
        public void SuaTK2(string MNV, string TDN, string CQ, string TT)
        {
            var td = (from a in xm.TAIKHOANs where a.TenDangNhap == TDN select a).SingleOrDefault();
            if (td != null)
            {
                td.CapQuyen = CQ;
                td.TrangThai = TT;
                xm.SubmitChanges();
            }
        }
        public void SuaTK(string MNV, string TDN, string MK, string CQ, string TT)
        {
            // NhaHangEntities std = new NhaHangEntities();
            var td = (from a in xm.TAIKHOANs where a.TenDangNhap == TDN select a).SingleOrDefault();
            if (td != null)
            {
                td.MatKhau = MK;
                td.CapQuyen = CQ;
                td.TrangThai = TT;
                xm.SubmitChanges();
            }
        }
        public void XoaTK(string ma)
        {

            TAIKHOAN td;
            td = xm.TAIKHOANs.Where(t => t.MaNV == ma).FirstOrDefault();
            if (td != null)
            {
                xm.TAIKHOANs.DeleteOnSubmit(td);
                xm.SubmitChanges();
            }

        }
        public void ThemTK(string MNV, string TDN, string MK, string CQ, string TT)
        {

            TAIKHOAN td = new TAIKHOAN();
            td.MaNV = MNV;
            td.TenDangNhap = TDN;
            td.MatKhau = MK;
            td.CapQuyen = CQ;
            td.TrangThai = TT;
            xm.TAIKHOANs.InsertOnSubmit(td);
            xm.SubmitChanges();
        }
        public void LoadCBBTenNV(ComboBox cbb)
        {
            for (int i = cbb.Items.Count - 1; i >= 0; i--)
            {
                cbb.Items.RemoveAt(i);
            }
            var HT = from a in xm.NHANVIENs
                     select new
                     {
                         a.TENNV
                     };
            foreach (var x in HT)
            {
                cbb.Items.Add(x.TENNV.Trim());
            }
        }
    }
}
