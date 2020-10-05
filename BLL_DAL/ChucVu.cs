using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class ChucVu
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void LayChucVu(DataGridView dataGridViewChucVu)
        {

            var nv = from p in xm.CHUCVUs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã chức vụ");
            dt.Columns.Add("Tên chức vụ");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MACHUCVU.Trim(), nv1.TENCHUCVU.Trim());
            }
            dataGridViewChucVu.DataSource = dt;
        }
        public void ThemChucVu(string MaCV, string TenCV)
        {
            CHUCVU nv = new CHUCVU();
            nv.MACHUCVU = MaCV;
            nv.TENCHUCVU = TenCV;         
            xm.CHUCVUs.InsertOnSubmit(nv);
            xm.SubmitChanges();
        }
        public void SuaLX(string MaCV, string TenCV)
        {

            var nv = (from a in xm.CHUCVUs where a.MACHUCVU == MaCV select a).SingleOrDefault();
            if (nv != null)
            {
                nv.MACHUCVU = MaCV;
                nv.TENCHUCVU = TenCV;        
                xm.SubmitChanges();
            }
        }
        public void XoaNV(string Manv)
        {
            CHUCVU nv;
            nv = xm.CHUCVUs.Where(t => t.MACHUCVU == Manv).FirstOrDefault();
            if (nv != null)
            {
                xm.CHUCVUs.DeleteOnSubmit(nv);
                xm.SubmitChanges();
            }
        }
    }
}
