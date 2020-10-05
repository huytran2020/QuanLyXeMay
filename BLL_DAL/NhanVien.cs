using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class NhanVien
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void LayNhanVien(DataGridView dataGridViewNhanVien)
        {

            var nv = from p in xm.NHANVIENs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã nhân viên");
            dt.Columns.Add("Mã chức vụ");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Năm Sinh");
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("SĐT");
            dt.Columns.Add("Email");
            dt.Columns.Add("Lương CB");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MANV.Trim(),nv1.MACHUCVU.Trim(),nv1.TENNV.Trim(), nv1.GIOITINH.Trim(), nv1.NAMSINH, nv1.DIACHINV.Trim(), nv1.SDTNV.Trim(),nv1.EMAILNV.Trim(), nv1.LUONG);
            }
            dataGridViewNhanVien.DataSource = dt;
        }
        public IQueryable <NHANVIEN> loadNV()
        {
            return xm.NHANVIENs.Select(t => t);
        }
        public void LoadChucVu(ComboBox cbbChucVu)
        {
            for (int i = cbbChucVu.Items.Count - 1; i >= 0; i--)
            {
                cbbChucVu.Items.RemoveAt(i);
            }
            cbbChucVu.Items.Add("Tất Cả");

            var dc = from p in xm.NHANVIENs group p by p.MACHUCVU into g select new { dc = g.Key };
            foreach (var i in dc)
            {
                cbbChucVu.Items.Add(i.dc.Trim());
            }
        }
        public void LoadGioiTinh(ComboBox cbbGioiTinh)
        {
            for (int i = cbbGioiTinh.Items.Count - 1; i >= 0; i--)
            {
                cbbGioiTinh.Items.RemoveAt(i);
            }
            cbbGioiTinh.Items.Add("Tất Cả");

            var dc = from p in xm.NHANVIENs group p by p.GIOITINH into g select new { dc = g.Key };
            foreach (var i in dc)
            {
                cbbGioiTinh.Items.Add(i.dc.Trim());
            }
        }
        public void ThemNV(string MNV, string MCV, string HT, string PH, string NS, string DC, string SDT, string EMAIL, string LCB)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = MNV;
            nv.MACHUCVU = MCV;
            nv.TENNV = HT;
            nv.GIOITINH = PH;
            nv.NAMSINH = int.Parse(NS);
            nv.DIACHINV = DC;
            nv.SDTNV = SDT;
            nv.EMAILNV = EMAIL;
            nv.LUONG = int.Parse(LCB);
            xm.NHANVIENs.InsertOnSubmit(nv);
            xm.SubmitChanges();
        }
        public void SuaNV(string MaNV,string MCV,string HT, string PH, string NS, string DC, string SDT, string EMAIL, string LCB)
        {

            var nv = (from a in xm.NHANVIENs where a.MANV == MaNV select a).SingleOrDefault();
            if (nv != null)
            {
                nv.MACHUCVU = MCV;
                nv.TENNV = HT;
                nv.GIOITINH = PH;
                nv.NAMSINH = int.Parse(NS);
                nv.DIACHINV = DC;
                nv.SDTNV = SDT;
                nv.EMAILNV = EMAIL;
                nv.LUONG = int.Parse(LCB);
                xm.SubmitChanges();
            }
        }
        public void XoaNV(string Manv)
        {
            NHANVIEN nv;
            nv = xm.NHANVIENs.Where(t => t.MANV == Manv).FirstOrDefault();
            if (nv != null)
            {
                xm.NHANVIENs.DeleteOnSubmit(nv);
                xm.SubmitChanges();
            }
        }
        public void Loc(ComboBox cbbChucVu, ComboBox cbbGT, TextBox txtTKiem, DataGridView dtgvtt)
        {
            try
            {
                if (cbbChucVu.Text == "Tất Cả" && cbbGT.Text == "Tất Cả")
                {
                    try
                    {

                        var tim = (from p in xm.NHANVIENs
                                   where p.TENNV.Contains(txtTKiem.Text)
                                   select new
                                   {
                                       p.MANV,
                                       p.MACHUCVU,
                                       p.TENNV,
                                       p.GIOITINH,
                                       p.NAMSINH,
                                       p.DIACHINV,
                                       p.SDTNV,
                                       p.EMAILNV,
                                       p.LUONG
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã nhân vien");
                        dt.Columns.Add("Mã chức vụ");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Giới tính");
                        dt.Columns.Add("Năm Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Email");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.MACHUCVU.Trim(),i.TENNV.Trim(), i.GIOITINH.Trim(), i.NAMSINH.ToString().Substring(0, 10), i.DIACHINV.Trim(), i.SDTNV.Trim(), i.EMAILNV.ToString().Substring(0, 10), i.LUONG.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }

                }
                else if (cbbChucVu.Text == "Tất Cả" && cbbGT.Text != "Tất Cả")
                {
                    try
                    {

                        var tim = (from p in xm.NHANVIENs
                                   where p.TENNV.Contains(txtTKiem.Text) && p.GIOITINH.Trim() == cbbGT.Text
                                   select new
                                   {
                                       p.MANV,
                                       p.MACHUCVU,
                                       p.TENNV,
                                       p.GIOITINH,
                                       p.NAMSINH,
                                       p.DIACHINV,
                                       p.SDTNV,
                                       p.EMAILNV,
                                       p.LUONG
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã nhân vien");
                        dt.Columns.Add("Mã chức vụ");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Giới tính");
                        dt.Columns.Add("Năm Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Email");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.MACHUCVU.Trim(), i.TENNV.Trim(), i.GIOITINH.Trim(), i.NAMSINH.ToString().Substring(0, 10), i.DIACHINV.Trim(), i.SDTNV.Trim(), i.EMAILNV.ToString().Substring(0, 10), i.LUONG.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }
                }
                else if (cbbChucVu.Text != "Tất Cả" && cbbGT.Text == "Tất Cả")
                {
                    try
                    {

                        var tim = (from p in xm.NHANVIENs
                                   where p.TENNV.Contains(txtTKiem.Text) && p.MACHUCVU == cbbChucVu.Text
                                   select new
                                   {
                                       p.MANV,
                                       p.MACHUCVU,
                                       p.TENNV,
                                       p.GIOITINH,
                                       p.NAMSINH,
                                       p.DIACHINV,
                                       p.SDTNV,
                                       p.EMAILNV,
                                       p.LUONG
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã nhân vien");
                        dt.Columns.Add("Mã chức vụ");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Giới tính");
                        dt.Columns.Add("Năm Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Email");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.MACHUCVU.Trim(), i.TENNV.Trim(), i.GIOITINH.Trim(), i.NAMSINH.ToString().Substring(0, 10), i.DIACHINV.Trim(), i.SDTNV.Trim(), i.EMAILNV.ToString().Substring(0, 10), i.LUONG.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }
                }

                else
                {
                    try
                    {

                        var tim = (from p in xm.NHANVIENs
                                   where p.TENNV.Contains(txtTKiem.Text) && p.MACHUCVU == cbbChucVu.Text && p.GIOITINH == cbbGT.Text
                                   select new
                                   {
                                       p.MANV,
                                       p.MACHUCVU,
                                       p.TENNV,
                                       p.GIOITINH,
                                       p.NAMSINH,
                                       p.DIACHINV,
                                       p.SDTNV,
                                       p.EMAILNV,
                                       p.LUONG
                                   }).ToList();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Mã nhân vien");
                        dt.Columns.Add("Mã chức vụ");
                        dt.Columns.Add("Họ Tên");
                        dt.Columns.Add("Giới tính");
                        dt.Columns.Add("Năm Sinh");
                        dt.Columns.Add("Địa Chỉ");
                        dt.Columns.Add("SĐT");
                        dt.Columns.Add("Email");
                        dt.Columns.Add("Lương CB");

                        foreach (var i in tim)
                        {
                            dt.Rows.Add(i.MANV.Trim(), i.MACHUCVU.Trim(), i.TENNV.Trim(), i.GIOITINH.Trim(), i.NAMSINH.ToString().Substring(0, 10), i.DIACHINV.Trim(), i.SDTNV.Trim(), i.EMAILNV.ToString().Substring(0, 10), i.LUONG.ToString());
                        }
                        dtgvtt.DataSource = dt;
                    }
                    catch
                    {

                    }
                }
            }
            catch
            {

            }
        }
    }
}
