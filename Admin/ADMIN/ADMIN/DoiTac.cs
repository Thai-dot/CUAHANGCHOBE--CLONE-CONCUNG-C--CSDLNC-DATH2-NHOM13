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
    public partial class DoiTac : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public DoiTac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void DoiTac_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();

            loaddata();

            connection.Close();
        }

        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select * from DoiTAC";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select DiaChiDT from DoiTac";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string madt = datareader.GetString(0);
                cb_DiaChi.Items.Add(madt);
            }
            connection.Close();



            dgv_1.DataSource = table;

        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            txb_MaDT.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_TenDT.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            cb_DiaChi.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_SDT.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_Email.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_MaDT.Text == "" || txb_TenDT.Text == "" || cb_DiaChi.Text == "" || txb_SDT.Text == "" || txb_Email.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin đối tác?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("suadoitac_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = Convert.ToInt32(txb_MaDT.Text);
                cmd.Parameters.Add("@TenDT", SqlDbType.NVarChar).Value = txb_TenDT.Text;
                cmd.Parameters.Add("@DiaChiDT", SqlDbType.NVarChar).Value = cb_DiaChi.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = txb_SDT.Text;
                cmd.Parameters.Add("@Email_DT", SqlDbType.NVarChar).Value = txb_Email.Text;
                

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
            if (txb_MaDT.Text == "")
            {
                MessageBox.Show("Chưa chọn đối tác?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoadoitac_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = Convert.ToInt32(txb_MaDT.Text);
               
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_TenDT.Text == "" || cb_DiaChi.Text == "" || txb_SDT.Text == "" || txb_Email.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin đối tác?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("taodoitac_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.Add("@TenDT", SqlDbType.NVarChar).Value = txb_TenDT.Text;
                cmd.Parameters.Add("@DiaChiDT", SqlDbType.NVarChar).Value = cb_DiaChi.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = txb_SDT.Text;
                cmd.Parameters.Add("@Email_DT", SqlDbType.NVarChar).Value = txb_Email.Text;


                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo thành công đối tác mới!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();


                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_DiaChi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
