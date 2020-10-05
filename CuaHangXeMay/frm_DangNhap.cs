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
    public partial class frm_DangNhap : Form
    {
        QuanLyXeMayDataContext xm = new QuanLyXeMayDataContext();
        public frm_DangNhap()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }
        public string MaNVDangChon { get; set; }
        public string TenNVDangChon { get; set; }
        public string QuyenNVDangChon { get; set; }
        public string TenTK { get; set; }
        public string KT { get; set; }
        DangNhap dn = new DangNhap();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (dn.LayTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text) == 1 && dn.LayTrangThai(txtTaiKhoan.Text, txtMatKhau.Text) == "Hoạt động")
                {
                    TenNVDangChon = dn.LayTenNV(txtTaiKhoan.Text, txtMatKhau.Text);
                    QuyenNVDangChon = dn.LayQuyenNV(txtTaiKhoan.Text, txtMatKhau.Text);
                    MaNVDangChon = dn.LayMaNV(txtTaiKhoan.Text, txtMatKhau.Text);
                    TenTK = txtTaiKhoan.Text;

                    MessageBox.Show("Đăng nhập thành công","Thông báo");
                    this.Hide();
                    frm_TrangChu h = new frm_TrangChu();
                    h.TenNV = TenNVDangChon;
                    h.Quyen = QuyenNVDangChon;
                    h.TK = MaNVDangChon;
                    h.TenDN = TenTK;
                    h.ShowDialog();
                    this.Hide();
                }
                else if (dn.LayTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text) == 1 && dn.LayTrangThai(txtTaiKhoan.Text, txtMatKhau.Text) == "Tạm ngưng")
                {
                    MessageBox.Show("Tài khoản đã bị khóa","Thông báo");
                }
                else
                {

                    MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu!");
                   
                }
            }
            catch
            {

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {
            this.txtTaiKhoan.ResetText();
            this.txtTaiKhoan.Focus();
        }

        private void btnDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != 8 || e.KeyChar != 13))
                e.Handled = true;
            if (e.KeyChar == 8)
                e.Handled = false;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar = char.ToUpper(e.KeyChar);
            txtMatKhau.MaxLength = 16;
        }

        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != 8 || e.KeyChar != 13))
                e.Handled = true;
            if (e.KeyChar == 8)
                e.Handled = false;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar = char.ToUpper(e.KeyChar);
            txtTaiKhoan.MaxLength = 16;
        }
    }
}
