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
    public partial class QuanLyLuongBH_QuanLy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public QuanLyLuongBH_QuanLy()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_QuanLy home = new Home_QuanLy();
            home.Show();

        }

        private void QuanLyLuongBH_QuanLy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
            
        
            connection.Close();

        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
            txb_MaNS.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_HoTen.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_Luong.Text = dgv_1.Rows[i].Cells[2].Value.ToString();

        }

        private void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select MaNS as Mã_NS, HoTenNS as Họ_Tên, LuongNS as LươngVNĐ, SDTNS from NhanSU where ChiNhanhLamViec = '" + Global.ChiNhanhLamViec + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txb_MaNS.Text == ""||txb_Luong.Text == "")
            {
                MessageBox.Show("Không để trống dữ liệu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("capnhatluong_bh", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Convert.ToInt32( txb_MaNS.Text);
                cmd.Parameters.Add("@Luong", SqlDbType.Float).Value = Convert.ToDouble(txb_Luong.Text);

                
                cmd.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Cập nhật lương thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                connection.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
