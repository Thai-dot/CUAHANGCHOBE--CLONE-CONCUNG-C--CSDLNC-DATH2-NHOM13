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
    public partial class QuanLyNhanVien_ADMIN : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
      
        public QuanLyNhanVien_ADMIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();

        }

        private void QuanLyNhanVien_ADMIN_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();

            loaddata();

            connection.Close();
        }
        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select * from NhanSu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgv_1.DataSource = table;

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select MaChiNhanh from ChiNhanh";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string magg = datareader.GetInt32(0).ToString();
                cb_ChiNhanh.Items.Add(magg);
            }
            connection.Close();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;

            txb_MaNS.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_HotenNS.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_DiaChi.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_SDTNS.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_Luong.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
            cb_ChiNhanh.Text = dgv_1.Rows[i].Cells[5].Value.ToString();
            cb_Loai.Text = dgv_1.Rows[i].Cells[6].Value.ToString();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_MaNS.Text == "" || txb_HotenNS.Text == "" || txb_DiaChi.Text == "" || txb_SDTNS.Text == "" || txb_Luong.Text == "" || cb_ChiNhanh.Text == "" || cb_Loai.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin nhân sự?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("suanhanvien_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Convert.ToInt32(txb_MaNS.Text);
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txb_HotenNS.Text;
                cmd.Parameters.Add("@DiaChiNS", SqlDbType.NVarChar).Value = txb_DiaChi.Text;
                cmd.Parameters.Add("@SDTNS", SqlDbType.Char).Value = txb_SDTNS.Text;
                cmd.Parameters.Add("@LuongNS", SqlDbType.Float).Value = Convert.ToDouble( txb_Luong.Text);
                cmd.Parameters.Add("@ChiNhanhLamViec", SqlDbType.Int).Value = Convert.ToInt32( cb_ChiNhanh.Text);
                cmd.Parameters.Add("@LoaiNS", SqlDbType.NVarChar).Value = cb_Loai.Text;



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
            if (txb_MaNS.Text == "" )
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin nhân sự?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoanhanvien_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Convert.ToInt32(txb_MaNS.Text);
             
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
            if(txb_HotenNS.Text == "" || txb_DiaChi.Text == "" || txb_SDTNS.Text == "" || txb_Luong.Text == "" || cb_ChiNhanh.Text == "" || cb_Loai.Text == ""||txb_TenDN.Text == "" || txb_MK.Text == "" || txb_NLMK.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin tài khoản?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txb_MK.Text != txb_NLMK.Text)
            {
                MessageBox.Show("Hai mật khẩu chửa đúng?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("taonhanvien_admin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
             
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txb_HotenNS.Text;
                cmd.Parameters.Add("@DiaChiNS", SqlDbType.NVarChar).Value = txb_DiaChi.Text;
                cmd.Parameters.Add("@SDTNS", SqlDbType.Char).Value = txb_SDTNS.Text;
                cmd.Parameters.Add("@LuongNS", SqlDbType.Float).Value = Convert.ToDouble(txb_Luong.Text);
                cmd.Parameters.Add("@ChiNhanhLamViec", SqlDbType.Int).Value = Convert.ToInt32(cb_ChiNhanh.Text);
                cmd.Parameters.Add("@LoaiNS", SqlDbType.NVarChar).Value = cb_Loai.Text;
              
                cmd.Parameters.Add("@TenDN", SqlDbType.Char).Value = txb_TenDN.Text;
                cmd.Parameters.Add("@MatKhau", SqlDbType.Char).Value = txb_MK.Text;



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
    }
}
