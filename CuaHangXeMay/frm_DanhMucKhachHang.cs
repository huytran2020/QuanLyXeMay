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
    public partial class frm_DanhMucKhachHang : Form
    {
        QuanLyXeMayDataContext qlxm = new QuanLyXeMayDataContext();
        KhachHang kh = new KhachHang();
        public frm_DanhMucKhachHang()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void loaddata()
        {
            dataGridViewKhachHang.DataSource = kh.GetKHACHHANGs();
        }
        private void btn_Thoat_Click(object sender, EventArgs e)
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridViewKhachHang.DataSource = qlxm.KHACHHANGs.Where(xe => xe.TENKH.Contains(txtTimKiem.Text));
        }

        private void frm_DanhMucKhachHang_Load(object sender, EventArgs e)
        {
            loaddata();
            int r = dataGridViewKhachHang.CurrentCell.RowIndex;
            txtMaKhachHang.Text = dataGridViewKhachHang.Rows[r].Cells[0].Value.ToString();
            txtTenKhachHang.Text = dataGridViewKhachHang.Rows[r].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridViewKhachHang.Rows[r].Cells[2].Value.ToString();
            txtSDT.Text = dataGridViewKhachHang.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = dataGridViewKhachHang.Rows[r].Cells[4].Value.ToString();
            txtCMNN.Text = dataGridViewKhachHang.Rows[r].Cells[5].Value.ToString();
            txtMaKhachHang.Enabled = txtTenKhachHang.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = txtCMNN.Enabled = false;
            btn_Xoa.Enabled = btn_Luu.Enabled = btn_Huy.Enabled = btn_Sua.Enabled = false;
        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridViewKhachHang.CurrentCell.RowIndex;
            txtMaKhachHang.Text = dataGridViewKhachHang.Rows[r].Cells[0].Value.ToString();
            txtTenKhachHang.Text = dataGridViewKhachHang.Rows[r].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridViewKhachHang .Rows[r].Cells[2].Value.ToString();
            txtSDT.Text = dataGridViewKhachHang.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = dataGridViewKhachHang .Rows[r].Cells[4].Value.ToString();
            txtCMNN.Text = dataGridViewKhachHang.Rows[r].Cells[5].Value.ToString();
            btn_Xoa.Enabled = btn_Luu.Enabled = btn_Huy.Enabled = btn_Sua.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = txtTenKhachHang.Text = txtDiaChi.Text = txtSDT.Text = txtEmail.Text = txtCMNN.Text = "";
            txtMaKhachHang.Focus();
            txtMaKhachHang.Enabled = txtTenKhachHang.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtEmail.Enabled = txtCMNN.Enabled = true;
            btn_Luu.Enabled = true;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                kh.SuaKH(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtCMNN.Text);
                MessageBox.Show("Sửa thành công", "Thông báo");
                loaddata();
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa mã khách hàng " + txtMaKhachHang.Text + " ??", "Thông báo", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                kh.XoaKH(txtMaKhachHang.Text);
                MessageBox.Show("Xóa thành công");
                loaddata();
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                kh.ThemKH(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, txtCMNN.Text);
                MessageBox.Show("Lưu thành công");
                loaddata();

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
