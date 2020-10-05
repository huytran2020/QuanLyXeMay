using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BLL_DAL
{
    public class NhaCungCap
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public void LayNhaCungCap(DataGridView dataGridView_NCC)
        {

            var nv = from p in xm.NHACUNGCAPs
                     select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã nhà cung cấp");
            dt.Columns.Add("Tên nhà cung cấp");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Số điện thoại");
            dt.Columns.Add("Email");
            foreach (var nv1 in nv)
            {
                dt.Rows.Add(nv1.MANCC.Trim(), nv1.TENNCC.Trim(), nv1.DIACHINCC.Trim(), nv1.SDTNCC, nv1.EMAILNCC.Trim());
            }
            dataGridView_NCC.DataSource = dt;
        }
        public void ThemNhaCungCap(string MaNCC, string TenNCC, string diachi, string sdt, string email )
        {
            NHACUNGCAP nv = new NHACUNGCAP();
            nv.MANCC= MaNCC;
            nv.TENNCC = TenNCC;
            nv.DIACHINCC = diachi;
            nv.SDTNCC = sdt;
            nv.EMAILNCC = email;
            xm.NHACUNGCAPs.InsertOnSubmit(nv);
            xm.SubmitChanges();
        }
        public void SuaNCC(string MaNCC, string TenNCC, string diachi, string sdt, string email)
        {

            var nv = (from a in xm.NHACUNGCAPs where a.MANCC == MaNCC select a).SingleOrDefault();
            if (nv != null)
            {
                nv.MANCC = MaNCC;
                nv.TENNCC = TenNCC;
                nv.DIACHINCC = diachi;
                nv.SDTNCC = sdt;
                nv.EMAILNCC = email;
                xm.SubmitChanges();
            }
        }
        public void XoaNCC(string MaNCC)
        {
            NHACUNGCAP nv;
            nv = xm.NHACUNGCAPs.Where(t => t.MANCC == MaNCC).FirstOrDefault();
            if (nv != null)
            {
                xm.NHACUNGCAPs.DeleteOnSubmit(nv);
                xm.SubmitChanges();
            }
        }
    }

}
