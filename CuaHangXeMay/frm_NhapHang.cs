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
    public partial class frm_NhapHang : Form
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        PhieuNhap pn = new PhieuNhap();
        bool them = false;
        public frm_NhapHang()
        {
            InitializeComponent();
        }
        public void loaddata()
        {
            pn.layThongTin(dataGridViewPhieuNhap);         
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.txtMaPN.ResetText();
            this.txtNgayNhap.ResetText();
            this.cbbMaNCC.ResetText();
            this.txtSoTienDaTra.ResetText();
            this.txtSoTienPhaiTra.ResetText();
            this.txtThanhToan.ResetText();
            this.cbbMaNV.ResetText();
        }

        private void frm_NhapHang_Load(object sender, EventArgs e)
        {
            loaddata();
            Load_CboMaNV();
            Load_CboMaNCC();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Hide();
                frm_TrangChu tc = new frm_TrangChu();
                tc.ShowDialog();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtMaPN.ResetText();
            this.txtNgayNhap.ResetText();
            this.cbbMaNCC.ResetText();
            this.txtSoTienDaTra.ResetText();
            this.txtSoTienPhaiTra.ResetText();
            this.txtThanhToan.ResetText();
            this.cbbMaNV.ResetText();
            this.txtMaPN.Focus();
            this.txtMaPN.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    pn.ThemPhieuNhap(txtMaPN.Text, cbbMaNCC.Text, cbbMaNV.Text, DateTime.Parse(txtNgayNhap.Text).ToString(), int.Parse(txtThanhToan.Text), double.Parse(txtSoTienPhaiTra.Text), double.Parse(txtSoTienDaTra.Text));
                    loaddata();
                    pn.layThongTin(dataGridViewPhieuNhap);
                    MessageBox.Show("Lưu thành công");

                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }

            }
            else
            {
                try
                {
                    pn.SuaPhieuNhap(txtMaPN.Text, cbbMaNCC.Text, cbbMaNV.Text, DateTime.Parse(txtNgayNhap.Text).ToString(), int.Parse(txtThanhToan.Text), double.Parse(txtSoTienPhaiTra.Text), double.Parse(txtSoTienDaTra.Text));
                    loaddata();
                    pn.layThongTin(dataGridViewPhieuNhap);
                    MessageBox.Show("Lưu thành công");

                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            this.txtMaPN.ResetText();
            this.txtNgayNhap.ResetText();
            this.cbbMaNCC.ResetText();
            this.txtSoTienDaTra.ResetText();
            this.txtSoTienPhaiTra.ResetText();
            this.txtThanhToan.ResetText();
            this.cbbMaNV.ResetText();
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.txtMaPN.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn huỷ không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridViewPhieuNhap.CurrentCell.RowIndex;
                string ma = dataGridViewPhieuNhap.Rows[r].Cells[0].Value.ToString();

                pn.XoaPhieuNhap(ma);
                loaddata();
                pn.layThongTin(dataGridViewPhieuNhap);
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void dataGridViewPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridViewPhieuNhap.CurrentCell.RowIndex;
                txtMaPN.Text = dataGridViewPhieuNhap.Rows[r].Cells[0].Value.ToString();
                cbbMaNCC.Text = dataGridViewPhieuNhap.Rows[r].Cells[1].Value.ToString();
                cbbMaNV.Text = dataGridViewPhieuNhap.Rows[r].Cells[2].Value.ToString();
                txtNgayNhap.Text = dataGridViewPhieuNhap.Rows[r].Cells[3].Value.ToString();
                txtThanhToan.Text = dataGridViewPhieuNhap.Rows[r].Cells[4].Value.ToString();           
                txtSoTienPhaiTra.Text = dataGridViewPhieuNhap.Rows[r].Cells[5].Value.ToString();
                txtSoTienDaTra.Text = dataGridViewPhieuNhap.Rows[r].Cells[6].Value.ToString();              
            }
            catch
            {

            }
        }
        private void Load_CboMaNV()
        {
            cbbMaNV.DataSource = pn.LoadMaNV();
            cbbMaNV.DisplayMember = "TENNV";
            cbbMaNV.ValueMember = "MANV";
        }
        private void Load_CboMaNCC()
        {
            cbbMaNCC.DataSource = pn.loadTenNCC();
            cbbMaNCC.DisplayMember = "TENNCC";
            cbbMaNCC.ValueMember = "MANCC";
        }
            private void cbbMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridViewPhieuNhap.DataSource = xm.PHIEUNHAPs.Where(nv => nv.MAPN.Contains(txtTimKiem.Text));
        }
    }
}
