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
    public partial class PhieuXuat : Form
    {
        QLPhieuXuat qlpx = new QLPhieuXuat();
        bool them = false;
        public PhieuXuat()
        {
            InitializeComponent();
        }
        
        public void Loaddata()
        {
            qlpx.LayPhieuXuat(dataGridViewPhieuXuat);
            this.btnLuu.Enabled = false;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.txtMaHoaDon.ResetText();
            this.txtKhachHang.ResetText();
            this.txtNgayLap.ResetText();
            this.txtNhanVienLap.ResetText();
            this.txtTongTien.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtMaHoaDon.ResetText();
            this.txtKhachHang.ResetText();
            this.txtNgayLap.ResetText();
            this.txtNhanVienLap.ResetText();
            this.txtTongTien.ResetText();
            this.txtMaHoaDon.Enabled = true;
            this.btnLuu.Enabled = true;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
        }

        private void PhieuXuat_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridViewPhieuXuat.CurrentCell.RowIndex;
                string ma = dataGridViewPhieuXuat.Rows[r].Cells[0].Value.ToString();

                qlpx.XoaPhieuXuat(ma);
                Loaddata();
                qlpx.LayPhieuXuat(dataGridViewPhieuXuat);
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            them = false;
            this.txtMaHoaDon.ResetText();
            this.txtKhachHang.ResetText();
            this.txtNgayLap.ResetText();
            this.txtNhanVienLap.ResetText();
            this.txtTongTien.ResetText();
            this.btnLuu.Enabled = true;
            this.txtMaHoaDon.Enabled = false;
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.button1.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    qlpx.ThemPhieuXuat(txtMaHoaDon.Text,  txtNgayLap.Text, txtNhanVienLap.Text, txtKhachHang.Text, double.Parse(txtTongTien.Text));
                    Loaddata();
                    qlpx.LayPhieuXuat(dataGridViewPhieuXuat);
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
                    qlpx.SuaPhieuXuat(txtMaHoaDon.Text, txtNgayLap.Text, txtNhanVienLap.Text, txtKhachHang.Text, double.Parse(txtTongTien.Text));
                    Loaddata();
                    qlpx.LayPhieuXuat(dataGridViewPhieuXuat);
                    MessageBox.Show("Lưu thành công");

                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void dataGridViewPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridViewPhieuXuat.CurrentCell.RowIndex;
                txtMaHoaDon.Text = dataGridViewPhieuXuat.Rows[r].Cells[0].Value.ToString();
                txtNgayLap.Text = dataGridViewPhieuXuat.Rows[r].Cells[1].Value.ToString();
                txtNhanVienLap.Text = dataGridViewPhieuXuat.Rows[r].Cells[2].Value.ToString();
                txtKhachHang.Text = dataGridViewPhieuXuat.Rows[r].Cells[3].Value.ToString();
                txtTongTien.Text = dataGridViewPhieuXuat.Rows[r].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
