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

namespace Customer
{
    public partial class LichSu_MuaHang_KH : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public LichSu_MuaHang_KH()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_KH home = new Home_KH();
            home.Show();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeuThich yt = new YeuThich();
            yt.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinKH tt = new ThongTinKH();
            tt.Show();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GioHang_KH gh = new GioHang_KH();
            gh.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có muốn thoát ?", "Thoát Đăng Nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
                Global.HoTen_KH = "";
                Global.Ten_DN = "";
                Global.MaKH = "";
            }
        }

        private void LichSu_MuaHang_KH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loadata();
            

            connection.Close();
        }

        private void loadata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from LichSu_MuaHang where MaKH = " + Global.MaKH + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;

           
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            DataTable table4 = new DataTable();
            command = connection.CreateCommand();
            int i = -1;
            i = dgv_1.CurrentRow.Index;
            if(dgv_1.Rows[i].Cells[1].Value.ToString() == "")
            {
                loadata();
                return;
            }
            command.CommandText = "Select * from ct_hoadon where mahoadon = " + dgv_1.Rows[i].Cells[1].Value.ToString() + " ";
            adapter.SelectCommand = command;
            table4.Clear();
            adapter.Fill(table4);
            dgv_2.DataSource = table4;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            TreEm_KH tt = new TreEm_KH();
            tt.Show();
        }
    }
}
