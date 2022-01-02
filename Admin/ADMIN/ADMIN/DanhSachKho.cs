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
    public partial class DanhSachKho : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public DanhSachKho()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaKho nk = new NhaKho();
            nk.Show();
        }

        private void DanhSachKho_Load(object sender, EventArgs e)
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
            command.CommandText = "Select DiaChiKho from Kho";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string madt = datareader.GetString(0);
                cb_DiaChi.Items.Add(madt);
            }
            connection.Close();



            dgv_1.DataSource = table;

        }

        private void cb_DiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_DiaChi.Text == "")
            {
                return;
            }

            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select * from Kho where DiaChiKho = '"+cb_DiaChi.Text+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            connection.Close();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            txb_MaKHo.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_TenKho.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_DiaChi.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_SoDienThoai.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            
            
        }

        private void txb_MaKHo_TextChanged(object sender, EventArgs e)
        {
            if (txb_MaKHo.Text == "")
            {
                return;

            }
            else
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "select * from Kho_SanPham where MaKho = '" + txb_MaKHo.Text + "'";
                adapter.SelectCommand = command;
                table2.Clear();
                adapter.Fill(table2);
                dgv_2.DataSource = table2;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_TenKho.Text == "" || txb_DiaChi.Text == "" || txb_SoDienThoai.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin kho?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("taokhomoi_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@TenKho", SqlDbType.NVarChar).Value = txb_TenKho.Text;
                cmd.Parameters.Add("@DiaChiKho", SqlDbType.NVarChar).Value = txb_DiaChi.Text;
                cmd.Parameters.Add("@SDTKho", SqlDbType.Char).Value = txb_SoDienThoai.Text;          

                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo thành công kho mới!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();


                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txb_MaKHo.Text == "")
            {
                MessageBox.Show("Chưa chọn kho?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoakho_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKho", SqlDbType.Int).Value = Convert.ToInt32(txb_MaKHo.Text);

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_TenKho.Text == "" || txb_DiaChi.Text == "" || txb_SoDienThoai.Text == ""||txb_MaKHo.Text=="")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin kho?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("suakho_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKho", SqlDbType.Int).Value = Convert.ToInt32( txb_MaKHo.Text);
                cmd.Parameters.Add("@TenKho", SqlDbType.NVarChar).Value = txb_TenKho.Text;
                cmd.Parameters.Add("@DiaChiKho", SqlDbType.NVarChar).Value = txb_DiaChi.Text;
                cmd.Parameters.Add("@SDTKho", SqlDbType.Char).Value = txb_SoDienThoai.Text;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công kho!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();


                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
