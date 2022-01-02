using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADMIN
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SanPham sp = new SanPham();
            sp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyNhanVien_ADMIN ql = new QuanLyNhanVien_ADMIN();
            ql.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoiTac dt = new DoiTac();
            dt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaKho nk = new NhaKho();
            nk.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLy_DVVC ql = new QuanLy_DVVC();
            ql.Show();
        }
    }
}
