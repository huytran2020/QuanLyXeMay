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
    public partial class frm_TaiKhoan : Form
    {
        QuanLyXeMayDataContext ql = new QuanLyXeMayDataContext();
        TaiKhoan qltk = new TaiKhoan();
        bool Them = false;
        public frm_TaiKhoan()
        {
            InitializeComponent();
        }
        

        public void loaddata()
        {
            qltk.LayThongTin(dataGridViewTaiKhoan);       
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
            btn_Them.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Sua.Enabled = true;
            this.txtMaNhanVien.Enabled = false;
            this.txtMK.Enabled = false;
            this.txtTenDN.Enabled = false;
            this.txtTenDN.Enabled = true;
            this.txtTenNV.Enabled = false;
            this.cbbTrangThai.Enabled = false;
            this.txtMK.ResetText();
            this.txtMaNhanVien.ResetText();
            this.cbbTrangThai.ResetText();
            this.txtTenDN.ResetText();
            this.txtTenNV.ResetText();
            this.radioButtonNhanVien.Checked = false;
            this.radioButtonQuanLi.Checked = false;
            this.txtMaNhanVien.Enabled = false;
            this.txtTenNV.Enabled = false;
        }
        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dataGridViewTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridViewTaiKhoan.CurrentCell.RowIndex;
                txtMaNhanVien.Text = dataGridViewTaiKhoan.Rows[r].Cells[0].Value.ToString();
                txtTenNV.Text = dataGridViewTaiKhoan.Rows[r].Cells[1].Value.ToString();
                txtTenDN.Text = dataGridViewTaiKhoan.Rows[r].Cells[2].Value.ToString();
                string a = dataGridViewTaiKhoan.Rows[r].Cells[3].Value.ToString();
                txtMK.Text = qltk.LayMK(txtTenDN.Text);
                if (a == "Quản lí")
                    radioButtonQuanLi.Checked = true;
                else
                    radioButtonNhanVien.Checked = true;
                cbbTrangThai.Text = dataGridViewTaiKhoan.Rows[r].Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Them = true;
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;

            btn_Them.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Sua.Enabled = false;
            txtTenNV.Text = txtMaNhanVien.Text = txtTenDN.Text = txtMK.Text = "";
            cbbTrangThai.Enabled = true;
            txtTenNV.Enabled = txtMaNhanVien.Enabled = txtTenDN.Enabled = txtMK.Enabled = true;
            this.radioButtonNhanVien.Checked = false;
            this.radioButtonQuanLi.Checked = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            btn_Luu.Enabled = true;
            btn_Huy.Enabled = true;

            btn_Them.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Sua.Enabled = false;

            try
            {
                qltk.SuaTK(txtMaNhanVien.Text, txtTenDN.Text, txtMK.Text, radioButtonQuanLi.Text, cbbTrangThai.Text);
                MessageBox.Show("Sửa thành công", "Thông báo");
                qltk.LayThongTin(dataGridViewTaiKhoan);
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaNhanVien.Text;        
                try
                {
                    qltk.XoaTK(ma);
                    loaddata();
                    qltk.LayThongTin(dataGridViewTaiKhoan);
                    MessageBox.Show("Đã Xóa Xong");
                }
                catch
                {
                MessageBox.Show("Lỗi");
                }
            
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string a;
            if (radioButtonNhanVien.Checked == true)
            {
                a = "Nhân Viên";
            }
            else
            {
                a = "Quản Lí";
            }

            if (Them)
            {
                try
                {
                    qltk.ThemTK(txtMaNhanVien.Text, txtTenDN.Text, txtMK.Text, a, cbbTrangThai.Text);
                    loaddata();
                    qltk.LayThongTin(dataGridViewTaiKhoan);
                    MessageBox.Show("Đã thêm xong");
                }
                catch
                {
                    MessageBox.Show("lỗi");
                }

            }
            else
            {
                if (txtMK.Text == qltk.LayMK(txtTenDN.Text))
                {
                    try
                    {
                        qltk.SuaTK2(txtMaNhanVien.Text, txtTenDN.Text, a, cbbTrangThai.Text);
                        loaddata();
                        qltk.LayThongTin(dataGridViewTaiKhoan);
                        MessageBox.Show("Đã thêm xong");
                    }
                    catch
                    {
                        MessageBox.Show("lỗi");
                    }
                }
                else
                {
                    try
                    {
                        qltk.SuaTK(txtMaNhanVien.Text, txtTenDN.Text, txtMK.Text, a, cbbTrangThai.Text);
                        loaddata();
                        qltk.LayThongTin(dataGridViewTaiKhoan);
                        MessageBox.Show("Đã thêm xong");
                    }
                    catch
                    {
                        MessageBox.Show("lỗi");
                    }
                }
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            loaddata();
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

        private void cbbTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbTenNhanVien_TextChanged(object sender, EventArgs e)
        {
        }

        private void cbbTrangThai_TextChanged(object sender, EventArgs e)
        {
            //cbbTrangThai.DisplayMember = "TrangThai";
            //cbbTrangThai.ValueMember = "TrangThai";
            //dataGridViewTaiKhoan.DataSource = qltk.getTrangThai();
        }
    }

}
