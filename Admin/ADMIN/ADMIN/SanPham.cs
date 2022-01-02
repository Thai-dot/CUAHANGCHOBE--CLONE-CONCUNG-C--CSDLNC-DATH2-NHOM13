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
    public partial class SanPham : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
           
            loaddata(); 

            connection.Close();
        }

        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select sp.MaSP,sp.TenSP,sp.GiaBan,sp.GiaMua,sp.LoaiSP,sp.DoiTac,sp.MaGG,dt.TenDoiTac from SanPham sp, DoiTac dt where dt.MaDT = sp.DoiTac";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgv_1.DataSource = table;

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select MaGG from MucGiamGia";
            SqlDataReader datareader2 = command.ExecuteReader();
            while (datareader2.Read())
            {
                string magg = datareader2.GetInt32(0).ToString();
                cb_MaGG.Items.Add(magg);
            }
            connection.Close();

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select MaDT from DoiTac";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string madt = datareader.GetInt32(0).ToString();
                cb_MaDT.Items.Add(madt);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            txb_MaSP.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_TenSP.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_GiaBan.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_GiaMua.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_LoaiSP.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
            cb_MaDT.Text = dgv_1.Rows[i].Cells[5].Value.ToString();
            cb_MaGG.Text = dgv_1.Rows[i].Cells[6].Value.ToString();
            txb_TenDT.Text = dgv_1.Rows[i].Cells[7].Value.ToString();

            connection = new SqlConnection(Global.strconnect);
            connection.Open();

            command = connection.CreateCommand();
            command.CommandText = "select MucGiam from MucGiamGia where MaGG = "+cb_MaGG.Text+"";
            txb_MucGiam.Text = command.ExecuteScalar().ToString();

            connection.Close();
        }

        private void cb_MaGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
            

        }

        private void cb_MaDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_MaSP.Text == "" || txb_TenSP.Text == ""||txb_GiaBan.Text==""||txb_GiaMua.Text==""||txb_LoaiSP.Text==""||cb_MaGG.Text==""||cb_MaDT.Text=="")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin sản phẩm?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("themsuasanpham_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = Convert.ToInt32(txb_MaSP.Text);
                cmd.Parameters.Add("@TenSp", SqlDbType.NVarChar).Value = txb_TenSP.Text;
                cmd.Parameters.Add("@GiaBan", SqlDbType.Float).Value = Convert.ToDouble(txb_GiaBan.Text);
                cmd.Parameters.Add("@GiaMua", SqlDbType.Float).Value = Convert.ToDouble(txb_GiaMua.Text);
                cmd.Parameters.Add("@DoiTac", SqlDbType.Int).Value = cb_MaDT.Text;
                cmd.Parameters.Add("@LoaiSP", SqlDbType.NVarChar).Value = txb_LoaiSP.Text;
                cmd.Parameters.Add("@MaGG", SqlDbType.Int).Value = cb_MaGG.Text;
                


                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
                

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_MaSP.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin sản phẩm?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoasanpham_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = Convert.ToInt32(txb_MaSP.Text);
               


                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
