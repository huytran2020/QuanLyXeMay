using BLL_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace CuaHangXeMay
{
    public partial class FormPhieuBaoHanh : Form
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public FormPhieuBaoHanh()
        {
            InitializeComponent();
        }

        private void dataGridViewBaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void txtMaXeMay_TextChanged(object sender, EventArgs e)
        {
            dataGridViewBaoHanh.DataSource = xm.PHIEUBAOHANHs.Where(nv => nv.MAPBH.Contains(txtMaXeMay.Text));
        }
    }
}
