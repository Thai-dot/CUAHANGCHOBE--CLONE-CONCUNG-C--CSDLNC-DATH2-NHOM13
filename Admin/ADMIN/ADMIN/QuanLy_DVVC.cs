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
    public partial class QuanLy_DVVC : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public QuanLy_DVVC()
        {
            InitializeComponent();
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

            txb_MaDV.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_TenDV.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_Email.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_SĐT.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
        }

        private void QuanLy_DVVC_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();

            loaddata();

            connection.Close();
        }

        private void loaddata()
        {


            command = connection.CreateCommand();
            command.CommandText = "select * from donvivanchuyen";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgv_1.DataSource = table;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( txb_TenDV.Text == "" || txb_SĐT.Text == "" || txb_Email.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin ĐƠN VỊ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("themdonvivc_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = txb_TenDV.Text;
                cmd.Parameters.Add("@EmailDV", SqlDbType.NVarChar).Value = txb_Email.Text;
                cmd.Parameters.Add("@SDT_DV", SqlDbType.NVarChar).Value = txb_SĐT.Text;
               



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

        private void button4_Click(object sender, EventArgs e)
        {
            if (txb_TenDV.Text == "" || txb_SĐT.Text == "" || txb_Email.Text == ""||txb_MaDV.Text=="")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin ĐƠN VỊ?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("suadonvivc_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDV", SqlDbType.Int).Value = Convert.ToInt32(txb_MaDV.Text);
                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = txb_TenDV.Text;
                cmd.Parameters.Add("@EmailDV", SqlDbType.NVarChar).Value = txb_Email.Text;
                cmd.Parameters.Add("@SDT_DV", SqlDbType.NVarChar).Value = txb_SĐT.Text;




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

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_MaDV.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin sản phẩm?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoadonvi_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDV", SqlDbType.Int).Value = Convert.ToInt32(txb_MaDV.Text);



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
