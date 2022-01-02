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

namespace Employee
{
    public partial class Home_BanHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Home_BanHang()
        {
            InitializeComponent();
        }

        private void label_XinChao_Click(object sender, EventArgs e)
        {

        }

        private void Home_BanHang_Load(object sender, EventArgs e)
        {
            label_XinChao.Text = label_XinChao.Text + " " + Global.HoTen_NS;
            label_chinhanh.Text = label_chinhanh.Text + " " + Global.ChiNhanhLamViec + " " + Global.TenChiNhanh;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginEmployee login = new LoginEmployee();
            login.Show();
            Global.MaNS = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon_BanHang hd = new HoaDon_BanHang();
            hd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinCaNhan_BanHang ttcn = new ThongTinCaNhan_BanHang();
            ttcn.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            XemThongTinKH_BanHang xem = new XemThongTinKH_BanHang();
            xem.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DiemDanh_BanHang diemdanh = new DiemDanh_BanHang();
            diemdanh.Show();
        }
    }
}
