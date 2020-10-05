using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL_DAL;
namespace CuaHangXeMay
{
    public partial class frm_ChucVu : Form
    {
        QuanLyXeMayDataContext ql = new QuanLyXeMayDataContext();
        ChucVu cv = new ChucVu();
        bool them = false;
        public void Loaddata()
        {
            cv.LayChucVu(dataGridViewChucVu);
            this.btn_Luu.Enabled = false;
            this.btn_Huy.Enabled = false;
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.txtMaChucVu.ResetText();
            this.txtTenChucVu.ResetText();
        }
        public frm_ChucVu()
        {
            InitializeComponent();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            them = false;
            this.txtMaChucVu.Enabled = false;
            this.btn_Luu.Enabled = true;
            this.btn_Huy.Enabled = true;
            this.btn_Them.Enabled = false;
            this.btn_Sua.Enabled = false;
            this.btn_Xoa.Enabled = false;
            this.txtMaChucVu.ResetText();
            this.txtTenChucVu.ResetText();

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    cv.ThemChucVu(txtMaChucVu.Text, txtTenChucVu.Text);
                    Loaddata();
                    cv.LayChucVu(dataGridViewChucVu);
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
                    cv.SuaLX(txtMaChucVu.Text, txtTenChucVu.Text);
                    Loaddata();
                    cv.LayChucVu(dataGridViewChucVu);
                    MessageBox.Show("Lưu thành công");

                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void FormChucVu_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn huỷ không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridViewChucVu.CurrentCell.RowIndex;
                string ma = dataGridViewChucVu.Rows[r].Cells[0].Value.ToString();

                cv.XoaNV(ma);
                Loaddata();
                cv.LayChucVu(dataGridViewChucVu);
                MessageBox.Show("Xóa thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtMaChucVu.Enabled = true;
            this.btn_Luu.Enabled = true;
            this.btn_Huy.Enabled = true;
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.txtMaChucVu.ResetText();
            this.txtTenChucVu.ResetText();
            this.txtMaChucVu.Focus();
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btn_In_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridViewChucVu.CurrentCell.RowIndex;
                txtMaChucVu.Text = dataGridViewChucVu.Rows[r].Cells[0].Value.ToString();
                txtTenChucVu.Text = dataGridViewChucVu.Rows[r].Cells[1].Value.ToString();
            }
            catch
            {

            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridViewChucVu.DataSource = ql.CHUCVUs.Where(xe => xe.MACHUCVU.Contains(txtTimKiem.Text));
        }
    }
}
