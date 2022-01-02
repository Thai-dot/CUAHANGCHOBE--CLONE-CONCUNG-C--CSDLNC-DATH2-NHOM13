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
using System.Globalization;

namespace Customer
{
    public partial class TreEm_KH : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public TreEm_KH()
        {
            InitializeComponent();
        }

        private void TreEm_KH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
           
            connection.Close();
        }

        private void loaddata()
        {
            
          
            connection = new SqlConnection(Global.strconnect);
            connection.Open();

            
            command = connection.CreateCommand();
            command.CommandText = "select * from TreEm where MaKH = "+Global.MaKH+"";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;

            connection.Close();

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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GioHang_KH gh = new GioHang_KH();
            gh.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinKH tt = new ThongTinKH();
            tt.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeuThich yt = new YeuThich();
            yt.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            LichSu_MuaHang_KH ls = new LichSu_MuaHang_KH();
            this.Hide();
            ls.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_KH home = new Home_KH();
            home.Show();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
           
            txb_STT.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_HoTenBe.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            comboBox1.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txb_STT.Text==""||txb_HoTenBe.Text == "" || comboBox1.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            else
            {
                try
                {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("capnhattreem_kh", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
                cmd.Parameters.Add("@STTtre", SqlDbType.Int).Value = txb_STT.Text;
                cmd.Parameters.Add("@HoTenBe", SqlDbType.NVarChar).Value = txb_HoTenBe.Text;
                cmd.Parameters.Add("@GioiTinhBe", SqlDbType.NVarChar).Value = comboBox1.Text;
                cmd.Parameters.Add("@NgaySinhBe", SqlDbType.Date).Value = dateTimePicker1.Text;
               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 loaddata();
                connection.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }

            }
        }
    }
}
