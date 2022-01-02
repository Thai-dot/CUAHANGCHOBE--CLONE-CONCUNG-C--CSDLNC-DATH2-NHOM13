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

namespace ADMIN
{
    public partial class NhaKho : Form
    {
        public NhaKho()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DanhSachKho ds = new DanhSachKho();
            ds.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kho_DoiTac kho = new Kho_DoiTac();
            kho.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Kho_ChiNhanh kho = new Kho_ChiNhanh();
            kho.Show();
        }
    }
}
