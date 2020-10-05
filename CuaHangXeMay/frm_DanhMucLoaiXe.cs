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
    public partial class frm_DanhMucLoaiXe : Form
    {
        QuanLyXeMayDataContext qlxm = new QuanLyXeMayDataContext();
        LoaiXe qlnv = new LoaiXe();
        bool them = false;
        public frm_DanhMucLoaiXe()
        {
            InitializeComponent();
        }
        public void Loaddata()
        {
            dataGridViewLoaiXe.DataSource = qlnv.GetLOAIXEs();
            //qlnv.LayLoaiXe(dataGridViewLoaiXe);
            this.btn_Luu.Enabled = false;
            this.btn_Huy.Enabled = false;
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.txtMaLX.ResetText();
            this.txtTenLX.ResetText();            
            this.txtDonGiaNhap.ResetText();
            this.txtDonGia.ResetText(); 
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridViewLoaiXe.DataSource = qlxm.LOAIXEs.Where(xe => xe.TENHANG.Contains(textBox3.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void btn_InDS_Click(object sender, EventArgs e)
        {

        }

        private void FormDanhMucLoaiXe_Load(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void dataGridViewLoaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridViewLoaiXe.CurrentCell.RowIndex;
                txtMaLX.Text = dataGridViewLoaiXe.Rows[r].Cells[0].Value.ToString();
                txtTenLX.Text = dataGridViewLoaiXe.Rows[r].Cells[1].Value.ToString();
                txtDonGiaNhap.Text = dataGridViewLoaiXe.Rows[r].Cells[2].Value.ToString();
                txtDonGia.Text = dataGridViewLoaiXe.Rows[r].Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            them = true;
            this.txtMaLX.Enabled = true;
            this.btn_Luu.Enabled = true;
            this.btn_Huy.Enabled = true;
            this.btn_Them.Enabled = true;
            this.btn_Sua.Enabled = true;
            this.btn_Xoa.Enabled = true;
            this.txtMaLX.ResetText();
            this.txtTenLX.ResetText();
            this.txtDonGiaNhap.ResetText();
            this.txtDonGia.ResetText();
            this.txtMaLX.Focus();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    qlnv.ThemLoaiXe(txtMaLX.Text, txtTenLX.Text, int.Parse(txtDonGiaNhap.Text), int.Parse(txtDonGia.Text));
                    Loaddata();
                    qlnv.LayLoaiXe(dataGridViewLoaiXe);
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
                    qlnv.SuaLX(txtMaLX.Text, txtTenLX.Text, int.Parse(txtDonGiaNhap.Text), int.Parse(txtDonGia.Text));
                    Loaddata();
                    qlnv.LayLoaiXe(dataGridViewLoaiXe);
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
            them = false;          
            this.txtMaLX.Enabled = false;
            this.btn_Luu.Enabled = true;
            this.btn_Huy.Enabled = true;
            this.btn_Them.Enabled = false;
            this.btn_Sua.Enabled = false;
            this.btn_Xoa.Enabled = false;


        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridViewLoaiXe.CurrentCell.RowIndex;
                string ma = dataGridViewLoaiXe.Rows[r].Cells[0].Value.ToString();

                qlnv.XoaNV(ma);
                Loaddata();
                qlnv.LayLoaiXe(dataGridViewLoaiXe);
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
                Loaddata();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
