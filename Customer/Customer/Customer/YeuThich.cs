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
    public partial class YeuThich : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public YeuThich()
        {
            InitializeComponent();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_KH home = new Home_KH();
            home.Show();
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

        private void YeuThich_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
            label_XinChao.Text = label_XinChao.Text + " " + Global.HoTen_KH.ToString();

            connection.Close();
        }
        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "Select MaSP as Mã_SP, TenSP as Tên_Sản_Phẩm, TenDOiTac as Tên_Đối_Tác, GiaBan as Giá_Bán from KhachHang_YeuThich where MaKH ='"+Global.MaKH+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;

        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
            txb_MaSP.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_TenSP.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_TenDoiTac.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_GiaBan.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoaspyeuthich_kh", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = txb_MaSP.Text;
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công sản phẩm?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                loaddata();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
