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
    public partial class Kho_DoiTac : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Kho_DoiTac()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaKho nk = new NhaKho();
            nk.Show();
        }

        private void Kho_DoiTac_Load(object sender, EventArgs e)
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
            command.CommandText = "Select MaKho from Kho";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string makho = datareader.GetInt32(0).ToString();
                cb_MaKho.Items.Add(makho);
            }
            connection.Close();

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select TenDoiTAC from dOItAC";
            SqlDataReader datareader1 = command.ExecuteReader();
            while (datareader1.Read())
            {
                string TENDOITAC = datareader1.GetString(0);
                cb_TenDoiTac.Items.Add(TENDOITAC);
            }
            connection.Close();


        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            cb_MaKho.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            cb_MaDT.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            cb_MaSP.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_SoLuong.Text = dgv_1.Rows[i].Cells[4].Value.ToString();

        }

        private void cb_TenDoiTac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TenDoiTac.Text == "")
            {
                return;
            }

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();

            command.CommandText = "select MaDT from DoiTac where TenDoiTac= N'" + cb_TenDoiTac.Text + "'";
            cb_MaDT.Text = command.ExecuteScalar().ToString();
            connection.Close();
        }

        private void cb_TenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TenSP.Text =="")
            {
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select MaSP from SanPham where TenSP = N'"+cb_TenSP.Text+"'";
            SqlDataReader datareader2 = command.ExecuteReader();
            
            while (datareader2.Read())
            {
                string masp = datareader2.GetInt32(0).ToString();
                cb_MaSP.Items.Add(masp);
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cb_MaKho.Text == ""||cb_MaDT.Text==""||cb_MaSP.Text==""||txb_SoLuong.Text=="")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin cung cấp?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("cungcapDoiTac_Kho_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MaKho", SqlDbType.Int).Value = Convert.ToInt32( cb_MaKho.Text);
                cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = Convert.ToInt32 (cb_MaDT.Text);
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = Convert.ToInt32(cb_MaSP.Text);
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = Convert.ToInt32(txb_SoLuong.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cung cấp thành công mặt hàng!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();


                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txb_MaDT_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_MaDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MaDT.Text == "")
            {
                return;

            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select * from Kho_DoiTac where MaDT = " + cb_MaDT.Text + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;
            connection.Close();

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select TenSP from SanPham where DoiTac = " + cb_MaDT.Text + "";
            SqlDataReader datareader2 = command.ExecuteReader();

            while (datareader2.Read())
            {
                string tenSP = datareader2.GetString(0);
                cb_TenSP.Items.Add(tenSP);
            }
            connection.Close();
        }

        private void cb_MaDT_TextChanged(object sender, EventArgs e)
        {
            if (cb_MaDT.Text == "")
            {
                return;

            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select * from Kho_DoiTac where MaDT = " + cb_MaDT.Text + "";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;
            connection.Close();

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select TenSP from SanPham where DoiTac = "+cb_MaDT.Text+"";
            SqlDataReader datareader2 = command.ExecuteReader();

            while (datareader2.Read())
            {
                string tenSP = datareader2.GetString(0);
                cb_TenSP.Items.Add(tenSP);
            }
            connection.Close();
        }

        private void cb_MaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_MaSP.Text == "")
            {
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select tENsP from SanPham where mAsp ="+cb_MaSP.Text+"";
            cb_TenSP.Text = command.ExecuteScalar().ToString();
            connection.Close();
        }
    }
}
