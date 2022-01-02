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

    public partial class DieuChinhPhieuGiam_QuanLy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public DieuChinhPhieuGiam_QuanLy()
        {
            InitializeComponent();
        }

        private void DieuChinhPhieuGiam_QuanLy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
            loaddata2();
            
            


            connection.Close();
        }



        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select * from MucGiamGia";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;

            
        }

        private void loaddata2()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select MaSP,TenSP,GiaBan,DoiTac,LoaiSP,MaGG from SanPham";
            table2.Clear();
            adapter.SelectCommand = command;
            adapter.Fill(table2);
            dgv_2.DataSource = table2;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_QuanLy home = new Home_QuanLy();
            home.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txb_MucGiam.Text == ""||date_BD.Text == ""||date_KT.Text == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("taomucgiamgia_nv", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NgayBD", SqlDbType.Date).Value = date_BD.Text;
                cmd.Parameters.Add("@NgayKT", SqlDbType.Date).Value = date_KT.Text;
                cmd.Parameters.Add("@MucGiam", SqlDbType.Float).Value = txb_MucGiam.Text;
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm mức giảm giá mới!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loaddata();
                connection.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txb_MaMucGiam.Text == ""||txb_MaSP.Text == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("apdungmucgiamgia_ns", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaGG", SqlDbType.Int).Value = Convert.ToInt32(txb_MaMucGiam.Text);
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = Convert.ToInt32(txb_MaSP.Text);
          

                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã áp dụng mức giảm giá vào sản phẩm!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loaddata2();
                connection.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (txb_MaMucGiam.Text == "" || txb_XoaMGG.Text == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoamucgiamgia_sp", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaGG", SqlDbType.Int).Value = Convert.ToInt32(txb_MaMucGiam.Text);
               


                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công mức giảm giá!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loaddata();
                connection.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (txb_MaMucGiam.Text == "" || txb_CapNhatMG.Text == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("capnhatmucgiamgia_nv", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaGG", SqlDbType.Int).Value = Convert.ToInt32(txb_MaMucGiam.Text);
                cmd.Parameters.Add("@MucGiamGia", SqlDbType.Float).Value = Convert.ToDouble(txb_CapNhatMG.Text);



                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công mức giảm giá!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loaddata();
                connection.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txb_MaMucGiam.Text == "" || cb_LoaiSP.Text == "")
            {
                MessageBox.Show("Chưa điền đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("capnhatloaisp_mucgiamgia_nv", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaGG", SqlDbType.Int).Value = Convert.ToInt32(txb_MaMucGiam.Text);
                cmd.Parameters.Add("@LoaiSP", SqlDbType.NVarChar).Value = cb_LoaiSP.Text;



                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công loại sp mức giảm giá!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loaddata2();
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
