using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangXeMay
{
    public partial class frm_GioiThieu : Form
    {
        public frm_GioiThieu()
        {
            InitializeComponent();
        }

        private void FormGioiThieu_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frm_DangNhap dn = new frm_DangNhap();
            dn.ShowDialog();
        }
    }
}
