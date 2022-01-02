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
    public partial class Kho_ChiNhanh : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Kho_ChiNhanh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaKho kho = new NhaKho();
            kho.Show();
        }

        private void Kho_ChiNhanh_Load(object sender, EventArgs e)
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

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select DiaChiCN from ChiNhanh";
            SqlDataReader datareader1 = command.ExecuteReader();
            while (datareader1.Read())
            {
                string tenchinhanh = datareader1.GetString(0);
                cb_TenChiNhanh.Items.Add(tenchinhanh);
            }
            connection.Close();

        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            cb_MaKho.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            cb_MaChiNhanh.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            cb_MaSP.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_SoLuong.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
        }

        private void cb_TenChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TenChiNhanh.Text == "")
            {
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
      
            command.CommandText = "Select MaChiNhanh from ChiNhanh where DiaChiCN = N'"+cb_TenChiNhanh.Text+"'";
            SqlDataReader datareader2 = command.ExecuteReader();
            while (datareader2.Read())
            {
                string machinhanh = datareader2.GetInt32(0).ToString();
                cb_MaChiNhanh.Items.Add(machinhanh);
            }
            connection.Close();
        }

        private void cb_TenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TenSP.Text == "")
            {
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select MaSP from SanPham where TenSP = N'" + cb_TenSP.Text + "'";
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
            if (cb_MaKho.Text == "" || cb_MaChiNhanh.Text == "" || cb_MaSP.Text == "" || txb_SoLuong.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin cung cấp?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("cungcapSanPham_ChiNhanh_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MaKho", SqlDbType.Int).Value = Convert.ToInt32(cb_MaKho.Text);
                cmd.Parameters.Add("@MaCN", SqlDbType.Int).Value = Convert.ToInt32(cb_MaChiNhanh.Text);
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = Convert.ToInt32(cb_MaSP.Text);
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = Convert.ToInt32(txb_SoLuong.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Cung cấp thành công mặt hàng!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select * from Kho_ChiNhanh where MaKho = " + cb_MaKho.Text + "";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgv_1.DataSource = table;
               

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_MaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MaKho.Text == "")
            {
                return;
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from Kho_ChiNhanh where MaKho = "+cb_MaKho.Text+"";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;
            connection = new SqlConnection(Global.strconnect);
          
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select MaSP from Kho_SanPham where MaKho = "+cb_MaKho.Text+"";
            SqlDataReader datareader2 = command.ExecuteReader();

            while (datareader2.Read())
            {
                string masp = datareader2.GetInt32(0).ToString();
                cb_MaSP.Items.Add(masp);
            }
            connection.Close();
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select sp.TenSP from Kho_SanPham k,SanPham sp where k.MaSp = sp.MaSP and k.MAKho = "+cb_MaKho.Text+"";
            SqlDataReader datareader3 = command.ExecuteReader();

            while (datareader3.Read())
            {
                string tensp = datareader3.GetString(0);
                cb_TenSP.Items.Add(tensp);
            }
            connection.Close();
        }

        private void cb_MaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_MaSP.Text == "")
            {
                return;
            }
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select TenSP from SanPham where MaSP = "+cb_MaSP.Text+"";
            cb_TenSP.Text = command.ExecuteScalar().ToString();
            connection.Close();
        }
    }
}
