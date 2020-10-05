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
    public partial class frm_DanhMucNhanVien : Form
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        NhanVien qlnv = new NhanVien();
        bool them = false;
        public frm_DanhMucNhanVien()
        {
            InitializeComponent();
        }
        public void Loaddata()
        {
            qlnv.LoadChucVu(cbbChucVu);
            qlnv.LayNhanVien(dataGridViewNhanVien);
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.txtDiaChi.ResetText();
            this.txtTen.ResetText();
            this.cbbChucVu.ResetText();
            this.txtLuong.ResetText();
            this.txtMaNhanVien.ResetText();
            this.txtNamSinh.ResetText();
            this.txtEmail.ResetText();
            this.cbbGioiTinh.ResetText();
            this.txtDienThoai.ResetText();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FormDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            //Loaddata();
            loadDT();
            int r = dataGridViewNhanVien.CurrentCell.RowIndex;
            txtMaNhanVien.Text = dataGridViewNhanVien.Rows[r].Cells[0].Value.ToString();
            cbbChucVu.Text = dataGridViewNhanVien.Rows[r].Cells[1].Value.ToString();
            txtTen.Text = dataGridViewNhanVien.Rows[r].Cells[2].Value.ToString();
            cbbGioiTinh.Text = dataGridViewNhanVien.Rows[r].Cells[3].Value.ToString();
            txtNamSinh.Text = dataGridViewNhanVien.Rows[r].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridViewNhanVien.Rows[r].Cells[5].Value.ToString();
            txtDienThoai.Text = dataGridViewNhanVien.Rows[r].Cells[6].Value.ToString();
            txtEmail.Text = dataGridViewNhanVien.Rows[r].Cells[7].Value.ToString();
            txtLuong.Text = dataGridViewNhanVien.Rows[r].Cells[8].Value.ToString();
            txtMaNhanVien.Enabled = cbbChucVu.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled = txtEmail.Enabled = txtLuong.Enabled = cbbGioiTinh.Enabled = txtNamSinh.Enabled = txtTen.Enabled = false;


        }
        public void loadDT()
        {
            dataGridViewNhanVien.DataSource = qlnv.loadNV();
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
            this.txtDiaChi.ResetText();
            this.txtTen.ResetText();
            this.txtLuong.ResetText();
            this.txtMaNhanVien.ResetText();
            this.txtNamSinh.ResetText();
            this.txtEmail.ResetText();
            this.cbbGioiTinh.ResetText();
            this.txtDienThoai.ResetText();
            this.cbbChucVu.ResetText();
            this.txtMaNhanVien.Enabled = true;          
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;        
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            txtMaNhanVien.Enabled = cbbChucVu.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled = txtEmail.Enabled = txtLuong.Enabled = cbbGioiTinh.Enabled = txtNamSinh.Enabled = txtTen.Enabled = true;
            //this.txtNgayVaoLam.Text = System.DateTime.Now.ToString().Substring(0, 10);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    qlnv.ThemNV(txtMaNhanVien.Text,cbbChucVu.Text,txtTen.Text, cbbGioiTinh.Text,txtNamSinh.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, txtLuong.Text);
                    qlnv.LayNhanVien(dataGridViewNhanVien);
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
                    qlnv.SuaNV(txtMaNhanVien.Text, cbbChucVu.Text, txtTen.Text, cbbGioiTinh.Text, txtNamSinh.Text, txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text, txtLuong.Text);
                    Loaddata();
                    qlnv.LayNhanVien(dataGridViewNhanVien);
                    MessageBox.Show("Lưu thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                qlnv.SuaNV(txtMaNhanVien.Text,cbbChucVu.Text, txtTen.Text, cbbGioiTinh.Text,txtNamSinh.Text,txtDiaChi.Text, txtDienThoai.Text, txtEmail.Text,txtLuong.Text);
                MessageBox.Show("Sửa thành công", "Thông báo");
                qlnv.LayNhanVien(dataGridViewNhanVien);
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa mã nhân viên " + txtMaNhanVien.Text + " ??", "Thông báo", MessageBoxButtons.YesNo);
            if(rs==DialogResult.Yes)
            {
                qlnv.XoaNV(txtMaNhanVien.Text);
                MessageBox.Show("Xóa thành công");
                loadDT();
            }    

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn huỷ thao tác với Form Nhân Viên không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                loadDT();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dataGridViewNhanVien.CurrentCell.RowIndex;
                txtMaNhanVien.Text = dataGridViewNhanVien.Rows[r].Cells[0].Value.ToString();
                cbbChucVu.Text = dataGridViewNhanVien.Rows[r].Cells[1].Value.ToString();
                txtTen.Text = dataGridViewNhanVien.Rows[r].Cells[2].Value.ToString();
                cbbGioiTinh.Text = dataGridViewNhanVien.Rows[r].Cells[3].Value.ToString();
                txtNamSinh.Text = dataGridViewNhanVien.Rows[r].Cells[4].Value.ToString();
                txtDiaChi.Text = dataGridViewNhanVien.Rows[r].Cells[5].Value.ToString();
                txtDienThoai.Text = dataGridViewNhanVien.Rows[r].Cells[6].Value.ToString();
                txtEmail.Text = dataGridViewNhanVien.Rows[r].Cells[7].Value.ToString();
                txtLuong.Text = dataGridViewNhanVien.Rows[r].Cells[8].Value.ToString();
                //qlnv.LayLuong(lblTongCa, lblTongTien, txtMaNV.Text, int.Parse(txtLuongCB.Text));
            }
            catch
            {

            }
        }

        private void cbbChucVu_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    qlnv.Loc(cbbChucVu, cbbGioiTinh, txtTimKiem, dataGridViewNhanVien);
            //    if (txtTimKiem.Text == "" && cbbChucVu.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
            //    {
            //        Loaddata();
            //    }
            //}
            //catch
            //{

            //}
        }

        private void cbbGioiTinh_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    qlnv.Loc(cbbChucVu, cbbGioiTinh, txtTimKiem, dataGridViewNhanVien);
            //    if (txtTimKiem.Text == "" && cbbChucVu.Text == "Tất Cả" && cbbGioiTinh.Text == "Tất Cả")
            //    {
            //        Loaddata();
            //    }
            //}
            //catch
            //{

            //}
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dataGridViewNhanVien.DataSource = xm.NHANVIENs.Where(nv => nv.TENNV.Contains(txtTimKiem.Text));
        }
    }
}
