
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
    public partial class frm_PhieuBaoHanh : Form
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        PhieuBaoHanh phieu = new PhieuBaoHanh();
        public frm_PhieuBaoHanh()
        {
            InitializeComponent();
        }

        private void dataGridViewBaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaXeMay.Enabled = txtMaPhieuBH.Enabled = txtNhanVien.Enabled = txtTinhTrang.Enabled = cbbKhachHang.Enabled = cbbNgayLap.Enabled = cbbNVSuaChua.Enabled = true;
            btn_Huy.Enabled = btn_Sua.Enabled = btn_Luu.Enabled = btn_Xoa.Enabled = false;
            int num = dataGridViewBaoHanh.CurrentCell.RowIndex;
            txtMaPhieuBH.Text = dataGridViewBaoHanh.Rows[num].Cells[0].Value.ToString();
            txtMaXeMay.Text = dataGridViewBaoHanh.Rows[num].Cells[1].Value.ToString();
            cbbNgayLap.Text = dataGridViewBaoHanh.Rows[num].Cells[2].Value.ToString();
            txtNhanVien.Text = dataGridViewBaoHanh.Rows[num].Cells[3].Value.ToString();
            cbbKhachHang.Text = dataGridViewBaoHanh.Rows[num].Cells[4].Value.ToString();
        }

        public void loaddatagridview()
        {
            dataGridViewBaoHanh.DataSource = phieu.GetPHIEUBAOHANHs();
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

        private void btn_Sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }

        private void frm_PhieuBaoHanh_Load(object sender, EventArgs e)
        {
            loaddatagridview();
            int num = dataGridViewBaoHanh.CurrentCell.RowIndex;
            txtMaPhieuBH.Text = dataGridViewBaoHanh.Rows[num].Cells[0].Value.ToString();
            txtMaXeMay.Text = dataGridViewBaoHanh.Rows[num].Cells[1].Value.ToString();
            cbbNgayLap.Text = dataGridViewBaoHanh.Rows[num].Cells[2].Value.ToString();
            txtNhanVien.Text = dataGridViewBaoHanh.Rows[num].Cells[3].Value.ToString();
            cbbKhachHang.Text = dataGridViewBaoHanh.Rows[num].Cells[4].Value.ToString();
        }
    }
}
