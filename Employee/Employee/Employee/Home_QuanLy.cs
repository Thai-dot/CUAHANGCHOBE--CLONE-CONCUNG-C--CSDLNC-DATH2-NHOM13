using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Employee
{
    public partial class Home_QuanLy : Form
    {
        public Home_QuanLy()
        {
            InitializeComponent();
        }

        private void Home_QuanLy_Load(object sender, EventArgs e)
        {
            label_XinChao.Text = label_XinChao.Text + " " + Global.HoTen_NS;
            label_chinhanh.Text = label_chinhanh.Text + " " + Global.ChiNhanhLamViec + " " + Global.TenChiNhanh;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginEmployee login = new LoginEmployee();
            login.Show();
            Global.MaNS = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DiemDanh_BanHang diemdanh = new DiemDanh_BanHang();
            diemdanh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            DieuChinhPhieuGiam_QuanLy dieuchinh = new DieuChinhPhieuGiam_QuanLy();
            dieuchinh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLyLuongBH_QuanLy ql = new QuanLyLuongBH_QuanLy();
            ql.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinCaNhan_BanHang tt = new ThongTinCaNhan_BanHang();
            tt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongKeDoanhThu_QuanLy TK = new ThongKeDoanhThu_QuanLy();
            TK.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaoHopDong_QuanLy tao = new TaoHopDong_QuanLy();
            tao.Show();
        }
    }
}
