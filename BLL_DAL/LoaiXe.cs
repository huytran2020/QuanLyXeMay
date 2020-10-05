using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class LoaiXe
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void LayLoaiXe(DataGridView dataGridViewLoaiXe)
        {

            var nv = from p in xm.LOAIXEs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã loại xe");
            dt.Columns.Add("Tên loại xe");               
            dt.Columns.Add("Đơn giá nhập");
            dt.Columns.Add("Đơn giá");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MAHANG.Trim(), nv1.TENHANG.Trim(), nv1.DONGIANHAP, nv1.DONGIA);
            }
            dataGridViewLoaiXe.DataSource = dt;
        }
        public IQueryable<LOAIXE> GetLOAIXEs()
        {
            var lx = from xe in xm.LOAIXEs select xe;
            return lx;
        }
        public void ThemLoaiXe(string MaLX, string TenLX, int Dongianhap, int Dongia)
        {
            LOAIXE nv = new LOAIXE();
            nv.MAHANG = MaLX;
            nv.TENHANG = TenLX;
            nv.DONGIANHAP = Dongia;
            nv.DONGIA = Dongia;
            xm.LOAIXEs.InsertOnSubmit(nv);
            xm.SubmitChanges();
        }
        public void SuaLX(string MaLX, string TenLX, int Dongianhap, int Dongia)
        {

            var nv = (from a in xm.LOAIXEs where a.MAHANG == MaLX select a).SingleOrDefault();
            if (nv != null)
            {
                nv.MAHANG = MaLX;
                nv.TENHANG = TenLX;
                nv.DONGIANHAP = Dongianhap;
                nv.DONGIA = Dongia;          
                xm.SubmitChanges();
            }
        }
        public void XoaNV(string Manv)
        {
            LOAIXE nv;
            nv = xm.LOAIXEs.Where(t => t.MAHANG == Manv).FirstOrDefault();
            if (nv != null)
            {
                xm.LOAIXEs.DeleteOnSubmit(nv);
                xm.SubmitChanges();
            }
        }
    }
}
