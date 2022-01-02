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
    public partial class TaoHopDong_QuanLy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable(); 
        public TaoHopDong_QuanLy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_QuanLy home = new Home_QuanLy();
            home.Show();
        }

        private void TaoHopDong_QuanLy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            label_DanhSach.Text = label_DanhSach.Text +" "+ Global.TenChiNhanh;
            loaddata();


            connection.Close();
        }

        private void loaddata()
        {
           
            command = connection.CreateCommand();
            command.CommandText = "select * from DOITAC where DiaChiDT = N'"+Global.TenChiNhanh+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgv_1.DataSource = table;
        }
        private void loaddata2()
        {
            label_Hopdong.Text = "Hợp Đồng";
            label_Hopdong.Text = label_Hopdong.Text + " CỦA ĐỐI TÁC " + txb_MaDT.Text;
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select * from HOPDONG where MaDT = "+txb_MaDT.Text+"";
            adapter.SelectCommand = command;
            table2.Clear();
            adapter.Fill(table2);

            dgv_2.DataSource = table2;
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            txb_MaDT.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            if (txb_MaDT.Text == "")
            {
                return;
            }
            else
            {
                loaddata2();
            }
           
        }

        private void dgv_2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            txb_MaHD.Text = dgv_2.Rows[i].Cells[0].Value.ToString();
            date_NgayLap.Text = dgv_2.Rows[i].Cells[1].Value.ToString();
            date_NgayDenHan.Text = dgv_2.Rows[i].Cells[2].Value.ToString();
            txb_MaSOThue.Text = dgv_2.Rows[i].Cells[3].Value.ToString();
            txb_TinhTrang.Text = dgv_2.Rows[i].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_MaDT.Text == "" || txb_MaHD.Text == ""||txb_MaSOThue.Text==""||date_NgayDenHan.Text==""||date_NgayLap.Text==""||txb_TinhTrang.Text=="")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("kykethopdong_ql", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = txb_MaDT.Text;
                cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Global.MaNS;
                cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = txb_MaHD.Text;
                cmd.Parameters.Add("@NgayLap", SqlDbType.Date).Value = date_NgayLap.Text;
                cmd.Parameters.Add("@NgayKT", SqlDbType.Date).Value = date_NgayDenHan.Text;
                cmd.Parameters.Add("@MST", SqlDbType.NVarChar).Value = txb_MaSOThue.Text;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = txb_TinhTrang.Text;
                


                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata2();           

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
