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
    public partial class frm_NhaCungCap : Form
    {
        QuanLyXeMayDataContext qlnv = new QuanLyXeMayDataContext();
        NhaCungCap ncc = new NhaCungCap();
        bool them = false;
        public frm_NhaCungCap()
        {
            InitializeComponent();
        }
        public void Loaddata()
        {
            ncc.LayNhaCungCap(dataGridView_NCC);
            this.btn_Luu.Enabled = false;
            this.btn_Huy.Enabled = false;
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.txtMaNCC.ResetText();
            this.txtTenNCC.ResetText();
            this.txtDiachi.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
        }
        private void frm_NhaCunngCap_Load(object sender, EventArgs e)
        {
            Loaddata();
            txtMaNCC.Enabled = txtTenNCC.Enabled = txtDiachi.Enabled = txtSDT.Enabled = txtEmail.Enabled = false;
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

        private void btn_Them_Click(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = txtTenNCC.Enabled = txtDiachi.Enabled = txtSDT.Enabled = txtEmail.Enabled = true;
            them = true;
            this.txtMaNCC.Enabled = true;
            this.btn_Luu.Enabled = true;
            this.btn_Huy.Enabled = true;
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.txtMaNCC.ResetText();
            this.txtTenNCC.ResetText();
            this.txtDiachi.ResetText();
            this.txtSDT.ResetText();
            this.txtEmail.ResetText();
            this.txtMaNCC.Focus();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    ncc.ThemNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtDiachi.Text, txtSDT.Text, txtEmail.Text);
                    Loaddata();
                   ncc.LayNhaCungCap(dataGridView_NCC);
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
                    ncc.SuaNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiachi.Text, txtSDT.Text, txtEmail.Text);
                    Loaddata();
                    ncc.LayNhaCungCap(dataGridView_NCC);
                    MessageBox.Show("Lưu thành công");

                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                ncc.SuaNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiachi.Text, txtSDT.Text, txtEmail.Text);
                Loaddata();
                ncc.LayNhaCungCap(dataGridView_NCC);
                MessageBox.Show("Sửa thành công");

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridView_NCC.CurrentCell.RowIndex;
                string ma = dataGridView_NCC.Rows[r].Cells[0].Value.ToString();

                ncc.XoaNCC(ma);
                Loaddata();
                ncc.LayNhaCungCap(dataGridView_NCC);
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn huỷ không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void dataGridView_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridView_NCC.CurrentCell.RowIndex;
                txtMaNCC.Text = dataGridView_NCC.Rows[r].Cells[0].Value.ToString();
                txtTenNCC.Text = dataGridView_NCC.Rows[r].Cells[1].Value.ToString();
                txtDiachi.Text = dataGridView_NCC.Rows[r].Cells[2].Value.ToString();
                txtSDT.Text = dataGridView_NCC.Rows[r].Cells[3].Value.ToString();
                txtEmail.Text = dataGridView_NCC.Rows[r].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }


        private void txtMaXeMay_TextChanged(object sender, EventArgs e)
        {
            dataGridView_NCC.DataSource = qlnv.NHACUNGCAPs.Where(nv => nv.TENNCC.Contains(txtTimKiem.Text));
        }
    }
}
