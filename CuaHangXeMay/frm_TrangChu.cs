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
    public partial class frm_TrangChu : Form
    {
        DangNhap dn = new DangNhap();
        public frm_TrangChu()
        {
            InitializeComponent();
        }
        public string TenNV { get; set; }
        public string Quyen { get; set; }
        public string TK { get; set; }
        public string TTin { get; set; }
        public string TenDN { get; set; }
        public string KT { get; set; }
        public string MK { get; set; }
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            if (label_Quyen.Text.ToString() == "Nhân viên")
            {
                label_xinchao.Text = TenNV.ToString();
                label_Quyen.Text = Quyen.ToString();
                btnTK.Enabled = false;
                btnDMChucVu.Enabled = false;
            }

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void danhMụcXeMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_TaiKhoan tk = new frm_TaiKhoan();
            tk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DangNhap tk = new frm_DangNhap();
            tk.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDMNhanVien_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DanhMucNhanVien tk = new frm_DanhMucNhanVien();
            tk.ShowDialog();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DanhMucNhanVien tk = new frm_DanhMucNhanVien();
            tk.ShowDialog();
        }

        private void btnDMChucVu_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_ChucVu tk = new frm_ChucVu();
            tk.ShowDialog();
        }

        private void btnDMKhachHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DanhMucKhachHang tk = new frm_DanhMucKhachHang();
            tk.ShowDialog();
        }

        private void btnDMXeMay_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_Xe tk = new frm_Xe();
            tk.ShowDialog();
        }

        private void btnDMNhaCungCap_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_NhaCungCap tk = new frm_NhaCungCap();
            tk.ShowDialog();
        }

        private void btnDMLoaiXe_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DanhMucLoaiXe tk = new frm_DanhMucLoaiXe();
            tk.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_PhieuXuat tk = new frm_PhieuXuat();
            tk.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_PhieuBaoHanh tk = new frm_PhieuBaoHanh();
            tk.ShowDialog();
        }
    }
}
